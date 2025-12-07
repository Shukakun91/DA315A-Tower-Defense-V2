using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DA315A_Tower_Defense_V2.Managers
{
    public class InputController
    {
        MouseState lastMouse;
        Point lastPos;

        public InputController()
        {
            lastMouse = Mouse.GetState();
            lastPos = lastMouse.Position;
        }

        public void Update(float dt)
        {
            MouseState mouse = Mouse.GetState();
            Point nowPos = mouse.Position;

            bool nowDown = (mouse.LeftButton == ButtonState.Pressed);
            bool lastDown = (lastMouse.LeftButton == ButtonState.Pressed);

            if (nowDown && lastDown)
            {
                MessageBus.Publish(new GameMessage("MouseLeftHeld", this, nowPos));
            }

            if (nowDown && !lastDown)
            {
                MessageBus.Publish(new GameMessage("MouseLeftClicked", this, nowPos));
            }

            if (!nowDown && lastDown)
            {
                MessageBus.Publish(new GameMessage("MouseLeftReleased", this, nowPos));
            }

            if (nowPos != lastPos)
            {
                MessageBus.Publish(new GameMessage("MouseMoved", this, nowPos));
            }

            lastMouse = mouse;
            lastPos = nowPos;
        }
    }
}
