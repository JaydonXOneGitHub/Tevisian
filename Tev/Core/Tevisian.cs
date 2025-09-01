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

        serviceManager = new ServiceManager();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Tevisian instance already made!");
        }

#if LINUX
#else
        Window.AllowAltF4 = false;
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

        serviceManager.Initialize();

#if LINUX
        // Add Linux fullscreen code


#endif

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void UnloadContent()
    {
        serviceManager.Shutdown();
        base.UnloadContent();
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    public static Tevisian Get() { return instance; }

    public ServiceManager GetServiceManager() => serviceManager;

    public SpriteBatch GetSpriteBatch() => _spriteBatch;
}
