using Microsoft.Xna.Framework.Graphics;

namespace Systemic;

public static class Drawing
{
    public static void DrawStorage(Systemic game, Storage storage, String title, (int x, int y) offset)
    {
        SpriteBatch spriteBatch = game.SpriteBatch;
        SpriteFont font = game.Fonts["Default"];
        Texture2D backTexture = game.Textures["Border"];

        int tileSize = 64;
        int itemSize = 48;
        int colsMax = 4;
        int rows = storage.MaxCount / colsMax;
        int remainder = storage.MaxCount % colsMax;
        int invWidth = tileSize * colsMax;

        // Title
        var titleLength = font.MeasureString(title).X;
        spriteBatch.Draw(backTexture, 
            new Rectangle(offset.x, offset.y - font.LineSpacing, invWidth, font.LineSpacing), Color.White);
        spriteBatch.DrawString(font, title, 
            new Vector2(offset.x - (titleLength / 2) + (invWidth / 2), offset.y - font.LineSpacing), Color.White);

        // Storage
        for (int y = 0; y < rows + 1; y++)
        {
            int cols = colsMax;
            if (y == rows)
            {
                cols = remainder;
            }
            for (int x = 0; x < cols; x++)
            {
                spriteBatch.Draw(backTexture, 
                    new Rectangle(offset.x + (x * tileSize), offset.y + (y * tileSize), tileSize, tileSize), Color.White);

                var item = storage.GetItem(colsMax * y + x);
                if (item != null)
                {
                    spriteBatch.Draw(item.GetTexture(game.Textures), 
                        new Rectangle((offset.x + 8) + (x * tileSize), (offset.y + 8) + (y * tileSize), itemSize, itemSize), Color.White);
                }
            }
        }
    }
}