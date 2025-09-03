using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Tev.Core;
using Tev.Services;

namespace Tev.UI;

public sealed class SelectableGridElement : UIElement
{
    private readonly List<List<SelectableUIElement>> grid = [];

    private Point selectedPos;

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
                selectedPos.X = (
                    (selectedPos.X - 1) %
                    grid[selectedPos.Y].Count
                );
                SelectElement();
                break;
            case NavControl.Right:
                selectedPos.X = (
                    (selectedPos.X + 1) %
                    grid[selectedPos.Y].Count
                );
                SelectElement();
                break;
        }
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
}