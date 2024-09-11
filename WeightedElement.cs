namespace TextAdventure;

public class WeightedElement<T>(int weight, T Element)
{
    public int Weight { get; }
    public T Element { get; }
}