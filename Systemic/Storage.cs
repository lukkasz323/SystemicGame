using System;
using System.Collections.Generic;
using Systemic.Items;

namespace Systemic;

public class Storage
{
    private List<Item> _items;
    private int _maxCount;

    public int MaxCount
    {
        get => _maxCount;
        set => _maxCount = Math.Clamp(value, 4, 32);
    }

    public Item GetItem(int index) => _items[index];

    public void AddItem(Item item)
    {
        for (int i = 0; i < MaxCount; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                break;
            }
        }
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
    }
}
