using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;
using Tev.Services;

namespace Tev.UI;

public sealed class SelectableAppIcon : SelectableUIElement
{
    private readonly StreamImageElement img;
    private readonly TextElement text;

    public float ScaleOffset = 1.2f;

    private readonly Vector2 posOffset = new Vector2(35, 18);

    private Color color;

    private readonly Texture2D selectionTexture;

    public StreamImageElement? Img => img;
    public TextElement Text => text;

    private readonly string designatedAppName;

    private const int maxStringLength = 18;

    public SelectableAppIcon(
        string imgPath, string displayText, string appName,
        UITreeService tree) : base(tree)
    {
        string finalText = displayText;

        if (finalText.Length > maxStringLength)
        {
            string initContents = finalText.Substring(0, maxStringLength - 3);

            finalText = initContents + "...";
        }

        img = new StreamImageElement(imgPath, tree);
        text = new TextElement(tree)
        {
            Text = finalText
        };

        img.Offset = Vector2.Zero;
        text.Offset = Vector2.UnitY * 210;

        designatedAppName = appName;

        selectionTexture = Tevisian.Get()!.Content.Load<Texture2D>(
            "Images/TevisianSelector"
        );

        DeferredAddChild(text);
        DeferredAddChild(img);
    }

    public override void OnSelected()
    {
        var tv = Tevisian.Get();

        var ps = tv!.GetServiceManager().GetService<ProcessService>();

        if (ps == null)
        {
            return;
        }

        var am = tv!.GetAppManifests()![designatedAppName]!;

        string appPath = am.AppPath!;

        string fullAppPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "LocalApps",
            am.AppFolder!,
            appPath
        );

        string workDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "LocalApps",
            am.AppFolder!
        );

        var processInfo = new ProcessStartInfo
        {
            WorkingDirectory = workDir,
            FileName = fullAppPath
        };

        ps.StartProcess(processInfo);
    }

    protected override void InternalDraw(GameTime gameTime)
    {
        Tevisian.Get()!.GetSpriteBatch().Draw(
            texture: selectionTexture,
            position: GlobalOffset - posOffset * ScaleOffset,
            color: color,
            scale: Vector2.One * ScaleOffset,
            effects: SpriteEffects.None,
            rotation: 0,
            origin: Vector2.Zero,
            sourceRectangle: null,
            layerDepth: internalLayerDepth
        );
    }

    public override void OnHovered()
    {
        color = new Color(255, 255, 255, 1);
    }

    public override void OnNotHovered()
    {
        color = Color.Transparent;
    }
}
