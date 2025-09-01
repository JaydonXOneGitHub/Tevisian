using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tev.Services;

public sealed class InputService : TevisianService
{
    private KeyboardState currKeyState;
    private KeyboardState prevKeyState;


    private GamePadState currGamePadState;
    private GamePadState prevGamePadState;



    public event Action<Keys> OnKeyPressed;
    public event Action<Buttons> OnGamePadButtonPressed;



    public override void Update(GameTime gameTime)
    {
        prevGamePadState = currGamePadState;
        prevKeyState = currKeyState;

        currKeyState = Keyboard.GetState();
        currGamePadState = GamePad.GetState(PlayerIndex.One);

        CheckKeysForJustPress();
        CheckButtonsForJustPress();
    }

    private void CheckKeysForJustPress()
    {
        CheckKeyForJustPress(Keys.Left);
        CheckKeyForJustPress(Keys.Right);
        CheckKeyForJustPress(Keys.Down);
        CheckKeyForJustPress(Keys.Up);
        CheckKeyForJustPress(Keys.Enter);
        CheckKeyForJustPress(Keys.Back);
    }

    private void CheckKeyForJustPress(Keys key)
    {
        if (prevKeyState.IsKeyUp(key) && currKeyState.IsKeyDown(key))
        {
            OnKeyPressed?.Invoke(key);
        }
    }

    private void CheckButtonsForJustPress()
    {
        CheckButtonForJustPress(Buttons.LeftThumbstickLeft);
        CheckButtonForJustPress(Buttons.DPadLeft);
        CheckButtonForJustPress(Buttons.LeftThumbstickRight);
        CheckButtonForJustPress(Buttons.DPadRight);
        CheckButtonForJustPress(Buttons.LeftThumbstickUp);
        CheckButtonForJustPress(Buttons.DPadUp);
        CheckButtonForJustPress(Buttons.LeftThumbstickDown);
        CheckButtonForJustPress(Buttons.DPadDown);
    }

    private void CheckButtonForJustPress(Buttons button)
    {
        if (prevGamePadState.IsButtonUp(button) && currGamePadState.IsButtonDown(button))
        {
            OnGamePadButtonPressed?.Invoke(button);
        }
    }
}