namespace GameGourmetView;

/// <summary>
/// Represents a custom input box that prompts the user for input.
/// Includes a prompt, a title, and a message icon.
/// </summary>
public partial class InputBox : Form
{
    /// <summary>
    /// The input text provided by the user.
    /// </summary>
    public string InputText { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InputBox"/> class.
    /// </summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="title">The title of the input box.</param>
    /// <param name="icon">The icon to display in the input box.</param>
    public InputBox(string prompt, string title, MessageBoxIcon icon)
    {
        InitializeComponent();
        lblPrompt.Text = prompt;
        Text = title;

        pictureBoxIcon.Image = icon switch
        {
            MessageBoxIcon.Information => SystemIcons.Information.ToBitmap(),
            MessageBoxIcon.Warning => SystemIcons.Warning.ToBitmap(),
            MessageBoxIcon.Error => SystemIcons.Error.ToBitmap(),
            MessageBoxIcon.Question => SystemIcons.Question.ToBitmap(),
            _ => null,
        };
    }

    /// <summary>
    /// Event triggered when the "OK" button is clicked.
    /// Captures the input text and closes the input box with an OK result.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">The event data.</param>
    private void BtnOk_Click(object sender, EventArgs e)
    {
        InputText = txtInput.Text;
        DialogResult = DialogResult.OK;
        Close();
    }

    /// <summary>
    /// Event triggered when the "Cancel" button is clicked.
    /// Closes the input box with a Cancel result.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">The event data.</param>
    private void BtnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
