namespace TextAdventure.States;

public class ChoiceEvent(string description, string[] choices)
{
    private readonly string _description = description;
    private readonly string[] _choices = choices;
    
    private List<ConsoleKey> _keybinds = [
        ConsoleKey.D1,
        ConsoleKey.D2, 
        ConsoleKey.D3, 
        ConsoleKey.D4, 
        ConsoleKey.D5, 
        ConsoleKey.D6, 
        ConsoleKey.D7, 
        ConsoleKey.D8, 
        ConsoleKey.D9, 
        ConsoleKey.D0, 
    ];

    public int GetChoice()
    {
        TextHandler.PrettyWrite(_description + "\n", TextHandler.TextType.Description);
        for (int i = 0; i < _choices.Length; i++)
        {
            string choiceText = _choices[i];
            TextHandler.PrettyWrite($"[{i + 1}] {choiceText}",
                TextHandler.TextType.Option,
                i == _choices.Length - 1,
                true);
            
            if(i < _choices.Length - 1)
                Console.WriteLine();
        }

        bool isValidInput = false;
        int choice = -1;
        while (!isValidInput)
        {
            ConsoleKey input = Console.ReadKey().Key;
            if (_keybinds.Contains(input))
            {
                choice = _keybinds.IndexOf(input);
                if (choice >= 0 && choice < _choices.Length)
                    isValidInput = true;
            }

            if (!isValidInput)
            {
                TextHandler.PrettyWrite($"Invalid input. ({input})", TextHandler.TextType.Bad, true);
            }
        }

        Console.Clear();
        
        return choice;
    }
}