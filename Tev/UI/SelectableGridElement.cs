using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Tev.Core;
using Tev.Services;

namespace Tev.UI;

public sealed class SelectableGridElement : UIElement
{
    private readonly List<SelectableUIElement?> grid;
    private readonly int rowCount;
    private readonly int iconCount;

    private int selectedIndex;

    private SelectableUIElement? selectedElement;

    private readonly NavigatorService? navigator;

    public SelectableGridElement(
        UITreeService tree,
        int rowCount,
        int iconCount
    ) : base(tree)
    {
        grid = [];

        this.rowCount = rowCount;
        this.iconCount = iconCount;

        navigator = Tevisian.Get()!
            .GetServiceManager()
            .GetService<NavigatorService>();
    }

    public override void OnAddedToTree()
    {
        navigator!.OnNavigationDone += OnNavigationDone;
    }

    public override void OnRemovedFromTree()
    {
        navigator!.OnNavigationDone -= OnNavigationDone;
    }

    public void Select(int selectedIndex)
    {
        this.selectedIndex = selectedIndex;

        SelectElement();
    }

    private void SelectElement()
    {
        Console.WriteLine(selectedIndex.ToString());
        
        selectedElement?.OnNotHovered();

        selectedElement = grid[selectedIndex];

        selectedElement?.OnHovered();
    }

    private void OnNavigationDone(NavControl control)
    {
        if (!(Tevisian.Get()!.IsActive))
        {
            return;
        }
        
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
        int temp = selectedIndex;

        int i = down ? Tevisian.MaxColumns : -Tevisian.MaxColumns;

        selectedIndex += i;

        if (!down && selectedIndex < 0)
        {
            selectedIndex = temp;
            return;
        }

        if (down && selectedIndex >= grid.Count)
        {
            selectedIndex = temp;
            return;
        }

        selectedIndex = Math.Clamp(
            selectedIndex,
            0,
            grid.Count - 1
        );

        SelectElement();
    }

    private void MoveH(bool left)
    {
        int i = left ? -1 : 1;

        selectedIndex += i;

        selectedIndex = Math.Clamp(
            selectedIndex,
            0,
            grid.Count - 1
        );

        SelectElement();
    }

    public void AddSelectable(SelectableUIElement sui)
    {
        grid.Add(sui);
        DeferredAddChild(sui);

        Console.WriteLine(grid.Count);
    }

    public void RemoveSelectable(int selectedIndex)
    {
        DeferredRemoveChild(grid[selectedIndex]!);
        grid.RemoveAt(selectedIndex);
    }

    public int GetSelectedIndex() => selectedIndex;

    public List<SelectableUIElement?> GetGrid() => grid;

    public SelectableUIElement? GetSelectedElement()
    {
        // Access selectedElement to avoid unused field warning
        return selectedElement;
    }
}