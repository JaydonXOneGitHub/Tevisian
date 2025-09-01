using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;
using Tev.Services;

namespace Tev.UI;

public sealed class UITreeService : TevisianService
{
    private readonly UIElement root;

    private TheatreRenderer theatre;

    public UITreeService()
    {
        root = new UIElement(this);
    }
    

    public UIElement GetRoot() => root;


    public override void Initialize()
    {
        theatre = Tevisian.Get().GetServiceManager().GetService<TheatreRenderer>();
    }

    public override void Draw(GameTime gameTime)
    {
        var batch = Tevisian.Get().GetSpriteBatch();

        Tevisian.Get().GraphicsDevice.SetRenderTarget(
            theatre.GetRenderTarget()
        );

        batch.Begin(sortMode: SpriteSortMode.FrontToBack);

        root.Draw(gameTime);

        batch.End();

        Tevisian.Get().GraphicsDevice.SetRenderTarget(null);
    }

    public override void Update(GameTime gameTime)
    {
        root.Draw(gameTime);
    }
}