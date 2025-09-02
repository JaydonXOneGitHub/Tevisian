using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;

namespace Tev.UI;

public sealed class ImageElement : UIElement
{
    private readonly Texture2D texture;

    public Color Color { get; set; } = Color.White;

    public ImageElement(string imgPath, UITreeService tree)
        : base(tree)
    {
        texture = Tevisian.Get().Content.Load<Texture2D>(imgPath);
    }

    public Texture2D GetTexture() => texture;

    protected override void InternalDraw(GameTime gameTime)
    {
        Tevisian.Get().GetSpriteBatch().Draw(
            texture,
            GlobalOffset,
            Color
        );
    }
}