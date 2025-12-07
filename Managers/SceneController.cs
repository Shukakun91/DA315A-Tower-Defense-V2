using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2.Managers
{
    public class SceneController
    {
        Dictionary<string, Scene> sceneDict = new Dictionary<string, Scene>();
        Scene activeScene;

        public SceneController() { }

        public void Add(string name, Scene scene)
        {
            sceneDict[name] = scene;
        }

        public Scene SetSceneTo(string name)
        {
            if (sceneDict.TryGetValue(name, out Scene scene))
            {
                activeScene = scene;
                return activeScene;
            }
            return null;
        }

        public Scene GetActiveScene()
        {
            return activeScene;
        }
    }
}