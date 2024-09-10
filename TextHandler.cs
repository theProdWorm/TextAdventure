namespace TextAdventure;

public static class TextHandler
{
    private static readonly int TextDelay = 45;

    public enum TextType
    {
        Good,
        Bad,
        Description,
        Option,
        Normal
    }

    public static void PrettyWrite(string output, TextType type = TextType.Normal, bool isLastLine = false)
    {
        var color = GetColor(type);
        Console.ForegroundColor = color;
        
        if(type == TextType.Option)
            Console.Write('\t');
        
        foreach (var letter in output)
        {
            Console.Write(letter);
            Thread.Sleep(TextDelay);
        }
        
        Console.ForegroundColor = ConsoleColor.White;
        
        if(isLastLine)
            Console.WriteLine(">");
    }

    private static ConsoleColor GetColor(TextType type) => type switch {
        
        TextType.Good => ConsoleColor.Green,
        TextType.Bad => ConsoleColor.Red,
        TextType.Description => ConsoleColor.Yellow,
        TextType.Option => ConsoleColor.Cyan,
        TextType.Normal => ConsoleColor.White,
        _ => ConsoleColor.White,
    };
}