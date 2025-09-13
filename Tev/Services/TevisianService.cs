using Microsoft.Xna.Framework;

namespace Tev.Services;

public abstract class TevisianService
{
    public virtual void Initialize() { }
    public virtual void Shutdown() { }

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime) { }

    public virtual void Reset() {}
}