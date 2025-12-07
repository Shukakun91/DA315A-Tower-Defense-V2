using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Tower_Defense_V2.Managers
{
    public interface IManager
    {
        void Update(float dt);
        void Draw(SpriteBatch sb);
    }
}