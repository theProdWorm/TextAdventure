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
    
    protected List<WeightedElement<T>> GetListWithInvertedWeights<T>(in List<WeightedElement<T>> list)
    {
        var sortedList = list.OrderByDescending(x => x.Weight).ToList();
        
        var invertedWeightsList = new List<WeightedElement<T>>();
        
        for (int i = 0; i < sortedList.Count; i++)
        {
            var invertedWeightElement = new WeightedElement<T>(
                sortedList[i].Weight, // Get the weight of the current item
                sortedList[^(i + 1)].Element); // Match it with the corresponding element in reversed order
            
            invertedWeightsList.Add(invertedWeightElement);
        }
        
        return invertedWeightsList;
    }
}