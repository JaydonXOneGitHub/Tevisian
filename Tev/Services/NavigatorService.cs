using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Tev.Core;
using Tev.UI;

namespace Tev.Services;

public enum NavControl
{
    Left,
    Right,
    Up,
    Down,
    Select,
    Back,
    Submenu,
}

public sealed class NavigatorService : TevisianService
{
    private InputService inputService;

    public event Action<NavControl> OnNavigationDone;

    public override void Initialize()
    {
        inputService = Tevisian.Get()
            .GetServiceManager()
            .GetService<InputService>();

        inputService.OnKeyPressed += OnKeyPressed;
        inputService.OnGamePadButtonPressed += OnButtonPressed;
    }

    private void OnButtonPressed(Buttons buttons)
    {
        switch (buttons)
        {
            case Buttons.DPadLeft:
            case Buttons.LeftThumbstickLeft:
                OnNavigationDone?.Invoke(NavControl.Left);
                break;
            case Buttons.DPadRight:
            case Buttons.LeftThumbstickRight:
                OnNavigationDone?.Invoke(NavControl.Right);
                break;
            case Buttons.DPadUp:
            case Buttons.LeftThumbstickUp:
                OnNavigationDone?.Invoke(NavControl.Up);
                break;
            case Buttons.DPadDown:
            case Buttons.LeftThumbstickDown:
                OnNavigationDone?.Invoke(NavControl.Down);
                break;
            case Buttons.A:
                OnNavigationDone?.Invoke(NavControl.Select);
                break;
            case Buttons.B:
                OnNavigationDone?.Invoke(NavControl.Back);
                break;
            case Buttons.Start:
                OnNavigationDone?.Invoke(NavControl.Submenu);
                break;
            default:
                break;
        }
    }

    private void OnKeyPressed(Keys keys)
    {
        switch (keys)
        {
            case Keys.Left:
                OnNavigationDone?.Invoke(NavControl.Left);
                break;
            case Keys.Right:
                OnNavigationDone?.Invoke(NavControl.Right);
                break;
            case Keys.Up:
                OnNavigationDone?.Invoke(NavControl.Up);
                break;
            case Keys.Down:
                OnNavigationDone?.Invoke(NavControl.Down);
                break;
            case Keys.Enter:
                OnNavigationDone?.Invoke(NavControl.Select);
                break;
            case Keys.Escape:
                OnNavigationDone?.Invoke(NavControl.Back);
                break;
            default:
                break;
        }
    }
}