using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

public class Food {
    public List<Lanche> Lanches { get; set; } = new List<Lanche>();
    private Queue<Lanche> nextQueue = new();
    private Queue<Lanche> queue = new();
    private DateTime lastFrame = DateTime.Now;

    private DrawPlanoParameters parameters = new DrawPlanoParameters { X = 0};

    public void Draw(Graphics g)
    {
        refillQueue();

        parameters.X -= 300 * deltaTime();
        float currentX = parameters.X;

        foreach (var lanche in queue) 
        {
            lanche.Draw(g, new DrawPlanoParameters { X = currentX });
            currentX += lanche.Width - 2000;
        }

        if (parameters.X + queue.Peek().Width < 0)
        {
            parameters.X += queue.Peek().Width + 1900;
            queue.Dequeue();
        }
    }

    private float deltaTime()
    {
        var newFrame = DateTime.Now;
        var time = newFrame - lastFrame;
        lastFrame = newFrame;

        return (float)time.TotalSeconds;
    }

    private void refillQueue()
    {
        int lanchesCount = Lanches.Count;
        while (queue.Count < lanchesCount)
        {
            if (nextQueue.Count == 0)
                genNextQueue();

            var next = nextQueue.Dequeue();
            queue.Enqueue(next);
        }
    }

    private void genNextQueue()
    {
        foreach (var lanche in Lanches.OrderBy(p => Random.Shared.Next()))
            nextQueue.Enqueue(lanche);
    }

    public void AddFood(Lanche lanche)
        => this.Lanches.Add(lanche);
}