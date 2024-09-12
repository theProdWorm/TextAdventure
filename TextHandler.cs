namespace TextAdventure;

public static class TextHandler
{
    private static readonly int TextDelay = 30;

    public enum TextType
    {
        Good,
        Bad,
        Description,
        Option,
        Normal
    }

    public static void PrettyWrite(string output, TextType type = TextType.Normal, bool isLastLine = false, bool printFast = false)
    {
        var color = GetColor(type);
        Console.ForegroundColor = color;
        
        if(type == TextType.Option)
            Console.Write('\t');
        
        if(printFast)
        {
            Console.Write(output);
        }
        else
        {
            foreach (var letter in output)
            {
                Console.Write(letter);
                Thread.Sleep(TextDelay);
            }
        }
        
        Thread.Sleep(500);
        
        Console.ForegroundColor = ConsoleColor.Gray;
        
        if(isLastLine)
            Console.Write("\n>");
    }

    private static ConsoleColor GetColor(TextType type) => type switch {
        
        TextType.Good => ConsoleColor.Green,
        TextType.Bad => ConsoleColor.Red,
        TextType.Description => ConsoleColor.Yellow,
        TextType.Option => ConsoleColor.Cyan,
        TextType.Normal => ConsoleColor.Gray,
        _ => ConsoleColor.Gray,
    };
}