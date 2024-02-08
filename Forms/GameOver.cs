using System;
using System.Drawing;
using System.Windows.Forms;

public class GameOver
{
    private Form gameOverForm;

    public GameOver()
    {
        gameOverForm = new Form
        {
            Text = "GAME OVER",
            Size = new Size(600, 400),
            StartPosition = FormStartPosition.CenterScreen,
            ControlBox = false,
            FormBorderStyle = FormBorderStyle.None,
            BackgroundImage = Image.FromFile("./Image/Menu/gameover.png"),
            TransparencyKey = Color.FromArgb(0, 0, 1),
            BackColor = Color.FromArgb(0, 0, 1),
            BackgroundImageLayout = ImageLayout.Stretch
        };

        var label = new Label
        {
            Text = "GAME OVER",
            AutoSize = true, // Mudança para AutoSize
            Location = new Point((gameOverForm.Width - 150) / 2, 50),
            Font = new Font("Arial", 26, FontStyle.Bold),
            BackColor = Color.Transparent,
            ForeColor = Color.White
        };

        Image buttonImage = Image.FromFile("./Image/Menu/voltar.png");

        var backButton = new Button
        {
            Size = new Size(190, 75), // Ajustado para melhor acomodar a imagem + texto
            Location = new Point(200, 300),
            Image = buttonImage,
            ImageAlign = ContentAlignment.MiddleLeft,
            TextAlign = ContentAlignment.MiddleRight,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Transparent, // Para botão transparente
        };
        backButton.FlatAppearance.BorderSize = 0;

        // var exitButton = new Button
        // {
        //     Text = "Sair do Jogo",
        //     Size = new Size(150, 30),
        //     Location = new Point(225, 340),
        // };

        backButton.Click += BackToMenuButtonClick;
        // exitButton.Click += ExitGameButtonClick;

        // Adiciona os controles ao Form
        gameOverForm.Controls.Add(label);
        gameOverForm.Controls.Add(backButton);
        // gameOverForm.Controls.Add(exitButton);

        gameOverForm.KeyPreview = true;
    }

    public void ShowPause()
    {
        gameOverForm.ShowDialog();
    }

    public void HidePause()
    {
        gameOverForm.Hide();
    }

    private void BackToMenuButtonClick(object sender, EventArgs e)
    {
        // Adicione lógica para voltar para o menu
        // Por exemplo: menuForm.Show();
    }

    private void ExitGameButtonClick(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
