using System;
using System.IO;
using Microsoft.Xna.Framework;
using Tev.UI;

namespace Tev.Core;

public static class SceneCreators
{
    public static void CreateHomeScreen(UITreeService tree)
    {
        InternalCreateHomeScreen(tree);
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            Console.WriteLine(e.Source);
            Console.WriteLine(e.Message);
        }

        GC.Collect();
    }

    private static void InternalCreateHomeScreen(UITreeService tree)
    {
        Tevisian.Get()!.Content.Unload();
        GC.Collect();

        var root = tree.GetRoot();

        root.GetChildren().EnsureCapacity(20);

        {
            var apm = Tevisian.Get()!.GetAppManifests();

            int rows = apm!.Values.Count / Tevisian.MaxColumns;
            int leftover = apm!.Values.Count % Tevisian.MaxColumns;
            int totalRows = rows + (leftover > 0 ? 1 : 0);

            Console.WriteLine($"Total rows: {totalRows}");

            var grid = new SelectableGridElement(
                tree,
                totalRows,
                Tevisian.MaxColumns
            );

            root.DeferredAddChild(grid);

            int row = 0;
            int col = 0;

            grid.Offset = new(-250, 100);

            Point offsetAmount = new(400, 300);

            foreach (var pair in apm!)
            {
                Console.WriteLine("Starting iteration!");

                string imgPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    Tevisian.AppFolder,
                    pair.Value!.AppFolder!,
                    pair.Value!.AppIconPath!
                );

                Console.WriteLine(imgPath);

                var sai = new SelectableAppIcon(
                    imgPath,
                    pair.Value!.Name!,
                    pair.Key,
                    tree
                );

                sai.Text!.Scale = 0.175f;

                sai.Img!.LayerDepth = 70;
                sai.Text!.LayerDepth = 65;

                sai.LayerDepth = 15;

                sai.ScaleOffset = 1.25f;

                grid.AddSelectable(sai);

                Console.WriteLine($"Col: {col}");
                Console.WriteLine($"Row: {row}");

                if (col >= Tevisian.MaxColumns)
                {
                    col = 0;
                    row++;
                }

                col++;

                sai.Offset = new Vector2(
                    offsetAmount.X * col,
                    offsetAmount.Y * row
                );
            }

            if (grid.GetGrid().Count > 0)
            {
                grid.Select(0);
            }
            else
            {
                // Select the default element
                var notice = new TextElement(tree);

                notice.Text = "No apps installed...";

                notice.Offset = offsetAmount.ToVector2();

                grid.DeferredAddChild(notice);
            }
        }
    }
}