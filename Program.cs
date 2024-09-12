using TextAdventure;
using TextAdventure.Characters;

TextHandler.PrettyWrite("What's your name?", TextHandler.TextType.Description, true);
string playerName = Console.ReadLine()!;
if (String.IsNullOrEmpty(playerName))
    playerName = "Player";


Game game = new Game(playerName, 3, 3);
game.Loop();