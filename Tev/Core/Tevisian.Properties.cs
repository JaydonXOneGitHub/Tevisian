using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tev.Services;

namespace Tev.Core;

public sealed partial class Tevisian
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private readonly ServiceManager serviceManager;

    private static Tevisian instance;
}