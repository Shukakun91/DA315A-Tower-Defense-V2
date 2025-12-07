using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2.Managers
{
    public class GameplayManager : IManager
    {
        DisplayBox gameplayBox;
        TowerManager towerManager;

        public GameplayManager(DisplayBox gameplayBox, TowerManager towerManager)
        {
            this.gameplayBox = gameplayBox;
            this.towerManager = towerManager;
        }

        public void Update(float dt)
        {
            //Not updating towers here, TowerManager is responsible for that.
        }

        public void Draw(SpriteBatch sb)
        {
            //we draw towers here instead of having towerManager do it directly,
            //since we need the DisplayBox
            gameplayBox.BeginRender(sb);
            foreach (var tower in towerManager.TowerList) tower.Draw(sb);
            gameplayBox.EndRender(sb);
            gameplayBox.Draw(sb);
        }
    }
}