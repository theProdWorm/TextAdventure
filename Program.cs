using TextAdventure;
using TextAdventure.Characters;

TextHandler.PrettyWrite("What's your name?", TextHandler.TextType.Description, true);
string playerName = Console.ReadLine();
if (String.IsNullOrEmpty(playerName))
    playerName = "Player";

Player player = new(playerName, 10);

Game game = new Game(player);
game.Loop();