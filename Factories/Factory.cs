namespace TextAdventure.Factories;

public abstract class Factory
{
    protected T GetRandomElementByWeight<T> (in List<WeightedElement<T>> list)
    {
        var sortedList = list.OrderByDescending(x => x.Weight).ToList();
        
        int sum = sortedList.Sum(x => x.Weight);
        int rolledValue = Game.random.Next(sum);

        int currentValue = 0;
        foreach (var element in sortedList)
        {
            if(currentValue + element.Weight > rolledValue)
                return element.Element;
            
            currentValue += element.Weight;
        }
        
        // If loop did not return, we are on the last element
        return sortedList.Last().Element;
    }
}