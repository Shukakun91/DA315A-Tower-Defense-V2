using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DA315A_Tower_Defense_V2
{
    public static class AssetLibrary
    {
        public static Texture2D Pixel;

        public static Color ColorBasic;
        public static Color ColorIce;
        public static Color ColorFire;
        public static Color ColorLightning;
        public static Color ColorNature;

        public static void Initialize(GraphicsDevice gd)
        {
            Pixel = new Texture2D(gd, 1, 1);
            Pixel.SetData(new[] { Color.White });

            ColorBasic = new Color(144, 153, 161);
            ColorIce = new Color(116, 206, 192);
            ColorFire = new Color(255, 156, 84);
            ColorLightning = new Color(243, 210, 59);
            ColorNature = new Color(99, 187, 91);
        }
    }
}