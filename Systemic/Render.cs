﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systemic;

public static class Render
{
    public static void Inventory(Systemic game, Storage storage)
    {
        SpriteBatch spriteBatch = game.SpriteBatch;
        SpriteFont font = game.Fonts["DefaultFont"];
        Texture2D backTexture = game.Textures["Border"];

        string title = "Inventory";
        var titleLength = font.MeasureString(title).X;
        int tileSize = 64;
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
                spriteBatch.Draw(backTexture, new Rectangle(offset.x + x * tileSize, offset.y + (y * tileSize), tileSize, tileSize), Color.White);
                spriteBatch.Draw(storage.Items[0].GetTexture(game.Textures), new Rectangle(offset.x + x * tileSize, offset.y + (y * tileSize), tileSize, tileSize), Color.White);
            }
        }
        for (int x = 0; x < remainder; x++)
        {
            spriteBatch.Draw(backTexture, new Rectangle(offset.x + x * tileSize, offset.y + (rows * tileSize), tileSize, tileSize), Color.White);
        }
    }
}