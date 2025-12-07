using DA315A_Tower_Defense_V2.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2.Managers
{
    public class TowerManager : IManager
    {
        public List<Tower> TowerList => towerList;
        List<Tower> towerList = new List<Tower>();
        public TowerManager()
        {
            MessageBus.Subscribe("SpawnTower", OnSpawnTower);
        }

        void OnSpawnTower(GameMessage msg)
        {
            Point pos = (Point)msg.Data;
            Tower tower = TowerFactory.CreateTowerBasic(pos);
            towerList.Add(tower);
        }

        public void Update(float dt)
        {
            for (int i = 0; i < towerList.Count; i++)
            {
                towerList[i].Update(dt);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            //Disabled since GameplayManager wants to draw the towers instead of letting TowerManager do it on its own.
            //This is because GameplayManager is responsible for the DisplayBox that displays gameplay.
            /*
            for (int i = 0; i < towerList.Count; i++)
            {
                towerList[i].Draw(sb);
            }
            */
        }
    }
}