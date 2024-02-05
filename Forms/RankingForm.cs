using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class RankingForm : Form
{
    private DataGridView dataGridViewRankings;

    public RankingForm(List<PlayerScore> rankings)
    {
        InitializeComponent();
        LoadRankings(rankings);
    }

    private void InitializeComponent()
    {
        this.dataGridViewRankings = new DataGridView
        {
            Location = new Point(10, 10),
            Size = new Size(280, 400),
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        };

        this.Controls.Add(this.dataGridViewRankings);
        this.Size = new Size(300, 450);
        this.Text = "Rankings";
    }

    private void LoadRankings(List<PlayerScore> rankings)
    {
        dataGridViewRankings.Columns.Clear();
        dataGridViewRankings.Columns.Add("PlayerName", "Player");
        dataGridViewRankings.Columns.Add("Score", "Score");

        foreach (var score in rankings)
        {
            dataGridViewRankings.Rows.Add(score.Name, score.Score);
        }
    }
}