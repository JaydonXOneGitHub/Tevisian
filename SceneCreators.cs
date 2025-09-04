using System;
using Microsoft.Xna.Framework;
using Tev.UI;

namespace Tev.Core;

public static class SceneCreators
{
    public static void CreateHomeScreen(UITreeService tree)
    {
        Tevisian.Get().Reset();

        var root = tree.GetRoot();

        root.GetChildren().EnsureCapacity(20);

        {
            var grid = new SelectableGridElement(tree);

            root.DeferredAddChild(grid);
        }
    }
}