using System;
using System.Collections.Generic;
using Systemic.Items;

namespace Systemic;

public class Storage
{
    private int _maxCount;

    public List<Item> Items { get; set; } = new();

    public int MaxCount
    {
        get => _maxCount;
        set => _maxCount = value;
    }

    public Storage(int size)
    {
        _maxCount = size;
    }
}
