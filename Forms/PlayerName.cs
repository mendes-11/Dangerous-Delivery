using System;
using System.Windows.Forms;

public class PlayerNameForm : Form
{
    private Label nameLabel;
    private TextBox nameTextBox;
    private Button okButton;

    public string PlayerName { get; private set; }

    public PlayerNameForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        nameLabel = new Label();
        nameTextBox = new TextBox();
        okButton = new Button();

        nameLabel.Text = "Digite seu nome:";
        nameLabel.Location = new System.Drawing.Point(10, 10);

        nameTextBox.Location = new System.Drawing.Point(10, 30);
        nameTextBox.Size = new System.Drawing.Size(200, 20);

        okButton.Text = "OK";
        okButton.Location = new System.Drawing.Point(10, 60);
        okButton.Click += OkButtonClick;

        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(okButton);

        Size = new System.Drawing.Size(600, 300);
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;
    }

    private void OkButtonClick(object sender, EventArgs e)
    {
        PlayerName = nameTextBox.Text;
        DialogResult = DialogResult.OK;
    }
}
