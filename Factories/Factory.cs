namespace TextAdventure.Factories;

public abstract class Factory
{
    protected T GetRandomElementByWeight<T>(List<WeightedElement<T>> list)
    {
        list = list.OrderByDescending(x => x.Weight).ToList();
        
        int sum = list.Sum(x => x.Weight);
        int rolledValue = Game.random.Next(sum);

        int currentValue = 0;
        foreach (var element in list)
        {
            if(currentValue + element.Weight > rolledValue)
                return element.Element;
            
            currentValue += element.Weight;
        }
        
        return list.Last().Element;
    }
}