using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Systemic.Items;

namespace Systemic;

public class Storage
{
    private List<Item> _items;
    private int _maxCount;

    public List<Rectangle> Buttons { get; private set; }
    public string Title { get; } 
    public (int x, int y) Position { get; } 

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

    public Storage(int size, string title, (int x, int y) position)
    {
        MaxCount = size;
        Title = title;
        Position = position;

        _items = new(MaxCount);
        for (int i = 0; i < MaxCount; i++)
        {
            _items.Add(null);
        }

        Buttons = new(MaxCount);
        int tileSize = 64;
        int colsMax = 4;
        int rows = MaxCount / colsMax;
        int remainder = MaxCount % colsMax;
        for (int y = 0; y < rows + 1; y++)
        {
            int cols = colsMax;
            if (y == rows)
            {
                cols = remainder;
            }
            for (int x = 0; x < cols; x++)
            {
                Buttons.Add(new Rectangle(Position.x + (x * tileSize), Position.y + (y * tileSize), tileSize, tileSize));
            }
        }
    }
}
