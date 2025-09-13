using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tev.Services;

namespace Tev.Core;

public sealed partial class Tevisian : Game
{
    public Tevisian()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.Title = "Tevisian";

        serviceManager = new ServiceManager();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Tevisian instance already made!");
        }

        Window.AllowAltF4 = false;

        appManifests = AppRegistrar.Search(AppFolder);

#if LINUX
#else
        Window.AllowUserResizing = true;
#endif
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Add Linux fullscreen code
        _graphics.PreferredBackBufferHeight =
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        _graphics.PreferredBackBufferWidth =
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        _graphics.IsFullScreen = true;

        _graphics.ApplyChanges();

        serviceManager.Initialize();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        serviceManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void UnloadContent()
    {
        serviceManager.Shutdown();
        base.UnloadContent();
    }


    protected override void Draw(GameTime gameTime)
    {
        serviceManager.Draw(gameTime);

        base.Draw(gameTime);
    }

    public static Tevisian? Get() { return instance; }

    public ServiceManager GetServiceManager() => serviceManager;

    public SpriteBatch GetSpriteBatch() => _spriteBatch!;

    public Dictionary<string, AppManifest?>? GetAppManifests() => appManifests;

    public void Reset()
    {
        Content.Unload();
        GC.Collect();
    }
}
