using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
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

        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();
            // 1. Adicione as colunas que faltam no seu SELECT
            string sql = "SELECT cd_usuario, nm_usuario, nm_email, nm_telefone, ic_tipo, nm_rua, nm_bairro, nm_cidade, sg_estado, cd_cep FROM Usuario";

            using (var con = Conexao.Abrir())
            using (var cmd = new SqlCommand(sql, con))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new Usuario
                    {
                        CdUsuario = (int)r["cd_usuario"],
                        NmUsuario = (string)r["nm_usuario"],
                        NmEmail = (string)r["nm_email"],
                        NmTelefone = (string)r["nm_telefone"],
                        IcTipo = (string)r["ic_tipo"],
                        // 2. Mapeie as novas colunas para as propriedades do objeto
                        NmRua = r["nm_rua"].ToString(),
                        NmBairro = r["nm_bairro"].ToString(),
                        NmCidade = r["nm_cidade"].ToString(),
                        SgEstado = r["sg_estado"].ToString(),
                        CdCep = r["cd_cep"].ToString()
                    });
                }
            }
            return lista;
        }

        public void AlterarUsuario(Usuario u)
        {
            // Adicione aqui suas validações (ex: senha não pode ser vazia, email deve ser válido)
            if (string.IsNullOrWhiteSpace(u.NmEmail))
                throw new Exception("O e-mail é obrigatório.");

            _dal.Alterar(u); // Chama o método na DAL que faz o UPDATE geral
        }

        public void Excluir(int cdUsuario)
        {
            // Adicione validações extras se necessário (ex: não excluir o próprio admin logado)
            _dal.Excluir(cdUsuario);
        }
    }

    public class ViagemBLL
    {
        private readonly ViagemAssentoDAL _dal = new ViagemAssentoDAL();

        // Cole a sua chave do MapQuest aqui dentro das aspas
        private const string API_KEY = "CHjxEPuEeQREnmNAmM6fxNDxUlutp8uT";

        /// <summary>
        /// Busca todas as viagens cadastradas (Sem filtros) para alimentar a Grid do Admin
        /// </summary>
        public List<Viagem> ListarTodas()
        {
            return _dal.ListarTodas(); // Agora mapeia o histórico completo sem sumir com registros!
        }

        /// <summary>
        /// Lista viagens aplicando filtros opcionais e conferindo o horário da aplicação
        /// </summary>
        public List<Viagem> ListarDisponiveis(string origem = null, string destino = null, DateTime? data = null)
        {
            // Regra: Se o usuário digitar campos idênticos na busca, barramos antes do banco
            if (!string.IsNullOrWhiteSpace(origem) && !string.IsNullOrWhiteSpace(destino))
            {
                if (origem.Trim().ToLower() == destino.Trim().ToLower())
                    throw new Exception("Origem e destino não podem ser iguais para a pesquisa.");
            }

            return _dal.ListarDisponiveis(origem, destino, data);
        }

        /// <summary>
        /// Gera a URL do mapa estático baseado na origem e destino informados
        /// </summary>
        public string GerarUrlMapa(string origem, string destino)
        {
            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                return string.Empty;

            // Evita problemas com espaços, acentos e caracteres especiais na URL
            string origemEscapada = WebUtility.UrlEncode(origem);
            string destinoEscapado = WebUtility.UrlEncode(destino);

            // Montando a URL do MapQuest com proporção perfeita 1x1 (quadrada)
            return $"https://www.mapquestapi.com/staticmap/v5/map?" +
                   $"key={API_KEY}&" +
                   $"size=400,400&" +
                   $"start={origemEscapada}&" +
                   $"end={destinoEscapado}&" +
                   $"format=png";
        }

        /// <summary>
        /// Encapsula a criação recebendo o objeto mapeado direto da interface (FormAdmin)
        /// </summary>
        public void Inserir(Viagem novaViagem)
        {
            // Como a tela de criação envia a quantidade de assentos padrão fixada em 40,
            // validamos e repassamos para a regra de negócio interna do sistema.
            string qtAssentosPadrao = "40";

            CriarViagem(
                novaViagem.NmOrigem,
                novaViagem.NmDestino,
                novaViagem.DtViagem,
                novaViagem.VlPreco.ToString(),
                qtAssentosPadrao,
                novaViagem.DsImagem
            );
        }

        /// <summary>
        /// Valida as regras de negócio e insere a viagem com contingência inteligente de imagens
        /// </summary>
        public void CriarViagem(string origem, string destino, DateTime dataHora, string precoStr, string qtAssentosStr, string imagemCaminhoOuUrl)
        {
            // 1. Validações básicas de presença de dados
            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                throw new Exception("Origem e destino são obrigatórios.");

            if (origem.Trim().ToLower() == destino.Trim().ToLower())
                throw new Exception("Origem e destino não podem ser iguais.");

            // 2. Validações numéricas e de negócio com regras estritas (Preço e Assentos)
            if (!decimal.TryParse(precoStr, out decimal preco) || preco <= 0)
                throw new Exception("Preço inválido. Digite um valor maior que zero.");

            if (!int.TryParse(qtAssentosStr, out int qtAssentos) || qtAssentos < 1 || qtAssentos > 50)
                throw new Exception("Quantidade de assentos deve ser entre 1 e 50.");

            if (dataHora <= DateTime.Now)
                throw new Exception("A data da viagem deve ser futura.");

            // 3. Lógica de contingência da imagem (Ambiguidade API vs Upload Manual)
            string caminhoFinalParaBanco = imagemCaminhoOuUrl;

            // Se for um caminho de arquivo físico local do Windows (não começa com HTTP/HTTPS)
            if (!string.IsNullOrWhiteSpace(imagemCaminhoOuUrl) && !imagemCaminhoOuUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(imagemCaminhoOuUrl))
                {
                    // Cria ou mapeia a pasta local dentro do diretório do executável (bin/Debug)
                    string pastaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImagensViagens");
                    if (!Directory.Exists(pastaDestino))
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }

                    // Gera um nome único via Guid para não sobrescrever arquivos com o mesmo nome
                    string extensao = Path.GetExtension(imagemCaminhoOuUrl);
                    string nomeUnico = $"{Guid.NewGuid()}{extensao}";
                    string caminhoCompletoDestino = Path.Combine(pastaDestino, nomeUnico);

                    // Copia o arquivo original do computador para dentro da estrutura do sistema
                    File.Copy(imagemCaminhoOuUrl, caminhoCompletoDestino, true);

                    // Caminho relativo que será persistido no banco de dados
                    caminhoFinalParaBanco = Path.Combine("ImagensViagens", nomeUnico);
                }
            }

            // 4. Instancia o modelo pronto com os dados unificados
            Viagem novaViagem = new Viagem
            {
                NmOrigem = origem.Trim(),
                NmDestino = destino.Trim(),
                DtViagem = dataHora,
                VlPreco = preco,
                DsImagem = caminhoFinalParaBanco
            };

            // 5. Envia para a DAL salvar as informações e gerar os assentos no banco
            _dal.Inserir(novaViagem, qtAssentos);
        }

        /// <summary>
        /// Método chamado pelo FormAdmin para salvar as alterações da viagem editada
        /// </summary>
        public void Alterar(Viagem v)
        {
            // Executa validações de consistência antes de persistir
            if (string.IsNullOrWhiteSpace(v.NmOrigem) || string.IsNullOrWhiteSpace(v.NmDestino))
                throw new Exception("Origem e Destino são campos obrigatórios.");

            if (v.VlPreco <= 0)
                throw new Exception("O preço da passagem deve ser um valor positivo maior que zero.");

            _dal.Alterar(v);
        }

        /// <summary>
        /// Método chamado pelo FormAdmin para remover registros físicos
        /// </summary>
        public void Excluir(int cdViagem)
        {
            if (cdViagem <= 0)
                throw new Exception("Código de identificação de viagem inválido.");

            // DICA DE OURO: Como seu banco possui chaves estrangeiras, a deleção dentro da ViagemAssentoDAL 
            // deve limpar primeiro as dependências na tabela de assentos antes de dar o DELETE na tabela de viagens!
            _dal.Excluir(cdViagem);
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
