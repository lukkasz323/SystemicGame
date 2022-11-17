using Microsoft.Xna.Framework.Graphics;
using Systemic.Items;

namespace Systemic;

public static class Drawing
{
    public static void DrawStorage(Systemic game, Storage storage)
    {
        SpriteBatch spriteBatch = game.SpriteBatch;
        SpriteFont font = game.Fonts["Default"];
        Texture2D backTexture = game.Textures["Border"];

        int tileSize = 64;
        int colsMax = 4;
        int invWidth = tileSize * colsMax;

        // Title
        var titleLength = font.MeasureString(storage.Title).X;
        spriteBatch.Draw(backTexture, 
            new Rectangle(storage.Position.x, storage.Position.y - font.LineSpacing, invWidth, font.LineSpacing), Color.White);
        spriteBatch.DrawString(font, storage.Title, 
            new Vector2(storage.Position.x - (titleLength / 2) + (invWidth / 2), storage.Position.y - font.LineSpacing), Color.White);

        for (int i = 0; i < storage.MaxCount; i++)
        {
            Rectangle button = storage.Buttons[i];
            Item item = storage.GetItem(i);

            spriteBatch.Draw(backTexture, button, Color.White);
            if (item != null)
            {
                spriteBatch.Draw(item.GetTexture(game.Textures), 
                    new Rectangle(button.X + 8, button.Y + 8, button.Width - 16, button.Height - 16), Color.White);
            }
        }
    }
}