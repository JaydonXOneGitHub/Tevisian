using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Tev.Core;
using Tev.Services;

namespace Tev.UI;

public sealed class SelectableGridElement : UIElement
{
    private readonly List<List<SelectableUIElement>> grid = [];

    private Point selectedPos = Point.Zero;

    private SelectableUIElement selectedElement;

    private readonly NavigatorService navigator;

    public SelectableGridElement(UITreeService tree) : base(tree)
    {
        navigator = Tevisian.Get().GetServiceManager().GetService<NavigatorService>();
    }

    public override void OnAddedToTree()
    {
        navigator.OnNavigationDone += OnNavigationDone;
    }

    public override void OnRemovedFromTree()
    {
        navigator.OnNavigationDone -= OnNavigationDone;
    }

    private void SelectElement()
    {
        selectedElement?.OnNotHovered();

        selectedElement = grid[selectedPos.Y][selectedPos.X];

        selectedElement?.OnHovered();
    }

    private void OnNavigationDone(NavControl control)
    {
        switch (control)
        {
            case NavControl.Left:
                MoveH(left: true);
                break;

            case NavControl.Right:
                MoveH(left: false);
                break;

            case NavControl.Up:
                MoveV(down: false);
                break;

            case NavControl.Down:
                MoveV(down: true);
                break;

            case NavControl.Select:
                selectedElement?.OnSelected();
                break;

            default:
                break;
        }
    }

    private void MoveV(bool down)
    {
        int i = down ? 1 : -1;

        selectedPos.Y = (
            (selectedPos.Y + i) %
            grid.Count
        );

        if (selectedPos.X > (grid[selectedPos.Y].Count - 1))
        {
            selectedPos.X = grid[selectedPos.Y].Count - 1;
        }

        SelectElement();
    }

    private void MoveH(bool left)
    {
        int i = left ? -1 : 1;

        selectedPos.X = (
            (selectedPos.X + i) %
            grid[selectedPos.Y].Count
        );

        SelectElement();
    }

    public void AddRow()
    {
        grid.Add([]);
    }

    public void RemoveRow()
    {
        grid.RemoveAt(grid.Count - 1);
    }

    public List<SelectableUIElement> GetRow(int row)
    {
        return grid[row];
    }

    public void AddSelectable(
        SelectableUIElement sui,
        int row)
    {
        grid[row].Add(sui);
        DeferredAddChild(sui);
    }

    public void RemoveSelectable(int row, int column)
    {
        DeferredRemoveChild(grid[row][column]);
        grid[row].RemoveAt(column);
    }

    public Point GetSelectedPos() => selectedPos;

    public SelectableUIElement GetSelectedElement()
    {
        // Access selectedElement to avoid unused field warning
        return selectedElement;
    }
}