using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tev.Core;

namespace Tev.UI;

public sealed class TextElement : UIElement
{
    private readonly SpriteFont font;

    public string Text { get; set; } = "LOREMIPSUM";

    public Color Color { get; set; } = Color.White;

    public float Rotation { get; set; } = 0;
    public float Scale { get; set; } = 0.25f;

    public SpriteEffects Effects = SpriteEffects.None;


    public TextElement(UITreeService tree) : base(tree)
    {
        font = Tevisian.Get()!.Content.Load<SpriteFont>("Fonts/Default");
    }

    protected override void InternalDraw(GameTime gameTime)
    {
        Tevisian.Get()!.GetSpriteBatch().DrawString(
            font, Text, GlobalOffset,
            Color, Rotation,
            Vector2.Zero, Scale,
            Effects, internalLayerDepth
        );
    }
}