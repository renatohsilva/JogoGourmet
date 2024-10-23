namespace JogoGourmetView;

partial class InputBox
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private Label lblPrompt;
    private TextBox txtInput;
    private Button btnOk;
    private Button btnCancel;


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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
        lblPrompt = new Label();
        txtInput = new TextBox();
        btnOk = new Button();
        btnCancel = new Button();
        pictureBoxIcon = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
        SuspendLayout();
        // 
        // lblPrompt
        // 
        lblPrompt.AutoSize = true;
        lblPrompt.Location = new Point(54, 9);
        lblPrompt.Name = "lblPrompt";
        lblPrompt.Size = new Size(38, 15);
        lblPrompt.TabIndex = 0;
        lblPrompt.Text = "label1";
        // 
        // txtInput
        // 
        txtInput.Location = new Point(54, 35);
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(316, 23);
        txtInput.TabIndex = 1;
        // 
        // btnOk
        // 
        btnOk.Location = new Point(214, 64);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(75, 23);
        btnOk.TabIndex = 2;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += BtnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(295, 64);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Cancelar";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += BtnCancel_Click;
        // 
        // pictureBoxIcon
        // 
        pictureBoxIcon.Location = new Point(12, 12);
        pictureBoxIcon.Name = "pictureBoxIcon";
        pictureBoxIcon.Size = new Size(36, 50);
        pictureBoxIcon.TabIndex = 4;
        pictureBoxIcon.TabStop = false;
        // 
        // InputBox
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(382, 101);
        Controls.Add(pictureBoxIcon);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(txtInput);
        Controls.Add(lblPrompt);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MaximumSize = new Size(398, 140);
        MinimumSize = new Size(398, 140);
        Name = "InputBox";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Input";
        ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBoxIcon;
}