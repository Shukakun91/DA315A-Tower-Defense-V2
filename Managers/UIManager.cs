using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2.Managers
{
    public class UIManager : IManager
    {
        List<UIButton> uiList = new List<UIButton>();
        DisplayBox displayBox;

        public UIManager(DisplayBox displayBox)
        {
            this.displayBox = displayBox;
        }

        public void AddUI(UIButton uiButton)
        {
            uiList.Add(uiButton);
        }

        public void Update(float dt)
        {
            for (int i = 0; i < uiList.Count; i++)
            {
                uiList[i].Update(dt);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            displayBox.BeginRender(sb);

            foreach (var uiElement in uiList)
            {
                uiElement.Draw(sb);
            }

            displayBox.EndRender(sb);
            displayBox.Draw(sb);
        }
    }
}
