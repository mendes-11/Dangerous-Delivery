using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class Layer : BaseLayer
{
    public List<IPlano> Planos { get; set; } = new List<IPlano>();

    private Queue<IPlano> nextQueue = new();
    private Queue<IPlano> queue = new();
    public float Velocidade { get; set; }

    private DrawPlanoParameters parameters = new DrawPlanoParameters { X = 0 };
    
    public Layer(float velocidade)
        => this.Velocidade = velocidade;

    public override void Draw(Graphics g)
    {
        refillQueue();

        foreach (var plano in queue)
        { 
            parameters.X -= Velocidade;
            plano.Draw(g, parameters);
        }

        // if (false)
        //     queue.Dequeue();
    }

    private void refillQueue()
    {
        int planosCount = Planos.Count;
        while (queue.Count < planosCount)
        {
            if (nextQueue.Count == 0)
                genNextQueue();

            var next = nextQueue.Dequeue();
            queue.Enqueue(next);



        }
    }

    private void genNextQueue()
    {
        foreach (var plano in Planos.OrderBy(p => Random.Shared.Next()))
            nextQueue.Enqueue(plano);
    }

    public void AddPlano(IPlano plano)
        => this.Planos.Add(plano);
}