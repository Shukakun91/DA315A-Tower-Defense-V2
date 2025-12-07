using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Tower_Defense_V2
{
    public class DisplayBox
    {
        GraphicsDevice gd;
        RenderTarget2D target;

        Rectangle destRec;

        int width;
        int height;

        public DisplayBox(GraphicsDevice gd, int width, int height, Rectangle destRec)
        {
            this.gd = gd;
            this.width = width;
            this.height = height;
            this.destRec = destRec;

            target = new RenderTarget2D(gd, width, height);
        }

        public void BeginRender(SpriteBatch sb)
        {
            gd.SetRenderTarget(target);
            gd.Clear(Color.Transparent);
        }

        public void EndRender(SpriteBatch sb)
        {
            gd.SetRenderTarget(null);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(target, destRec, Color.White);
        }
    }
}