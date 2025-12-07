using DA315A_Tower_Defense_V2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace DA315A_Tower_Defense_V2.Factories
{
    public static class SceneFactory
    {
        public static Scene CreateScene(string name, GraphicsDevice gd)
        {
            if (name == "Gameplay")
            {
                return CreateSceneGameplay(gd);
            }
            else
            {
                Debug.WriteLine("ERROR: SceneFactory has no definition of the scene " + name + ".");
                return null;
            }
        }

        static Scene CreateSceneGameplay(GraphicsDevice gd)
        {
            Scene scene = new Scene();

            DisplayBox uiBox = new DisplayBox(gd, 400, 400, new Rectangle(0, 0, 400, 400));
            UIManager uiManager = new UIManager(uiBox);

            UIButton spawnButton = new UIButton(new Rectangle(20, 20, 100, 40), "SpawnTower");
            uiManager.AddUI(spawnButton);

            scene.AddManager(uiManager);

            TowerManager towerManager = new TowerManager();
            scene.AddManager(towerManager);

            DisplayBox gameplayBox = new DisplayBox(gd, 800, 600, new Rectangle(0, 0, 800, 600));
            GameplayManager gameplayManager = new GameplayManager(gameplayBox, towerManager);
            scene.AddManager(gameplayManager);

            return scene;
        }
    }
}
