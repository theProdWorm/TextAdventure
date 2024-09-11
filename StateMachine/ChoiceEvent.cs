using TextAdventure.World;

namespace TextAdventure.StateMachine;

public class ChoiceEvent(string description, string[] choices)
{
    private readonly string _description = description;
    private readonly string[] _choices = choices;

    private int GetChoice()
    {
        TextHandler.PrettyWrite(_description + "\n", TextHandler.TextType.Description);
        for (int i = 0; i < _choices.Length; i++)
        {
            string choiceText = _choices[i];
            TextHandler.PrettyWrite($"[{i + 1}] {choiceText}\n",
                TextHandler.TextType.Option,
                i == _choices.Length - 1);
        }

        bool isValidInput = false;
        int choice = -1;
        while (!isValidInput)
        {
            isValidInput = int.TryParse(Console.ReadLine(), out choice) && choice < _choices.Length;

            if (!isValidInput)
            {
                TextHandler.PrettyWrite("Invalid input.", TextHandler.TextType.Bad, true);
            }
        }

        return choice;
    }
}