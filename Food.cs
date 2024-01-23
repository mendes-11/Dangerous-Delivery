using System.Collections.Generic;

public class Food {
    public List<ILanche> Lanches { get; set; } = new List<ILanche>();

    

    public void AddFood(ILanche lanche)
        => this.Lanches.Add(lanche);
}