using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using Systemic.Items;

namespace Systemic;

public class Systemic : Game
{
    private GraphicsDeviceManager _graphics;

    public SpriteBatch SpriteBatch { get; private set; }
    public Dictionary<string, SpriteFont> Fonts { get; private set; }
    public Dictionary<string, Texture2D> Textures { get; private set; }


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
        Fonts = new();
        Textures = new();

        _graphics.HardwareModeSwitch = false;
        //_graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        Player.Inventory.Items.Add(new Wood());

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);

        // TODO: use this.Content to load your game content
        var fontFilenames = new List<string>()
        {
            "DefaultFont"
        };
        var textureFilenames = new List<string>()
        {
            "Default",
            "Border",
            "Wood"
        };

        foreach (string font in fontFilenames)
        {
            Fonts.Add(font, Content.Load<SpriteFont>($"Fonts/{font}"));
        }
        foreach (string texture in textureFilenames)
        {
            Textures.Add(texture, Content.Load<Texture2D>($"Textures/{texture}"));
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
        SpriteBatch.Begin();

        Render.Inventory(this, Player.Inventory);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}