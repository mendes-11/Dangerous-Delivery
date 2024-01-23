using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class Player
{
    private const int TamanhoJogador = 210;
    private int posX = 500;
    private int posY = 650;
    private int velocidade = 30;
    private int frameAtual = 0;

    private const int LimiteSuperiorY = 550;
    private const int LimiteInferiorY = 800;
    private const int LimiteDireitaX = 1450;
    private const int LimiteEsquerdaX = 100;
    private int lastPosX;
    private int lastPosY;

    private List<Image> playerImages = new List<Image>();

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
        int novaPosX = posX - velocidade;
        if (novaPosX >= LimiteEsquerdaX)
        {
            posX = novaPosX;
        }
    }

    public void MoveRight()
    {
        lastPosX = posX;
        int novaPosX = posX + velocidade;
        if (novaPosX <= LimiteDireitaX)
        {
            posX = novaPosX;
        }
    }

    public void MoveUp()
    {
        lastPosY = posY;
        int novaPosY = posY - velocidade;

        if (novaPosY >= LimiteSuperiorY)
        {
            posY = novaPosY;
        }
    }

    public void MoveDown()
    {
        lastPosY = posY;
        int novaPosY = posY + velocidade;

        if (novaPosY <= LimiteInferiorY)
        {
            posY = novaPosY;
        }
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
