using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;

namespace Tev.UI;

public sealed class ImageElement : UIElement
{
    private readonly Texture2D texture;

    public Color Color { get; set; } = Color.White;

    public Vector2 Scale { get; set; }

    public float Rotation { get; set; } = 0;

    public SpriteEffects Effects = SpriteEffects.None;



    public ImageElement(string imgPath, UITreeService tree)
        : base(tree)
    {
        texture = Tevisian.Get()!.Content.Load<Texture2D>(imgPath);
    }

    public Texture2D GetTexture() => texture;

    protected override void InternalDraw(GameTime gameTime)
    {
        Tevisian.Get()!.GetSpriteBatch().Draw(
            texture: texture,
            sourceRectangle: null,
            position: GlobalOffset,
            scale: Scale,
            rotation: Rotation,
            color: Color,
            origin: Vector2.Zero,
            effects: Effects,
            layerDepth: internalLayerDepth
        );
    }
}