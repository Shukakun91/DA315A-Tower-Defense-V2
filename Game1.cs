using DA315A_Tower_Defense_V2.Factories;
using DA315A_Tower_Defense_V2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DA315A_Tower_Defense_V2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sb;

        private InputController inputController;

        private SceneController sceneController;
        private Scene activeScene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);
            AssetLibrary.Initialize(GraphicsDevice);

            inputController = new InputController();

            sceneController = new SceneController();
            Scene gameplayScene = SceneFactory.CreateScene("Gameplay", GraphicsDevice);
            sceneController.Add("Gameplay", gameplayScene);
            activeScene = sceneController.SetSceneTo("Gameplay");
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            inputController.Update(dt);
            MessageBus.Dispatch();
            activeScene.Update(dt);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sb.Begin();
            activeScene.Draw(sb);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
