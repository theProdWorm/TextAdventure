namespace TextAdventure;

public class ChoiceEvent(string description, Dictionary<string, IGameEvent> choices) : IGameEvent
{
    private readonly string description = description;
    private readonly Dictionary<string, IGameEvent> choices = choices;
    
    public IGameEvent Trigger()
    {
        TextHandler.PrettyWrite(description, TextHandler.TextType.Description);
        for (int i = 0; i < choices.Keys.Count; i++)
        {
            string choiceText = choices.Keys.ElementAt(i);
            TextHandler.PrettyWrite($"[{i + 1}] {choiceText}\n",
                TextHandler.TextType.Option,
                i == choices.Keys.Count - 1);
        }

        int input = HandleChoice();

        return choices.ElementAt(0).Value;
    }

    private int HandleChoice()
    {
        bool isValidInput = false;
        int choice = -1;
        while (!isValidInput)
        {
            isValidInput = int.TryParse(Console.ReadLine(), out choice) && choices.Count >= choice;

            if (!isValidInput)
            {
                TextHandler.PrettyWrite("Invalid input.", TextHandler.TextType.Bad, true);
            }
        }

        return choice;
    }
}