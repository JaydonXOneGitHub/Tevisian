using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;

namespace Tev.Services;

public sealed class TheatreRenderer : TevisianService
{
    private RenderTarget2D? renderTarget;

    public const int TargetWidth = 2560;
    public const int TargetHeight = 1440;

    private Rectangle rectangle;
    private bool resizing = false;



    public RenderTarget2D? GetRenderTarget() => renderTarget;

    public override void Initialize()
    {
        renderTarget = new RenderTarget2D(
            Tevisian.Get()!.GraphicsDevice,
            TargetWidth,
            TargetHeight
        );

        Tevisian.Get()!.Window.ClientSizeChanged += OnResized;

        Resize();
    }

    private void Resize()
    {
        if (!resizing)
        {
            var window = Tevisian.Get()!.Window;

            resizing = true;

            GC.Collect();

            rectangle = new Rectangle(
                0, 0,
                window.ClientBounds.Width,
                window.ClientBounds.Height
            );

            resizing = false;

            GC.Collect();
        }
    }

    private void OnResized(object? obj, EventArgs ea) => Resize();

    public override void Shutdown()
    {
        renderTarget?.Dispose();
        renderTarget = null;
    }

    public override void Draw(GameTime gameTime)
    {
        var batch = Tevisian.Get()!.GetSpriteBatch();

        batch.Begin(sortMode: SpriteSortMode.FrontToBack);

        if (renderTarget != null)
        {
            batch.Draw(
                renderTarget,
                rectangle,
                Color.White
            );
        }

        batch.End();
    }
}