using System.Drawing;
using System.Windows.Forms;

public class GameOver
{
    private Form gameOverForm;

    public GameOver()
    {
        gameOverForm = new Form
        {
            Text = "Opções",
            Size = new Size(700, 500),
            StartPosition = FormStartPosition.CenterScreen,
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
        gameOverForm.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                gameOverForm.Close();
            }
        };
    }

    public void Mostrar()
    {
        gameOverForm.ShowDialog();
    }
}