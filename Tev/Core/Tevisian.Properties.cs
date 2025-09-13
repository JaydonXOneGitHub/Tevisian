using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Tev.Services;

namespace Tev.Core;

public sealed partial class Tevisian
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch? _spriteBatch;

    private readonly ServiceManager serviceManager;

    private static Tevisian? instance;

    private readonly Dictionary<string, AppManifest?>? appManifests;

    public const string AppFolder = "LocalApps";

    public const int MaxColumns = 3;
}