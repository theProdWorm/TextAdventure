namespace TextAdventure;

public class WeightedElement<T>(int weight, T element)
{
    public int Weight { get; } = weight;
    public T Element { get; } = element;
}