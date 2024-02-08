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

        gameOverForm.Controls.Add(label);
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
}
