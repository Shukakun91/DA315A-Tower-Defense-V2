using DA315A_Tower_Defense_V2.Managers;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2
{
    public class Scene
    {
        List<IManager> managerList = new List<IManager>();

        public Scene()
        {

        }

        public void AddManager(IManager manager)
        {
            managerList.Add(manager);
        }

        public void Update(float dt)
        {
            for (int i = 0; i < managerList.Count; i++)
            {
                managerList[i].Update(dt);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < managerList.Count; i++)
            {
                managerList[i].Draw(sb);
            }
        }
    }
}