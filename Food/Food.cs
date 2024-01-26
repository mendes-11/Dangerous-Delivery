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
    private DateTime lastFrame = DateTime.Now;
    private DateTime nextSpawnTime = DateTime.Now.AddSeconds(5);
    private DrawPlanoParameters parameters = new DrawPlanoParameters { X = 2500 };

    public void Draw(Graphics g)
    {
        refillQueue();
        float currentX = parameters.X;

        if (queue.Any())
        {
            parameters.X -= 8;
            var lanche = queue.Peek();
            lanche.Draw(g, new DrawPlanoParameters { X = currentX });
            if (Collision.Current.CheckCollisions(lanche))
            {
                parameters.X = 2220; 
                queue.Dequeue();
                SetNextSpawnTime();
                return;
            }

            if (parameters.X + queue.Peek().Width < 0)
            {
                parameters.X = 2220; 
                queue.Dequeue();
                SetNextSpawnTime();
            }
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
                var next = nextQueue.Dequeue();
                queue.Enqueue(next);
                SetNextSpawnTime();
            }
        }
    }

    private void SetNextSpawnTime()
    {
        int seconds = Random.Shared.Next(5, 15);
        nextSpawnTime = DateTime.Now.AddSeconds(seconds);
    }

    private void genNextQueue()
    {
        int randomIndex = Random.Shared.Next(Lanches.Count);
        var lanche = Lanches[randomIndex];
        nextQueue.Enqueue(lanche);
    }

    public void AddFood(Lanche lanche) => this.Lanches.Add(lanche);
}
