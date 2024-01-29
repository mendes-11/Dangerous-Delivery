using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

public class Food
{
    public List<Lanche> Lanches { get; set; } = new List<Lanche>();
    private Queue<Lanche> nextQueue = new();
    private Queue<Lanche> queue = new();
    private Player player = new Player();
    private DateTime nextSpawnTime = DateTime.Now.AddSeconds(0);
    private DrawPlanoParameters parameters = new DrawPlanoParameters { X = 2500 };

    public void Draw(Graphics g)
    {
        refillQueue();
        float currentX = parameters.X;

        if (queue.Any())
        {
            parameters.X -= 15;
            foreach (var lanche in queue.ToList())
            {
                lanche.Draw(g, new DrawPlanoParameters { X = currentX });
                if (Collision.Current.CheckCollisions(lanche))
                {
                    parameters.X = 2220;
                    player.AddFoodBag(lanche);
                    queue.Dequeue();
                }
                else if (parameters.X + lanche.Width < 0)
                {
                    parameters.X = 2220;
                    queue.Dequeue();
                }
                currentX += 600;
            }
            SetNextSpawnTime();
        }
    }

    private void refillQueue()
    {
        if (DateTime.Now >= nextSpawnTime)
        {
            if (nextQueue.Count == 0)
                genNextQueue();
            else
            {
                while (queue.Count < Lanches.Count)
                {
                    var next = nextQueue.Dequeue();
                    queue.Enqueue(next);
                }
            }
        }
    }

    private void SetNextSpawnTime()
    {
        int seconds = Random.Shared.Next(0, 1);
        nextSpawnTime = DateTime.Now.AddSeconds(seconds);
    }

    private void genNextQueue()
    {
        foreach (var lanche in Lanches.OrderBy(p => Random.Shared.Next()))
            nextQueue.Enqueue(lanche);
    }

    public void AddFood(Lanche lanche) => this.Lanches.Add(lanche);
}
