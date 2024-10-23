namespace JogoGourmetView;

/// <summary>
/// Representa uma caixa de entrada personalizada que solicita uma entrada do usuário.
/// Inclui um prompt, um título e um ícone de mensagem.
/// </summary>
public partial class InputBox : Form
{
    /// <summary>
    /// O texto de entrada fornecido pelo usuário.
    /// </summary>
    public string InputText { get; private set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="InputBox"/>.
    /// </summary>
    /// <param name="prompt">A mensagem a ser exibida para o usuário.</param>
    /// <param name="title">O título da caixa de entrada.</param>
    /// <param name="icon">O ícone a ser exibido na caixa de entrada.</param>
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
    /// Evento acionado quando o botão "OK" é clicado.
    /// Captura o texto de entrada e fecha a caixa de entrada com resultado OK.
    /// </summary>
    /// <param name="sender">O objeto que gerou o evento.</param>
    /// <param name="e">Os dados do evento.</param>
    private void BtnOk_Click(object sender, EventArgs e)
    {
        InputText = txtInput.Text;
        DialogResult = DialogResult.OK;
        Close();
    }

    /// <summary>
    /// Evento acionado quando o botão "Cancelar" é clicado.
    /// Fecha a caixa de entrada com resultado Cancel.
    /// </summary>
    /// <param name="sender">O objeto que gerou o evento.</param>
    /// <param name="e">Os dados do evento.</param>
    private void BtnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
