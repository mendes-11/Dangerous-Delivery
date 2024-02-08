using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;
using System.Collections.Generic;

public class Game : Form
{
    private Bitmap bmp;
    private Graphics g;
    private Parallax parallax;
    private ObjectsLayers objectsLayers;
    private FoodLanche foodLanche;
    private BreakImg breakImg;
    private Player player;
    private Pause pause;
    private RainLayer rain;
    private SoundPlayer backgroundMusicPlayer;
    private bool moveLeft,
        moveRight,
        moveUp,
        moveDown;
    private bool isPaused = false;
    public string PlayerName { get; }
    private GameHUD gameHUD;
    public PictureBox Pb;
    public Game(string playerName)
    {
        PlayerName = playerName;

        this.WindowState = FormWindowState.Maximized;
        this.Text = "Dangerous Delivery";
        this.KeyPreview = true;
        this.Pb = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.RebeccaPurple };
        var timer = new Timer { Interval = 1000 / 60, };

        backgroundMusicPlayer = new SoundPlayer("Music\\1.wav");
        backgroundMusicPlayer.Load();
        // backgroundMusicPlayer.PlayLooping();

        gameHUD = new GameHUD(this);
        gameHUD.LoadRankingsFromFile("rankings.json");
        player = new Player(gameHUD);
        parallax = new Parallax();
        objectsLayers = new ObjectsLayers();
        foodLanche = new FoodLanche(gameHUD);
        breakImg = new BreakImg(gameHUD);
        pause = new Pause();
        rain = new RainLayer(5000);
        pause.ResumeGame += (sender, e) => ResumeGame();

        parallax.Layers.Add(new SkyLayer());
        parallax.Layers.Add(new CloudLayer(0.02f));
        parallax.Layers.Add(new CityLayer(0.03f));
        parallax.Layers.Add(new SlumLayer(0.04F));
        parallax.Layers.Add(new CasasLayer(0.05F));
        parallax.Layers.Add(new RuasLayer(0.07f));
        parallax.Layers.Add(new CalcadasLayer(0.06f));

        // objectsLayers.Objects.Add(new OleoLayer(320, this, gameHUD));
        // objectsLayers.Objects.Add(new PneuLayer(400, this, gameHUD));
        // objectsLayers.Objects.Add(new PneuLayer(200, this, gameHUD));
        // objectsLayers.Objects.Add(new OleoLayer(210, this, gameHUD));

        gameHUD.Player(playerName);

        this.Load += (sender, e) =>
        {
            bmp = new Bitmap(2 * Pb.Width, 2 * Pb.Height);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.CompositingQuality = CompositingQuality.AssumeLinear;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            g.Clear(Color.Black);
            Pb.Image = bmp;
            timer.Start();
        };

        timer.Tick += (sender, e) =>
        {
            if (!isPaused)
            {
                UpdatePlayerMovement();

                parallax.Draw(g, Pb.Size);
                // foodLanche.Draw(g);
                // breakImg.Draw(g);
                // objectsLayers.Draw(g);
                player.Draw(g);
                // gameHUD.Draw(g);
                // rain.Draw(g);
                // rain.Update();
                Pb.Refresh();
            }
        };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            else if (!isPaused && e.KeyCode == Keys.P)
            {
                TogglePause();
            }
            if (e.KeyCode == Keys.G)
            {
                player.UsingGrauImages = !player.UsingGrauImages;
                if (!player.UsingGrauImages)
                {
                    player.isGrauLoopActive = false;
                    player.frameAtual = 0;
                }
            }
            else if (!isPaused)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        moveLeft = true;
                        break;
                    case Keys.D:
                        moveRight = true;
                        break;
                    case Keys.W:
                        moveUp = true;
                        break;
                    case Keys.S:
                        moveDown = true;
                        break;
                }
            }
        };

        this.KeyUp += (o, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    moveLeft = false;
                    break;
                case Keys.D:
                    moveRight = false;
                    break;
                case Keys.W:
                    moveUp = false;
                    break;
                case Keys.S:
                    moveDown = false;
                    break;
            }
        };

        FormClosed += delegate
        {
            Application.Exit();
        };

        this.Controls.Add(Pb);
    }

    private void UpdatePlayerMovement()
    {
        if (moveLeft)
            player.MoveLeft();
        if (moveRight)
            player.MoveRight();
        if (moveUp)
            player.MoveUp();
        if (moveDown)
            player.MoveDown();
    }

    private void ResumeGame()
    {
        isPaused = false;
        pause.HidePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pause.ShowPause();
        }
        else
        {
            ResumeGame();
        }
    }
}
