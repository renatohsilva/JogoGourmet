namespace GameGourmetView;

partial class GameForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
        lblInitialMessage = new Label();
        btnStartGame = new Button();
        SuspendLayout();
        // 
        // lblInitialMessage
        // 
        lblInitialMessage.AutoSize = true;
        lblInitialMessage.Font = new Font("Segoe UI", 14F);
        lblInitialMessage.Location = new Point(50, 50);
        lblInitialMessage.Name = "lblInitialMessage";
        lblInitialMessage.Size = new Size(311, 25);
        lblInitialMessage.TabIndex = 0;
        lblInitialMessage.Text = "Think of a dish you like!";
        // 
        // btnStartGame
        // 
        btnStartGame.Location = new Point(150, 100);
        btnStartGame.Name = "btnStartGame";
        btnStartGame.Size = new Size(100, 40);
        btnStartGame.TabIndex = 1;
        btnStartGame.Text = "OK";
        btnStartGame.UseVisualStyleBackColor = true;
        btnStartGame.Click += BtnStartGame_Click;
        // 
        // GameForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(406, 171);
        Controls.Add(lblInitialMessage);
        Controls.Add(btnStartGame);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MaximumSize = new Size(422, 210);
        MinimumSize = new Size(422, 210);
        Name = "GameForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gourmet Game";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblInitialMessage;
    private Button btnStartGame;
}