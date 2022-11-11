using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Systemic.Items;

public abstract class Item
{
    public string Name { get; }

    public Texture2D GetTexture(Dictionary<string, Texture2D> textures) => textures[Name];

    public Item()
    {
        Name = this.GetType().Name;
    }
}
