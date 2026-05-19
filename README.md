# NEXO — Sistema Inteligente de Reserva de Passagens Rodoviárias 🚌✨

O **NEXO** é um aplicativo desktop para gerenciamento e reserva de passagens rodoviárias e excursões, desenvolvido como projeto universitário para as disciplinas de **Desenvolvimento de Aplicativos Desktop** e **Banco de Dados**.

Inspirada no modelo de negócios de grandes startups como *ClickBus* e *Stripe*, a plataforma foi projetada seguindo padrões modernos de arquitetura de software, garantindo segurança na persistência dos dados e uma experiência visual limpa (*clean/SaaS style*).

---

## 🚀 Funcionalidades Principais

### 👤 Área do Cliente (Passageiro)
*   **Cadastro Simplificado**: Integração via código com a API pública do **ViaCEP** utilizando `WebClient` para preenchimento automático do endereço com tratamento de concorrência.
*   **Segurança de Acesso**: Sistema de login seguro com senhas criptografadas nativamente em **SHA-256** antes do envio ao banco de dados.
*   **Mapa Dinâmico de Assentos**: Renderização visual do layout do ônibus em tempo real. Os assentos são coloridos e gerenciados de forma dinâmica baseado no status do banco de dados (**Verde**: Livre | **Amarelo**: Selecionado | **Vermelho**: Ocupado).
*   **Carrinho de Reservas**: Gerenciamento de estado global da sessão via classe estática, permitindo a compra de múltiplos assentos em uma única transação.

### 👑 Área do Administrador (Painel Geral)
*   **Controle de Viagens**: Criação de novas rotas comerciais com validação rigorosa de regras de negócio (bloqueio de rotas duplicadas, preços inválidos e viagens retroativas).
*   **Histórico de Vendas**: Dashboard com listagem integrada de todas as reservas ativas no sistema utilizando agrupamento de strings.

---

## 🛠️ Detalhes Técnicos e Arquitetura

O projeto foi estruturado em **Três Camadas (3-Tier Architecture)** para garantir o desacoplamento do código e facilitar futuras expansões do sistema:

1.  **UI (User Interface)**: Camada de visualização desenvolvida em **C# Windows Forms**, estilizada com elementos *Flat Design*, fontes de sistema otimizadas (`Segoe UI` e `Trebuchet MS`) e paleta de cores institucional.
2.  **BLL (Business Logic Layer)**: Centralização de todas as regras de validação cadastral, gerenciamento de sessões globais, higienização de strings com expressões regulares (`Regex`) e algoritmos de criptografia.
3.  **DAL (Data Access Layer)**: Comunicação direta com o banco de dados utilizando **ADO.NET** puro e manipulação direta de objetos na memória com comandos tipados.

### 🗄️ Engenharia de Banco de Dados
*   **Banco de Dados Utilizado**: Microsoft SQL Server (arquivo local `.mdf` acoplado ao projeto via `|DataDirectory|`).
*   **Integridade Referencial**: Uso rigoroso de chaves estrangeiras (`FOREIGN KEY`) com regras de propagação de deleção (`ON DELETE CASCADE`), restrições de unicidade (`UNIQUE`) e travas de validação em nível de tabela (`CHECK constraints`).
*   **Controle de Concorrência e Transações**: Implementação de **`SqlTransaction` (`Commit`/`Rollback`)** no fechamento do carrinho, garantindo que o vínculo da reserva e a atualização do status do assento para `OCUPADO` ocorram em bloco indissociável (operação "tudo ou nada"), evitando compras duplicadas por múltiplos usuários.
*   **Queries Avançadas**: Consultas otimizadas com junções (`INNER JOIN`, `LEFT JOIN`), funções de agregação (`COUNT`, `HAVING`) e concatenação de dados na própria query através do método **`STRING_AGG`**.

---

## 🛠️ Tecnologias Utilizadas

*   **Linguagem:** C# (.NET Framework)
*   **Interface:** Windows Forms Desktop
*   **Banco de Dados:** Microsoft SQL Server (ADO.NET)
*   **Bibliotecas Nativas:** `System.Security.Cryptography`, `System.Text.RegularExpressions`, `System.Net`

---

## 💻 Como Executar o Projeto

1. Clone o repositório em sua máquina:
   ```bash
   git clone https://github.com
   ```
2. Abra o arquivo de solução **`nexo-app.sln`** no Visual Studio.
3. Certifique-se de que a instância do **SQL Server LocalDB** está ativa em seu Windows.
4. Execute o comando **Recompilar Solução** para estruturar as pastas `bin\Debug`.
5. Pressione **F5 (Play)** para rodar o aplicativo.

---
*Projeto desenvolvido para fins estritamente acadêmicos.*
