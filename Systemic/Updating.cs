using Microsoft.Xna.Framework.Input;
using Systemic.Items;

namespace Systemic;

public static class Updating
{
    public static void HandleInputs(Systemic game)
    {
        // Keyboard
        KeyboardState keyboard = Keyboard.GetState();

        
        if (keyboard.IsKeyDown(Keys.Escape))
            game.Exit();

        if (!game.ActionIsLocked[InputAction.ToggleFullscreen])
        {
            if (keyboard.IsKeyDown(Keys.LeftAlt) && keyboard.IsKeyDown(Keys.Enter))
            {
                game.Graphics.ToggleFullScreen();

                game.ActionIsLocked[InputAction.ToggleFullscreen] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.LeftAlt) && keyboard.IsKeyUp(Keys.Enter))
            {
                game.ActionIsLocked[InputAction.ToggleFullscreen] = false;
            }
        }

        if (!game.ActionIsLocked[InputAction.Debug1])
        {
            if (keyboard.IsKeyDown(Keys.Space))
            {
                game.Player.Storage.AddItem(new Wood());

                game.ActionIsLocked[InputAction.Debug1] = true;
            }
        }
        else
        {
            if (keyboard.IsKeyUp(Keys.Space))
            {
                game.ActionIsLocked[InputAction.Debug1] = false;
            }
        }

        // Mouse
        MouseState mouse = Mouse.GetState();

        for (int i = 0; i < game.Player.Storage.MaxCount; i++)
        {
            Rectangle button = game.Player.Storage.Buttons[i];

            if (mouse.LeftButton == ButtonState.Pressed && button.Contains(mouse.Position))
            {
                game.Player.Storage.RemoveItem(i);
            }
        }
    }
}