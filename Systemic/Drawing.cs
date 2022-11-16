using Microsoft.Xna.Framework.Graphics;

namespace Systemic;

public static class Drawing
{
    public static void DrawInventory(Systemic game)
    {
        SpriteBatch spriteBatch = game.SpriteBatch;
        Storage storage = game.Player.Storage;
        SpriteFont font = game.Fonts["Default"];
        Texture2D backTexture = game.Textures["Border"];
        

        string title = "Inventory";
        var titleLength = font.MeasureString(title).X;
        int tileSize = 64;
        int itemSize = 48;
        int cols = 4;
        int rows = storage.MaxCount / cols;
        int remainder = storage.MaxCount % cols;
        int invWidth = tileSize * cols;
        var offset = (x: 32, y: 32);

        // Title
        spriteBatch.Draw(backTexture, new Rectangle(offset.x, offset.y - font.LineSpacing, invWidth, font.LineSpacing), Color.White);
        spriteBatch.DrawString(font, title, new Vector2(offset.x - (titleLength / 2) + (invWidth / 2), offset.y - font.LineSpacing), Color.White);

        // Storage
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                spriteBatch.Draw(backTexture, new Rectangle(offset.x + (x * tileSize), offset.y + (y * tileSize), tileSize, tileSize), Color.White);

                var item = storage.GetItem(cols * y + x);
                if (item != null)
                {
                    spriteBatch.Draw(item.GetTexture(game.Textures), new Rectangle((offset.x + 8) + (x * tileSize), (offset.y + 8) + (y * tileSize), itemSize, itemSize), Color.White);
                }
            }
        }
        for (int x = 0; x < remainder; x++)
        {
            spriteBatch.Draw(backTexture, new Rectangle(offset.x + x * tileSize, offset.y + (rows * tileSize), tileSize, tileSize), Color.White);
        }
    }
}
