using Systemic.Items;

namespace Systemic;

public class Storage
{
    private List<Item> _items;
    private int _maxCount;

    public List<Rectangle> Buttons { get; private set; }

    public int MaxCount
    {
        get => _maxCount;
        set => _maxCount = Math.Clamp(value, 4, 64);
    }

    public Item GetItem(int index) => _items[index];

    public bool AddItem(Item item)
    {
        for (int i = 0; i < MaxCount; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int index) => _items[index] = null;

    public Storage(int size)
    {
        MaxCount = size;

        _items = new(MaxCount);
        for (int i = 0; i < MaxCount; i++)
        {
            _items.Add(null);
        }

        Buttons = new(MaxCount);
        for (int i = 0; i < MaxCount; i++)
        {
            Buttons.Add(new Rectangle());
        }
    }
}
