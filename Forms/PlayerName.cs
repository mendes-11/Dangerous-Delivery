using System;
using System.Drawing;
using System.Windows.Forms;

public class PlayerNameForm : Form
{
    private TextBox nameTextBox;
    private PictureBox pbBackground;
    private Button okButton;
    private Panel textPanel;

    public string PlayerName { get; private set; }

    public PlayerNameForm()
    {
        InitializeComponent();
        Resize += new EventHandler(FormResized);
    }

    private void InitializeComponent()
    {
        pbBackground = new PictureBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Image = Image.FromFile("./Image/Menu/name.png"),
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        Controls.Add(pbBackground);

        textPanel = new Panel();
        textPanel.BackColor = Color.FromArgb(50, 255, 255, 255);

        nameTextBox = new TextBox();
        nameTextBox.Dock = DockStyle.Fill;
        nameTextBox.BackColor = Color.White;
        nameTextBox.BorderStyle = BorderStyle.None;

        okButton = new Button();
        okButton.Location = new Point(630, 300); 
        okButton.Size = new Size(70, 73); 
        okButton.Image = Image.FromFile("./Image/Menu/star.png");
        okButton.ImageAlign = ContentAlignment.MiddleCenter;
        okButton.TextImageRelation = TextImageRelation.ImageAboveText;
        okButton.Text = "";
        okButton.FlatStyle = FlatStyle.Flat;
        okButton.FlatAppearance.BorderSize = 0;
        okButton.BackColor = Color.Transparent;
        okButton.FlatAppearance.MouseOverBackColor = okButton.BackColor;
        okButton.FlatAppearance.MouseDownBackColor = okButton.BackColor; 
        okButton.Click += OkButtonClick;
        pbBackground.Controls.Add(okButton);
        ;

        textPanel.Controls.Add(nameTextBox);
        pbBackground.Controls.Add(textPanel);

        Size = new Size(783, 438);
        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.CenterScreen;
        TransparencyKey = Color.FromArgb(0, 0, 1);
        BackColor = Color.FromArgb(0, 0, 1);
    }

    private void OkButtonClick(object sender, EventArgs e)
    {
        PlayerName = nameTextBox.Text;
        DialogResult = DialogResult.OK;
    }

    private void FormResized(object sender, EventArgs e)
    {
        textPanel.Location = new Point(
            (this.ClientSize.Width - textPanel.Width) / 2,
            (int)(this.ClientSize.Height * 0.85)
        );
        textPanel.Size = new Size(200, 20);
    }
}
