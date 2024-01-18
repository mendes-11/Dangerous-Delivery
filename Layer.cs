using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

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

        float currentX = parameters.X;

        foreach (var plano in queue.ToList()) 
        {
            plano.Draw(g, new DrawPlanoParameters { X = currentX });
            currentX += 900 - Velocidade;

    
            if (parameters.X + 900 < 0) // Arrumar, está excluindo e adiantando as imagens 
            {
                queue.Dequeue();
            }
        }

        parameters.X -= Velocidade; 

        if (queue.Count == 0)
        {
            parameters.X = 0;
        }
        
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