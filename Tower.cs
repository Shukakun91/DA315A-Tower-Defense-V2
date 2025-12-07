using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Tower_Defense_V2
{
    public class Tower
    {
        private Point pos;

        public Tower(Point pos)
        {
            this.pos = pos;
        }

        public void Update(float dt)
        {
            //later: state machine, cooldowns, scanning
        }

        public void Draw(SpriteBatch sb)
        {
            //TEMPORARY PLACEHOLDER GRAPHIC
            sb.Draw(AssetLibrary.Pixel, new Rectangle(pos.X - 16, pos.Y - 16, 32, 32), AssetLibrary.ColorBasic);
        }
    }
}