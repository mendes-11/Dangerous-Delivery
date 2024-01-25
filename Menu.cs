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
        this.BackgroundImage = Image.FromFile("./Image/Menu (2).jpg");


        var playButton = CriarBotao("Jogar");
        var opcoesButton = CriarBotao("Opções");
        var exitButton = CriarBotao("Sair");

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

            CentralizarBotao(playButton);
            CentralizarBotao(opcoesButton);
            CentralizarBotao(exitButton);
        };

        timer.Tick += (o, e) =>
        {
            pb.Refresh();
        };
    }

    private Button CriarBotao(string texto)
    {
        var botao = new Button();
        botao.Text = texto;
        botao.Size = new Size(100, 50);
        this.Controls.Add(botao);
        return botao;
    }

    private void CentralizarBotao(Button botao)
    {
        botao.Location = new Point(
            (this.ClientSize.Width - botao.Width) / 2, 
            (this.ClientSize.Height - botao.Height) / 2 + botao.TabIndex * 100);
    }
}
