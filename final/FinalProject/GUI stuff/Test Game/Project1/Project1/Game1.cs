using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Input;
using Project1.Render;
using Project1.Simulation;
using System;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Renderer _render;
        private Camera _camera;
        private CameraController _cameraController;
        private SpaceSimulation _simulation;


        public Game1()
        {
            _simulation = new SpaceSimulation();
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferMultiSampling = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _camera = new Camera();

            _camera.Update();

            _camera.UpdateProjection(
                GraphicsDevice.Viewport);


            _cameraController =
                new CameraController(_camera);


            _render =
                new Renderer(
                    GraphicsDevice,
                    _camera);
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            _cameraController.Update(gameTime);


            // Recalculate camera matrices after movement
            _camera.Update();


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);


            _camera.UpdateProjection(
                GraphicsDevice.Viewport);


            _render.Begin();


            // 3D test triangles

            _render.FillTriangle(
                new Vector3(-0.5f, -0.5f, -10),
                new Vector3(0f, 0.5f, -10),
                new Vector3(0.5f, -0.5f, -10),
                Color.White);


            _render.FillTriangle(
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(0f, 0.5f, 0),
                new Vector3(0.5f, -0.5f, 0),
                Color.Red);



            // Screen-space visual aids

            _render.DrawLine3D(
                new Vector3(-0.5f, 0, 0),
                new Vector3(0.5f, 1, 0),
                Color.Yellow);


            _render.DrawLine3D(
                new Vector3(-1, -1, 1),
                new Vector3(1, 0, 2),
                Color.Orange);



            //Axis
            _render.DrawLine3D(
                new Vector3(-2, 0, 0),
                new Vector3(2, 0, 0),
                Color.Red);


            _render.DrawLine3D(
                new Vector3(0, -2, 0),
                new Vector3(0, 2, 0),
                Color.Green);


            _render.DrawLine3D(
                new Vector3(0, 0, -2),
                new Vector3(0, 0, 2),
                Color.Black);
            //Axis



            _render.DrawBezierCurve3D(
                new Vector3(-5, 0, 1),
                new Vector3(-2, 5, -5),
                new Vector3(2, -5, -1),
                new Vector3(5, 0, 0),
                Color.Cyan,
                64,
                3f);

            _render.DrawEllipse3D(
                Vector3.Zero,
                new Vector3(0, 0, 1.49598f),
                new Vector3(
                    1.49577f * MathF.Cos(MathHelper.ToRadians(7.155f)),
                    1.49577f * MathF.Sin(MathHelper.ToRadians(7.155f)),
                    0
                ),
                Color.White);

            _render.End();


            base.Draw(gameTime);
        }
    }
}