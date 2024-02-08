using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Media;

public class Food
{
    public List<Lanche> Lanches { get; set; } = new List<Lanche>();
    private Queue<Lanche> nextQueue = new();
    private Queue<Lanche> queue = new();
    private Player player;
    private DateTime nextSpawnTime = DateTime.Now.AddSeconds(1);
    private SoundPlayer collectSoundPlayer = new SoundPlayer("./Music\\captura.wav");


    public Food(GameHUD hud)
    {
        player = new Player(hud);
        collectSoundPlayer.Load();
    }
    public void Draw(Graphics g,  SizeF size)
    {
        Queue<Lanche> newQueue = new Queue<Lanche>();

        if (!newQueue.Any())
            refillQueue();

        if (queue.Any())
        {
            foreach (var lanche in queue)
            {
                lanche.Draw(g, new DrawPlanoParameters {Size = size });
                lanche.X -= 0.02f;

                if (Collision.Current.CheckCollisions(lanche) && player.IncrementHUDCounter(lanche))
                {
                    lanche.X = 1.05f;
                    collectSoundPlayer.Play();
                }
                else if (lanche.X + lanche.Width < 0)
                {
                    lanche.X = 1.05f;
                }
                else
                {
                    newQueue.Enqueue(lanche);
                }
            }
            queue = newQueue;
            SetNextSpawnTime();
        }
    }

    private void refillQueue()
    {
        if (DateTime.Now >= nextSpawnTime)
        {
            if (nextQueue.Count == 0)
            {
                genNextQueue();
            }
            else
            {
                while (queue.Count < Random.Shared.Next(1, 3))
                {
                    if (nextQueue.Any())
                    {
                        var next = nextQueue.Dequeue();
                        queue.Enqueue(next);
                    }
                }
            }
        }
    }

    private void SetNextSpawnTime()
    {
        int seconds = Random.Shared.Next(1, 3);
        nextSpawnTime = DateTime.Now.AddSeconds(seconds);
    }

    private void genNextQueue()
    {
        float initialX = 1.05f;

        foreach (var lanche in Lanches.OrderBy(p => Random.Shared.Next()))
        {
            lanche.X = initialX;
            nextQueue.Enqueue(lanche);
            initialX += Random.Shared.NextSingle() * 0.15f + 0.35f;
        }
    }

    public void AddFood(Lanche lanche) => this.Lanches.Add(lanche);
}
