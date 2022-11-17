global using System;
global using System.Collections.Generic;
global using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Systemic;

public class Systemic : Game
{
    public GraphicsDeviceManager Graphics { get; private set; }
    public SpriteBatch SpriteBatch { get; private set; }
    public Dictionary<InputAction, bool> ActionIsLocked = new();
    public Dictionary<string, SpriteFont> Fonts = new();
    public Dictionary<string, Texture2D> Textures = new();
    public Player Player { get; } = new();

    public Systemic()
    {
        Graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Graphics.HardwareModeSwitch = false;
        Graphics.ApplyChanges();

        // Locked input actions
        foreach (InputAction action in Enum.GetValues(typeof(InputAction)))
        {
            ActionIsLocked[action] = false;
        }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);

        // TODO: use this.Content to load your game content
        var fontFilenames = new List<string>()
        {
            "Default"
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
        Updating.HandleInputs(this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        SpriteBatch.Begin();

        Drawing.DrawStorage(this, Player.Storage);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
