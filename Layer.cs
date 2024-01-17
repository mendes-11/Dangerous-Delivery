using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class Layer : BaseLayer
{
    public List<IPlano> Planos { get; set; }

    private Queue<IPlano> nextQueue = new();
    private Queue<IPlano> queue = new();
    public float Velocidade { get; set; }

    private DrawPlanoParameters parameters = new DrawPlanoParameters { X = 20 };
    
    public Layer(float velocidade)
        => this.Velocidade = velocidade;

    public override void Draw(Graphics g)
    {
        refillQueue();

        foreach (var plano in queue)
        { 
            plano.Draw(g, parameters);
        }

        if (false) // valida se um plano está para fora
            queue.Dequeue();
    }

    private void refillQueue()
    {
        int planosCount = Planos.Count;
        while (queue.Count < planosCount)
        {
            var next = nextQueue.Dequeue();
            queue.Enqueue(next);

            if (nextQueue.Count == 0)
                genNextQueue();
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