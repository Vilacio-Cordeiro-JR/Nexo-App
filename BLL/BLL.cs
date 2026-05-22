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
    /// <summary>
    /// Classe estática responsável por manter o contexto global da sessão do usuário durante o ciclo de vida da aplicação.
    /// Permite acesso centralizado ao usuário logado, viagem selecionada e assentos escolhidos.
    /// </summary>
    public static class Sessao
    {
        public static Usuario UsuarioLogado { get; set; }
        public static Viagem ViagemSelecionada { get; set; }
        public static List<Assento> AssentosSelecionados { get; set; } = new List<Assento>();
    }

    /// <summary>
    /// Camada de regras de negócio para operações relacionadas ao usuário.
    /// Centraliza validações, autenticação e orquestração de persistência.
    /// </summary>
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        /// <summary>
        /// Gera o hash SHA256 da senha para garantir segurança no armazenamento e comparação.
        /// Decisão: SHA256 é utilizado para evitar persistência de senhas em texto puro, mitigando riscos de vazamento.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>Hash SHA256 em formato hexadecimal.</returns>
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

        /// <summary>
        /// Realiza o cadastro de um novo usuário após validações de negócio e formato.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="senha">Senha em texto puro.</param>
        /// <param name="telefone">Telefone no formato (99) 99999-9999.</param>
        /// <param name="cep">CEP no formato 00000-000.</param>
        /// <param name="rua">Nome da rua.</param>
        /// <param name="bairro">Nome do bairro.</param>
        /// <param name="cidade">Nome da cidade.</param>
        /// <param name="estado">Sigla do estado.</param>
        /// <exception cref="Exception">Lança exceção se qualquer validação falhar.</exception>
        public void Cadastrar(string nome, string email, string senha,
                              string telefone, string cep, string rua,
                              string bairro, string cidade, string estado)
        {
            // Validação de presença e formato usando Regex para garantir integridade dos dados.
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

        /// <summary>
        /// Realiza a autenticação do usuário utilizando e-mail e senha.
        /// </summary>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>Instância de Usuario autenticado.</returns>
        /// <exception cref="Exception">Lança exceção se as credenciais forem inválidas.</exception>
        public Usuario Login(string email, string senha)
        {
            var usuario = _dal.BuscarPorLogin(email.Trim().ToLower(), GerarHash(senha));
            if (usuario == null)
                throw new Exception("E-mail ou senha incorretos.");
            return usuario;
        }

        /// <summary>
        /// Lista todos os usuários cadastrados no sistema.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();
            // NOTE: O SELECT inclui todas as colunas relevantes para exibição e edição.
            string sql = "SELECT cd_usuario, nm_usuario, nm_email, nm_telefone, ic_tipo, nm_rua, nm_bairro, nm_cidade, sg_estado, cd_cep FROM Usuario";

            // Decisão: Uso do bloco 'using' para garantir liberação de recursos e evitar leaks de conexão.
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

        /// <summary>
        /// Altera os dados de um usuário existente após validações.
        /// </summary>
        /// <param name="u">Objeto usuário com dados atualizados.</param>
        /// <exception cref="Exception">Lança exceção se o e-mail for inválido.</exception>
        public void AlterarUsuario(Usuario u)
        {
            // Validação de negócio: e-mail não pode ser vazio.
            if (string.IsNullOrWhiteSpace(u.NmEmail))
                throw new Exception("O e-mail é obrigatório.");

            _dal.Alterar(u); // Chama o método na DAL que faz o UPDATE geral
        }

        /// <summary>
        /// Exclui um usuário do sistema.
        /// </summary>
        /// <param name="cdUsuario">Código do usuário.</param>
        public void Excluir(int cdUsuario)
        {
            // TODO: Adicionar validação para impedir exclusão do próprio admin logado, se necessário.
            _dal.Excluir(cdUsuario);
        }
    }

    /// <summary>
    /// Camada de regras de negócio para operações relacionadas a viagens.
    /// Centraliza validações, integração com MapQuest e orquestração de persistência.
    /// </summary>
    public class ViagemBLL
    {
        private readonly ViagemAssentoDAL _dal = new ViagemAssentoDAL();

        // Chave da API MapQuest utilizada para geração de mapas estáticos.
        private const string API_KEY = "CHjxEPuEeQREnmNAmM6fxNDxUlutp8uT";

        /// <summary>
        /// Busca todas as viagens cadastradas (sem filtros) para alimentar a Grid do Admin.
        /// </summary>
        /// <returns>Lista de viagens.</returns>
        public List<Viagem> ListarTodas()
        {
            return _dal.ListarTodas(); // Agora mapeia o histórico completo sem sumir com registros!
        }

        /// <summary>
        /// Lista viagens aplicando filtros opcionais e conferindo o horário da aplicação.
        /// </summary>
        /// <param name="origem">Origem da viagem (opcional).</param>
        /// <param name="destino">Destino da viagem (opcional).</param>
        /// <param name="data">Data da viagem (opcional).</param>
        /// <returns>Lista de viagens disponíveis.</returns>
        /// <exception cref="Exception">Lança exceção se origem e destino forem iguais.</exception>
        public List<Viagem> ListarDisponiveis(string origem = null, string destino = null, DateTime? data = null)
        {
            // Regra de negócio: impedir busca com origem e destino idênticos.
            if (!string.IsNullOrWhiteSpace(origem) && !string.IsNullOrWhiteSpace(destino))
            {
                if (origem.Trim().ToLower() == destino.Trim().ToLower())
                    throw new Exception("Origem e destino não podem ser iguais para a pesquisa.");
            }

            return _dal.ListarDisponiveis(origem, destino, data);
        }

        /// <summary>
        /// Gera a URL do mapa estático baseado na origem e destino informados.
        /// Decisão: A geração da URL é feita na BLL para centralizar regras de integração externa.
        /// </summary>
        /// <param name="origem">Cidade de origem.</param>
        /// <param name="destino">Cidade de destino.</param>
        /// <returns>URL do mapa estático do MapQuest.</returns>
        public string GerarUrlMapa(string origem, string destino)
        {
            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                return string.Empty;

            // Decisão: UrlEncode para evitar problemas com caracteres especiais.
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
        /// Encapsula a criação recebendo o objeto mapeado direto da interface (FormAdmin).
        /// </summary>
        /// <param name="novaViagem">Objeto viagem preenchido.</param>
        public void Inserir(Viagem novaViagem)
        {
            // Decisão: Quantidade de assentos padrão fixada em 40 para padronização operacional.
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
        /// Valida as regras de negócio e insere a viagem com contingência inteligente de imagens.
        /// </summary>
        /// <param name="origem">Origem da viagem.</param>
        /// <param name="destino">Destino da viagem.</param>
        /// <param name="dataHora">Data e hora da viagem.</param>
        /// <param name="precoStr">Preço em string.</param>
        /// <param name="qtAssentosStr">Quantidade de assentos em string.</param>
        /// <param name="imagemCaminhoOuUrl">Caminho local ou URL da imagem.</param>
        /// <exception cref="Exception">Lança exceção se qualquer validação falhar.</exception>
        public void CriarViagem(string origem, string destino, DateTime dataHora, string precoStr, string qtAssentosStr, string imagemCaminhoOuUrl)
        {
            // Validações de presença, formato e regras de negócio.
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

            // Decisão: Contingência para imagens locais ou URLs externas.
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

            // Instancia o modelo pronto com os dados unificados
            Viagem novaViagem = new Viagem
            {
                NmOrigem = origem.Trim(),
                NmDestino = destino.Trim(),
                DtViagem = dataHora,
                VlPreco = preco,
                DsImagem = caminhoFinalParaBanco
            };

            // Decisão: A DAL é responsável por inserir a viagem e gerar os assentos em transação.
            _dal.Inserir(novaViagem, qtAssentos);
        }

        /// <summary>
        /// Método chamado pelo FormAdmin para salvar as alterações da viagem editada.
        /// </summary>
        /// <param name="v">Viagem editada.</param>
        /// <exception cref="Exception">Lança exceção se dados obrigatórios forem inválidos.</exception>
        public void Alterar(Viagem v)
        {
            // Validações de consistência antes de persistir.
            if (string.IsNullOrWhiteSpace(v.NmOrigem) || string.IsNullOrWhiteSpace(v.NmDestino))
                throw new Exception("Origem e Destino são campos obrigatórios.");

            if (v.VlPreco <= 0)
                throw new Exception("O preço da passagem deve ser um valor positivo maior que zero.");

            _dal.Alterar(v);
        }

        /// <summary>
        /// Método chamado pelo FormAdmin para remover registros físicos.
        /// </summary>
        /// <param name="cdViagem">Código da viagem.</param>
        /// <exception cref="Exception">Lança exceção se o código for inválido.</exception>
        public void Excluir(int cdViagem)
        {
            if (cdViagem <= 0)
                throw new Exception("Código de identificação de viagem inválido.");

            // NOTE: A exclusão em cascata é tratada na DAL, respeitando integridade referencial.
            _dal.Excluir(cdViagem);
        }
    }

    /// <summary>
    /// Camada de regras de negócio para operações de reserva de assentos.
    /// Centraliza validações e orquestração de persistência transacional.
    /// </summary>
    public class ReservaBLL
    {
        private readonly ReservaDAL _dal = new ReservaDAL();

        /// <summary>
        /// Confirma a reserva de assentos para um usuário em uma viagem.
        /// </summary>
        /// <param name="cdUsuario">Código do usuário.</param>
        /// <param name="cdViagem">Código da viagem.</param>
        /// <param name="assentos">Lista de assentos selecionados.</param>
        /// <exception cref="Exception">Lança exceção se nenhum assento for selecionado.</exception>
        public void ConfirmarReserva(int cdUsuario, int cdViagem, List<Assento> assentos)
        {
            if (assentos == null || assentos.Count == 0)
                throw new Exception("Selecione ao menos um assento.");

            var ids = new List<int>();
            foreach (var a in assentos) ids.Add(a.CdAssento);

            // Decisão: A DAL executa a reserva e marcação dos assentos em transação para evitar overbooking.
            _dal.Inserir(cdUsuario, cdViagem, ids);
        }

        /// <summary>
        /// Lista todas as reservas do sistema.
        /// </summary>
        /// <returns>Lista de reservas.</returns>
        public List<Reserva> ListarTodas() => _dal.ListarTodas();
    }
}
