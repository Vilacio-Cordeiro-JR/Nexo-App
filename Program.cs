using System;
using System.Windows.Forms;
using Nexo_App.BLL;
using Nexo_App.UI;

namespace Nexo_App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var login = new FormLogin())
                {
                    Application.Run(login);
                }

                if (Sessao.UsuarioLogado != null)
                {
                    Form telaDestino = null;
                    string tipoUsuario = Sessao.UsuarioLogado.IcTipo?.ToUpper() ?? "";

                    if (tipoUsuario == "ADMIN")
                    {
                        telaDestino = new FormAdmin();
                    }
                    else if (tipoUsuario == "USER")
                    {
                        // 🔍 BLOCO DE DIAGNÓSTICO: Captura qualquer erro de inicialização da Home
                        try
                        {
                            telaDestino = new FormHome();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"O construtor do FormHome quebrou antes de abrir!\n\nErro: {ex.Message}\n\nStack: {ex.StackTrace}",
                                            "Erro Fatal no FormHome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break; // Aborta o loop para você ver o erro
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Tipo de usuário desconhecido: '{tipoUsuario}'.",
                                        "Erro de Roteamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    // Se a tela foi criada com sucesso, tenta rodar o loop de mensagens dela
                    if (telaDestino != null)
                    {
                        try
                        {
                            Application.Run(telaDestino);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"O FormHome quebrou enquanto rodava!\n\nErro: {ex.Message}",
                                            "Erro em Tempo de Execução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (Sessao.UsuarioLogado == null)
                    {
                        continue;
                    }
                }
                else
                {
                    // 🔍 DIAGNÓSTICO B: Se o login fechou mas a sessão sumiu
                    MessageBox.Show("O FormLogin foi fechado, mas o objeto 'Sessao.UsuarioLogado' está NULO!",
                                    "Aviso de Estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                break;
            }
        }
    }
}