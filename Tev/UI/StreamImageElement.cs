using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;

namespace Tev.UI;

public sealed class StreamImageElement : UIElement
{
    private Texture2D? texture;

    public Color Color { get; set; } = Color.White;

    public Vector2 Scale { get; set; } = Vector2.One;

    public float Rotation { get; set; } = 0;

    public SpriteEffects Effects = SpriteEffects.None;



    public StreamImageElement(string imgPath, UITreeService tree)
        : base(tree)
    {
        using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
        {
            texture = Texture2D.FromStream(
                Tevisian.Get()!.GraphicsDevice,
                fs
            );
        }
    }

    public Texture2D? GetTexture() => texture;

    protected override void InternalDraw(GameTime gameTime)
    {
        // if (texture == null)
        // {
        //     return;
        // }

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

    public override void OnRemovedFromTree()
    {
        texture?.Dispose();
        texture = null;
    }
}