using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Systemic;

public class Systemic : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Dictionary<string, SpriteFont> _fonts;
    private Dictionary<string, Texture2D> _textures;

    public Player Player { get; } = new();

    public Systemic()
    {
        _graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _fonts = new();
        _textures = new();

        _graphics.HardwareModeSwitch = false;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content
        var fontFilenames = new List<string>()
        {
            "font"
        };
        var textureFilenames = new List<string>()
        {
            "border"
        };

        foreach (string font in fontFilenames)
        {
            _fonts.Add(font, Content.Load<SpriteFont>($"Fonts/{font}"));
        }
        foreach (string texture in textureFilenames)
        {
            _textures.Add(texture, Content.Load<Texture2D>($"Textures/{texture}"));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        // Draw inventory
        SpriteFont font = _fonts["font"];
        Texture2D texture = _textures["border"];
        string title = "Inventory";
        var titleLength = font.MeasureString(title).X;
        int tileSize = 64;
        int cols = 4;
        int rows = 8;
        int invWidth = tileSize * cols;
        var offset = (x: 32, y: 32);
        
        _spriteBatch.Draw(texture, new Rectangle(offset.x, offset.y - font.LineSpacing, invWidth, font.LineSpacing), Color.White);
        _spriteBatch.DrawString(font, title, new Vector2(offset.x - (titleLength / 2) + (invWidth / 2), offset.y - font.LineSpacing), Color.White);
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                _spriteBatch.Draw(texture, new Rectangle(offset.x + x * tileSize, offset.y + y * tileSize, tileSize, tileSize), Color.White);
            }
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}