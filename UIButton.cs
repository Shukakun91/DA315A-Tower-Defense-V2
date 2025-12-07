using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Stately;

namespace DA315A_Tower_Defense_V2
{
    public class UIButton
    {
        Rectangle bounds;
        string clickMsg;

        Point mousePos;
        bool mouseInbounds;
        bool mouseDown;

        State root = new State("root");
        State idle = new State("idle");
        State hover = new State("hover");
        State pressed = new State("pressed");

        enum VisualState { Idle, Hover, Pressed }
        VisualState visualState = VisualState.Idle;

        public UIButton(Rectangle bounds, string clickMsg)
        {
            this.bounds = bounds;
            this.clickMsg = clickMsg;

            MessageBus.Subscribe("MouseMoved", OnMouseMoved);
            MessageBus.Subscribe("MouseLeftClicked", OnMouseLeftClicked);
            MessageBus.Subscribe("MouseLeftReleased", OnMouseLeftReleased);

            DefineStateMachine();
        }

        void DefineStateMachine()
        {
            root.StartAt(idle);

            #region Events Mechanical
            idle.ChangeTo(hover).If(() => mouseInbounds);

            hover.ChangeTo(idle).If(() => !mouseInbounds);

            hover.ChangeTo(pressed).If(() => mouseDown && mouseInbounds);

            pressed.ChangeTo(hover).If(() => !mouseDown && mouseInbounds);

            pressed.ChangeTo(idle).If(() => !mouseDown && !mouseInbounds);
            
            pressed.OnExit = () =>
            {
                if (!mouseDown && mouseInbounds)
                {
                    MessageBus.Publish(new GameMessage(clickMsg, this, mousePos));
                }
            };
            #endregion
            #region Events Visual
            idle.OnEnter = () => { visualState = VisualState.Idle; };
            hover.OnEnter = () => { visualState = VisualState.Hover; };
            pressed.OnEnter = () => { visualState = VisualState.Pressed; };
            #endregion
        }

        void OnMouseMoved(GameMessage msg)
        {
            mousePos = (Point)msg.Data;
            mouseInbounds = bounds.Contains(mousePos);
        }

        void OnMouseLeftClicked(GameMessage msg)
        {
            mouseDown = true;
            mousePos = (Point)msg.Data;
            mouseInbounds = bounds.Contains(mousePos);
        }

        void OnMouseLeftReleased(GameMessage msg)
        {
            mouseDown = false;
            mousePos = (Point)msg.Data;
            mouseInbounds = bounds.Contains(mousePos);
        }

        public void Update(float dt)
        {
            root.Update(dt);
        }

        public void Draw(SpriteBatch sb)
        {
            Color color;
            if (visualState == VisualState.Pressed)    { color = Color.DarkGray; }
            else if (visualState == VisualState.Hover) { color = Color.LightGray; }
            else                                       { color = Color.White; }
            sb.Draw(AssetLibrary.Pixel, bounds, color);
        }
    }
}