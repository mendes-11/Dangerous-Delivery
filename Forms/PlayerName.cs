using System;
using System.Drawing;
using System.Windows.Forms;

public class PlayerNameForm : Form
{
    private Label nameLabel;
    private TextBox nameTextBox;
    private PictureBox pbBackground;
    private Button okButton;

    public string PlayerName { get; private set; }

    public PlayerNameForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Configurar o PictureBox para ser o plano de fundo
        pbBackground = new PictureBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Image = Image.FromFile("./Image/Menu/name.png"),
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        Controls.Add(pbBackground);

        // Configurar os controles de entrada
        // nameLabel = new Label();
        // nameLabel.Text = "Digite seu nome:";
        // nameLabel.Location = new Point(10, 10);
        // pbBackground.Controls.Add(nameLabel);

        // nameTextBox = new TextBox();
        // nameTextBox.Location = new Point(10, 30);
        // nameTextBox.Size = new Size(200, 20);
        // pbBackground.Controls.Add(nameTextBox);

        // okButton = new Button();
        // okButton.Text = "OK";
        // okButton.Location = new Point(10, 60);
        // okButton.Click += OkButtonClick;
        // pbBackground.Controls.Add(okButton);

        // Configurações do formulário
        Size = new Size(900, 450);
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;

        // Definir cor de fundo transparente
        this.TransparencyKey = Color.FromArgb(0, 0, 1);
        this.BackColor = Color.FromArgb(0, 0, 1);
    }

    private void OkButtonClick(object sender, EventArgs e)
    {
        PlayerName = nameTextBox.Text;
        DialogResult = DialogResult.OK;
    }
}
