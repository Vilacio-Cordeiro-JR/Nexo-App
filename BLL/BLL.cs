using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Nexo_App.DAL;
using Nexo_App.Models;

namespace Nexo_App.BLL
{
    public static class Sessao
    {
        public static Usuario UsuarioLogado { get; set; }
        public static Viagem ViagemSelecionada { get; set; }
        public static List<Assento> AssentosSelecionados { get; set; } = new List<Assento>();
    }

    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        public static string GerarHash(string senha)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public void Cadastrar(string nome, string email, string senha,
                              string telefone, string cep, string rua,
                              string bairro, string cidade, string estado)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome obrigatório.");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("E-mail inválido.");

            if (senha.Length < 6)
                throw new Exception("Senha deve ter ao menos 6 caracteres.");

            if (!Regex.IsMatch(telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
                throw new Exception("Telefone inválido. Use: (99) 99999-9999");

            if (!Regex.IsMatch(cep, @"^\d{5}-\d{3}$"))
                throw new Exception("CEP inválido. Use: 00000-000");

            if (string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(bairro) ||
                string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado))
                throw new Exception("Por favor, clique em 'Buscar' para preencher os dados de endereço antes de cadastrar.");

            _dal.Inserir(new Usuario
            {
                NmUsuario = nome.Trim(),
                NmEmail = email.Trim().ToLower(),
                DsSenhaHash = GerarHash(senha),
                NmTelefone = telefone.Trim(),
                CdCep = cep.Trim(),
                NmRua = rua.Trim(),
                NmBairro = bairro.Trim(),
                NmCidade = cidade.Trim(),
                SgEstado = estado.Trim().ToUpper(),
                IcTipo = "USER"
            });
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = _dal.BuscarPorLogin(email.Trim().ToLower(), GerarHash(senha));
            if (usuario == null)
                throw new Exception("E-mail ou senha incorretos.");
            return usuario;
        }
    }

    public class ViagemBLL
    {
        private readonly ViagemDAL _dal = new ViagemDAL();

        // Repassa filtros para a DAL
        public List<Viagem> ListarDisponiveis(string origem = null, string destino = null, DateTime? data = null)
        {
            // Regra opcional: Se o usuário digitar campos idênticos na busca, barramos antes do banco
            if (!string.IsNullOrWhiteSpace(origem) && !string.IsNullOrWhiteSpace(destino))
            {
                if (origem.Trim().ToLower() == destino.Trim().ToLower())
                    throw new Exception("Origem e destino não podem ser iguais para a pesquisa.");
            }

            return _dal.ListarDisponiveis(origem, destino, data);
        }

        // Mantém o método CriarViagem exatamente como estava...
        public void CriarViagem(string origem, string destino, DateTime dataHora, string precoStr, string qtAssentosStr)
        {
            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                throw new Exception("Origem e destino são obrigatórios.");

            if (origem.Trim().ToLower() == destino.Trim().ToLower())
                throw new Exception("Origem e destino não podem ser iguais.");

            if (!decimal.TryParse(precoStr, out decimal preco) || preco <= 0)
                throw new Exception("Preço inválido. Digite um valor maior que zero.");

            if (!int.TryParse(qtAssentosStr, out int qtAssentos) || qtAssentos < 1 || qtAssentos > 50)
                throw new Exception("Quantidade de assentos deve ser entre 1 e 50.");

            if (dataHora <= DateTime.Now)
                throw new Exception("A data da viagem deve ser futura.");

            _dal.Inserir(new Viagem
            {
                NmOrigem = origem.Trim(),
                NmDestino = destino.Trim(),
                DtViagem = dataHora,
                VlPreco = preco
            }, qtAssentos);
        }
    }

    public class ReservaBLL
    {
        private readonly ReservaDAL _dal = new ReservaDAL();

        public void ConfirmarReserva(int cdUsuario, int cdViagem, List<Assento> assentos)
        {
            if (assentos == null || assentos.Count == 0)
                throw new Exception("Selecione ao menos um assento.");

            var ids = new List<int>();
            foreach (var a in assentos) ids.Add(a.CdAssento);

            _dal.Inserir(cdUsuario, cdViagem, ids);
        }

        public List<Reserva> ListarTodas() => _dal.ListarTodas();
    }
}
