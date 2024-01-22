using System;
using System.Drawing;
using System.Windows.Forms;

public class Player
{
    private const int TamanhoJogador = 170;
    private int posX = 500;
    private int posY = 530;
    private int velocidade = 30;
    private int frameAtual = 0;

    private int lastPosX;
    private int lastPosY;

    private Image playerSpriteSheet;
    private const int NumeroDeQuadros = 4;

    private Timer animationTimer;

    public Player()
    {
        playerSpriteSheet = Image.FromFile("./Image/man.png");
        animationTimer = new Timer { Interval = 100, Enabled = true };
        animationTimer.Tick += (sender, e) => Animate();
    }

    public void MoveLeft()
    {
        lastPosX = posX;
        posX -= velocidade;
    }

    public void MoveRight()
    {
        lastPosX = posX;
        posX += velocidade;
    }

    public void MoveUp()
    {
        lastPosY = posY;
        posY -= velocidade;
    }

    public void MoveDown()
    {
        lastPosY = posY;
        posY += velocidade;
    }

    private void Animate()
    {
        frameAtual = (frameAtual + 1) % NumeroDeQuadros;
    }

    public bool CheckCollision(int x, int y, int width, int height)
    {
        Rectangle playerRect = new Rectangle(posX, posY, TamanhoJogador, TamanhoJogador);
        Rectangle obstacleRect = new Rectangle(x, y, width, height);

        return playerRect.IntersectsWith(obstacleRect);
    }

    public void ReverseLastMove()
    {
        posX = lastPosX;
        posY = lastPosY;
    }

    public void Draw(Graphics g)
    {
        int larguraDoQuadro = playerSpriteSheet.Width / NumeroDeQuadros;
        Rectangle origem = new Rectangle(
            frameAtual * larguraDoQuadro,
            0,
            larguraDoQuadro,
            playerSpriteSheet.Height
        );
        Rectangle destino = new Rectangle(posX, posY, TamanhoJogador, TamanhoJogador);

        g.DrawImage(playerSpriteSheet, destino, origem, GraphicsUnit.Pixel);
    }
}