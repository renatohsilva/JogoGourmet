using JogoGourmetCore;

namespace JogoGourmetView;

/// <summary>
/// Representa o formulário do jogo de adivinhação de pratos.
/// </summary>
public partial class GameForm : Form
{
    private Game game; // Instância do jogo que gerencia o estado da árvore de perguntas

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="GameForm"/>.
    /// </summary>
    public GameForm()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
        InitializeGame();
    }

    /// <summary>
    /// Inicializa a árvore do jogo.
    /// </summary>
    private void InitializeGame()
    {
        game = new Game();
    }

    /// <summary>
    /// Evento acionado quando o botão de iniciar jogo é clicado.
    /// Mostra o diálogo de confirmação com a pergunta atual.
    /// </summary>
    /// <param name="sender">O objeto que gerou o evento.</param>
    /// <param name="e">Os dados do evento.</param>
    private void BtnStartGame_Click(object sender, EventArgs e)
    {
        ShowConfirmationDialog(game.CurrentNode);
    }

    /// <summary>
    /// Mostra um diálogo de confirmação ao usuário para verificar se a pergunta é correta.
    /// </summary>
    /// <param name="node">O nó atual da árvore de perguntas.</param>
    private void ShowConfirmationDialog(Node node)
    {
        string message = $"O prato que você pensou é uma {node.Question}?";
        DialogResult result = MessageBox.Show(message, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            ProcessYesResponse();
        }
        else
        {
            ProcessNoResponse();
        }
    }

    /// <summary>
    /// Processa a resposta afirmativa do usuário.
    /// Exibe uma mensagem de acerto se o nó atual for terminal.
    /// Caso contrário, avança para o nó correspondente à resposta afirmativa.
    /// </summary>
    private void ProcessYesResponse()
    {
        if (Game.IsTerminalNode(game.CurrentNode))
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetGame();
        }
        else
        {
            game.MoveToYesNode();
            ShowConfirmationDialog(game.CurrentNode);
        }
    }

    /// <summary>
    /// Processa a resposta negativa do usuário.
    /// Se o nó atual for terminal, solicita um novo prato.
    /// Caso contrário, avança para o nó correspondente à resposta negativa.
    /// </summary>
    private void ProcessNoResponse()
    {
        if (Game.IsTerminalNode(game.CurrentNode))
        {
            PromptForNewDish(game.CurrentNode);
        }
        else
        {
            game.MoveToNoNode();
            ShowConfirmationDialog(game.CurrentNode);
        }
    }

    /// <summary>
    /// Solicita ao usuário o nome de um novo prato e uma nova pergunta para atualizar a árvore de perguntas.
    /// </summary>
    /// <param name="node">O nó atual da árvore de perguntas.</param>
    private void PromptForNewDish(Node node)
    {
        string newDish = GetUserInput("Qual prato você pensou?", "Desisto");

        if (!string.IsNullOrEmpty(newDish))
        {
            string newQuestion = GetUserInput($"{newDish} é ________ mas {node.Question} não.", "Complete");

            if (!string.IsNullOrEmpty(newQuestion))
            {
                Game.UpdateGameTree(node, newDish, newQuestion);
                MessageBox.Show("Obrigado! Aprendi um novo prato.", "Obrigado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGame();
            }
        }
        else
        {
            MessageBox.Show("Entrada inválida! O jogo será reiniciado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ResetGame();
        }
    }

    /// <summary>
    /// Solicita uma entrada do usuário através de um diálogo.
    /// </summary>
    /// <param name="message">A mensagem a ser exibida no diálogo.</param>
    /// <param name="title">O título do diálogo.</param>
    /// <returns>A entrada do usuário como uma string.</returns>
    private static string GetUserInput(string message, string title)
    {
        using (var inputBox = new InputBox(message, title, MessageBoxIcon.Question))
        {
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                return inputBox.InputText.Trim();
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// Reinicia o jogo, redefinindo o nó atual para a raiz da árvore.
    /// </summary>
    private void ResetGame()
    {
        game.Reset();
    }
}
