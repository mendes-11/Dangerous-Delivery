using System;
using System.Drawing;
using System.Windows.Forms;

public class Menu : Form
{
    private Bitmap bmp;
    private Graphics g;

    public Menu()
    {
        var pb = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.Transparent };
        var timer = new Timer { Interval = 20 };

        this.WindowState = FormWindowState.Maximized;
        this.Text = "Dangerous Delivery";
        this.BackgroundImage = Image.FromFile("./Image/Menu/Menu.jpg");

        var playButton = CriarBotao("./Image/Menu/jogarButton.png");
        var opcoesButton = CriarBotao("./Image/Menu/opcoesButton.png");
        var exitButton = CriarBotao("./Image/Menu/sairButton.png");

        playButton.Click += (o, e) =>
        {
            Game game = new Game();
            this.Hide();
            game.Show();
        };

        opcoesButton.Click += (o, e) =>
        {
            Opcoes opcoesForm = new Opcoes();
            opcoesForm.Mostrar();
        };

        exitButton.Click += (o, e) =>
        {
            Application.Exit();
        };

        this.Controls.Add(pb);

        this.Load += (o, e) =>
        {
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            pb.Image = bmp;
            timer.Start();

            CentralizarBotao(playButton, -250);
            CentralizarBotao(opcoesButton, 0);
            CentralizarBotao(exitButton, 250);
        };

        timer.Tick += (o, e) =>
        {
            pb.Refresh();
        };
    }

    private Button CriarBotao(string imagemPath)
    {
        var botao = new Button();
        botao.Size = new Size(400, 150);

        var imagem = Image.FromFile(imagemPath);

        botao.Image = new Bitmap(imagem, botao.Size);
        botao.ImageAlign = ContentAlignment.MiddleLeft;
        botao.BackColor = Color.Transparent;

        botao.TextImageRelation = TextImageRelation.ImageBeforeText;
        botao.ImageAlign = ContentAlignment.MiddleCenter;

        botao.FlatStyle = FlatStyle.Flat;
        botao.FlatAppearance.BorderSize = 0;
        botao.FlatAppearance.MouseOverBackColor = Color.Transparent;
        botao.FlatAppearance.MouseDownBackColor = Color.Transparent;

        this.Controls.Add(botao);
        return botao;
    }

    private void CentralizarBotao(Button botao, int Position)
    {
        botao.Location = new Point(
            (this.ClientSize.Width - botao.Width) / 2,
            (this.ClientSize.Height - botao.Height) / 2 + Position);
    }
}
