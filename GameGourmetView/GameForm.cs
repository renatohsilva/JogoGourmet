using GameGourmetCore;

namespace GameGourmetView;

/// <summary>
/// Represents the form for the dish guessing game.
/// </summary>
public partial class GameForm : Form
{
    private Game game; // Instance of the game that manages the state of the question tree

    /// <summary>
    /// Initializes a new instance of the <see cref="GameForm"/> class.
    /// </summary>
    public GameForm()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
        InitializeGame();
    }

    /// <summary>
    /// Initializes the game's question tree.
    /// </summary>
    private void InitializeGame()
    {
        game = new Game();
    }

    /// <summary>
    /// Event triggered when the start game button is clicked.
    /// Displays a confirmation dialog with the current question.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">The event data.</param>
    private void BtnStartGame_Click(object sender, EventArgs e)
    {
        ShowConfirmationDialog(game.CurrentNode);
    }

    /// <summary>
    /// Displays a confirmation dialog asking the user if the current question is correct.
    /// </summary>
    /// <param name="node">The current node of the question tree.</param>
    private void ShowConfirmationDialog(Node node)
    {
        string message = $"Is the dish you're thinking of a {node.Question}?";
        DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    /// Processes the user's affirmative response.
    /// If the current node is a terminal node, displays a success message.
    /// Otherwise, advances to the node corresponding to the "Yes" response.
    /// </summary>
    private void ProcessYesResponse()
    {
        if (Game.IsTerminalNode(game.CurrentNode))
        {
            MessageBox.Show("I guessed it again!", "Gourmet Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetGame();
        }
        else
        {
            game.MoveToYesNode();
            ShowConfirmationDialog(game.CurrentNode);
        }
    }

    /// <summary>
    /// Processes the user's negative response.
    /// If the current node is a terminal node, prompts for a new dish.
    /// Otherwise, advances to the node corresponding to the "No" response.
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
    /// Prompts the user for the name of a new dish and a new question to update the question tree.
    /// </summary>
    /// <param name="node">The current node of the question tree.</param>
    private void PromptForNewDish(Node node)
    {
        string newDish = GetUserInput("What dish were you thinking of?", "I give up");

        if (!string.IsNullOrEmpty(newDish))
        {
            string newQuestion = GetUserInput($"{newDish} is ________ but {node.Question} is not.", "Complete");

            if (!string.IsNullOrEmpty(newQuestion))
            {
                Game.UpdateGameTree(node, newDish, newQuestion);
                MessageBox.Show("Thanks! I learned a new dish.", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGame();
            }
        }
        else
        {
            MessageBox.Show("Invalid input! The game will restart.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ResetGame();
        }
    }

    /// <summary>
    /// Prompts the user for input through a dialog.
    /// </summary>
    /// <param name="message">The message to display in the dialog.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <returns>The user's input as a string.</returns>
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
    /// Resets the game, setting the current node back to the root of the tree.
    /// </summary>
    private void ResetGame()
    {
        game.Reset();
    }
}
