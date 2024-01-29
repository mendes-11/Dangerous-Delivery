using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class Player : ObjBox
{
    private const int TamanhoJogador = 210;
    private const int LimiteSuperiorY = 550;
    private const int LimiteInferiorY = 770;
    private const int LimiteDireitaX = 1450;
    private const int LimiteEsquerdaX = 100;
    private List<Image> playerImages = new List<Image>();
    private Timer animationTimer;
    private int posX = 500;
    private int posY = 650;
    private float velocidadeMax = 17f;
    private float aceleracao = 2f;
    private float desaceleracao = 1.8f;
    private float velocidadeX = 0;
    private float velocidadeY = 0;
    private int frameAtual = 0;
    public Queue<Lanche> BagLanche = new();
    private float centerScreen;

    public override RectangleF Box { get; set; }

    public Player()
    {
        foreach (var filePath in Directory.GetFiles("Image/Entregador"))
        {
            playerImages.Add(Image.FromFile(filePath));
        }

        centerScreen = Screen.PrimaryScreen.Bounds.Width / 2f;
        Collision.Current.AddObjBox(this);
        animationTimer = new Timer { Interval = 100, Enabled = true };
        animationTimer.Tick += (sender, e) => Update();
    }

    public void MoveLeft()
    {
        velocidadeX = Math.Max(velocidadeX - aceleracao, -velocidadeMax);
    }

    public void MoveRight()
    {
        velocidadeX = Math.Min(velocidadeX + aceleracao, velocidadeMax);
    }

    public void MoveUp()
    {
        velocidadeY = Math.Max(velocidadeY - aceleracao, -velocidadeMax);
    }

    public void MoveDown()
    {
        velocidadeY = Math.Min(velocidadeY + aceleracao, velocidadeMax);
    }

    public void Update()
    {
        ApplyFriction();
        UpdatePosition();
        Animate();
    }

    private void ApplyFriction()
    {
        if (velocidadeX > 0)
            velocidadeX = Math.Max(0, velocidadeX - desaceleracao);
        else if (velocidadeX < 0)
            velocidadeX = Math.Min(0, velocidadeX + desaceleracao);

        if (velocidadeY > 0)
            velocidadeY = Math.Max(0, velocidadeY - desaceleracao);
        else if (velocidadeY < 0)
            velocidadeY = Math.Min(0, velocidadeY + desaceleracao);
    }

    private void UpdatePosition()
    {
        posX = Math.Clamp(posX + (int)velocidadeX, LimiteEsquerdaX, LimiteDireitaX);
        posY = Math.Clamp(posY + (int)velocidadeY, LimiteSuperiorY, LimiteInferiorY);
    }

    private void Animate()
    {
        frameAtual = (frameAtual + 1) % playerImages.Count;
    }

    public void Draw(Graphics g)
    {
        Image currentImage = playerImages[frameAtual];
        float deltaY = -posY / 500f;
        float scaleFactor = 0.2f - deltaY * 0.7f;

        int adjustedSize = (int)(TamanhoJogador * scaleFactor);
        int adjustedX = posX + (TamanhoJogador - adjustedSize) / 2;
        int adjustedY = posY + (TamanhoJogador - adjustedSize) / 2;

        Rectangle destino = new Rectangle(adjustedX, adjustedY, adjustedSize, adjustedSize);
        CreateHitbox(adjustedX, posY + 143, adjustedSize, adjustedSize / 3f);
        g.DrawRectangle(Pens.White, Box);
        g.DrawImage(currentImage, destino);
    }

    public void CheckedCollision()
    {
        if (Collision.Current.CheckCollisions(this))
        {
            MessageBox.Show(
                "Collision detected!",
                "Collision Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }

    public void AddFoodBag(Lanche lanche)
    {
        BagLanche.Enqueue(lanche);
    }
}
