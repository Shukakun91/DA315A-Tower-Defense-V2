using Microsoft.Xna.Framework;

namespace DA315A_Tower_Defense_V2.Factories
{
    public static class TowerFactory
    {
        public static Tower CreateTowerBasic(Point pos)
        {
            //create tower
            //load sprites later
            //attach state machine later
            return new Tower(pos);
        }
    }
}