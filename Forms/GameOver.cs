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
            FormBorderStyle = FormBorderStyle.FixedSingle
        };

        var label = new Label
        {
            Text = "GAME OVER",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 26, FontStyle.Bold),
        };

        var backButton = new Button
        {
            Text = "Voltar para o Menu",
            Size = new Size(150, 30),
            Location = new Point(50, 300),
        };

        var exitButton = new Button
        {
            Text = "Sair do Jogo",
            Size = new Size(150, 30),
            Location = new Point(400, 300),
        };

        backButton.Click += BackToMenuButtonClick;
        exitButton.Click += ExitGameButtonClick;

        gameOverForm.Controls.Add(label);
        gameOverForm.Controls.Add(backButton);
        gameOverForm.Controls.Add(exitButton);
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
