using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks.Dataflow;
using Systemic.Items;

namespace Systemic;

public static class Updating
{
    public static void HandleInputs(Systemic game)
    {
        // Keyboard
        KeyboardState keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Escape))
        {
            game.Exit();
        }

        InputAction action = InputAction.ToggleFullscreen;
        if (!game.ActionIsLocked[action])
        {
            if (keyboard.IsKeyDown(Keys.LeftAlt) && keyboard.IsKeyDown(Keys.Enter))
            {
                game.Graphics.ToggleFullScreen();

                game.ActionIsLocked[action] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.LeftAlt) || keyboard.IsKeyUp(Keys.Enter))
            {
                game.ActionIsLocked[action] = false;
            }
        }

        action = InputAction.Debug1;
        if (!game.ActionIsLocked[action])
        {
            if (keyboard.IsKeyDown(Keys.Space))
            {
                game.Player.Storage.AddItem(new Wood());

                game.ActionIsLocked[action] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.Space))
            {
                game.ActionIsLocked[action] = false;
            }
        }

        // Mouse
        MouseState mouse = Mouse.GetState();

        action = InputAction.Click;
        if (!game.ActionIsLocked[action])
        {
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < game.Player.Storage.MaxCount; i++)
                {
                    Rectangle button = game.Player.Storage.Buttons[i];

                    if (button.Contains(mouse.Position))
                    {
                        game.Player.Storage.RemoveItem(i);
                    }
                }

                game.ActionIsLocked[action] = true;
            }
        }
        else
        {
            if (mouse.LeftButton == ButtonState.Released)
            {
                game.ActionIsLocked[action] = false;
            }
        }
    }
}