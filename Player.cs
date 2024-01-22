using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class Player
{
    private const int TamanhoJogador = 300;
    private int posX = 500;
    private int posY = 650;
    private int velocidade = 30;
    private int frameAtual = 0;

    private int lastPosX;
    private int lastPosY;

    private List<Image> playerImages = new List<Image>();
    private const int NumeroDeQuadros = 4;

    private Timer animationTimer;

    public Player()
    {
        foreach (var filePath in Directory.GetFiles("Image/Entregador"))
        {
            playerImages.Add(Image.FromFile(filePath));
        }
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


    private void Animate()
    {
        frameAtual = (frameAtual + 1) % playerImages.Count;
    }

    public void Draw(Graphics g)
    {
        Image currentImage = playerImages[frameAtual];
        Rectangle destino = new Rectangle(posX, posY, TamanhoJogador, TamanhoJogador);

        g.DrawImage(currentImage, destino);
    }
}
