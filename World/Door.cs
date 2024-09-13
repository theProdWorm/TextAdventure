using TextAdventure.Characters;
using TextAdventure.Items.Items;
using TextAdventure.States;

namespace TextAdventure.World;

public class Door
{
    private readonly Room _roomBehindDoor;
    private readonly Action<Room> _enter;
    private readonly bool _isLocked;

    public Door(Room roomBehindDoor, Action<Room> enter, bool isLocked = false)
    {
        _roomBehindDoor = roomBehindDoor;
        _enter = enter;
        _isLocked = isLocked;
    }

    public bool TryEnter(Player player)
    {
        if (!_isLocked)
        {
            _enter(_roomBehindDoor);
            return true;
        }

        // TODO: Check for key

        int keyIndex = -1;
        for (int i = 0; i < player.Inventory.Length; i++)
        {
            var item = player.Inventory[i];
            if (item == null)
                continue;

            if (item.Type == Item.ItemType.Key)
            {
                keyIndex = i;
            }
        }
        
        if(keyIndex < 0)
            return false;

        player.Inventory[keyIndex] = null;
        TextHandler.PrettyWrite($"{player.Name} used a key to enter a locked room!\n");

        _enter(_roomBehindDoor);

        return true;
    }

    public new string ToString()
    {
        return _roomBehindDoor.ToString();
    }
}