using System;
using System.Drawing;
using System.Windows.Forms;

public class Menu : Form
{
    private PictureBox pbBackground;
    private Button playButton, opcoesButton, exitButton;

    public Menu()
    {
        WindowState = FormWindowState.Maximized;

        pbBackground = new PictureBox
        {
            Dock = DockStyle.Fill,
            Image = Image.FromFile("./Image/Menu/Menu.jpg"),
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        playButton = CriarBotao("./Image/Menu/jogarButton.png");
        opcoesButton = CriarBotao("./Image/Menu/opcoesButton.png");
        exitButton = CriarBotao("./Image/Menu/sairButton.png");

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

        this.Controls.Add(pbBackground);

        pbBackground.Controls.Add(playButton);
        pbBackground.Controls.Add(opcoesButton);
        pbBackground.Controls.Add(exitButton);

        this.Load += (o, e) =>
        {
            CentralizarBotao(playButton, -250);
            CentralizarBotao(opcoesButton, 0);
            CentralizarBotao(exitButton, 250);
        };
    }

    private Button CriarBotao(string imagemPath)
    {
        var botao = new Button
        {
            Size = new Size(400, 150),
            Image = new Bitmap(Image.FromFile(imagemPath), new Size(390, 150)),
            ImageAlign = ContentAlignment.MiddleLeft,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { BorderSize = 0 },
            TextAlign = ContentAlignment.MiddleCenter
        };

        botao.FlatAppearance.MouseOverBackColor = Color.Transparent;
        botao.FlatAppearance.MouseDownBackColor = Color.Transparent;

        return botao;
    }

    private void CentralizarBotao(Button botao, int position)
    {
        botao.Location = new Point(
            (pbBackground.ClientSize.Width - botao.Width) / 2,
            (pbBackground.ClientSize.Height - botao.Height) / 2 + position
        );
    }
}
