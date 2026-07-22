using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Render;

namespace Project1.Input
{
    public class CameraController
    {
        private readonly Camera _camera;

        private MouseState _previousMouse;

        private readonly float _orbitSensitivity = 0.005f;
        private readonly float _panSensitivity = 0.01f;

        private const float NormalZoomFactor = 0.85f;
        private const float PrecisionZoomFactor = 0.95f;
        private const float FastZoomFactor = 0.70f;

        private const float DistancePanScale = 0.15f;

        public CameraController(Camera camera)
        {
            _camera = camera;

            _previousMouse = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();

            UpdateOrbit(mouse, keyboard);
            UpdatePan(mouse, keyboard);
            UpdateZoom(mouse, keyboard);

            _previousMouse = mouse;

            _camera.Update();
        }

        private void UpdateOrbit(
            MouseState mouse,
            KeyboardState keyboard)
        {
            if (mouse.MiddleButton == ButtonState.Pressed &&
                keyboard.IsKeyUp(Keys.LeftShift))
            {
                float deltaX =
                    mouse.X - _previousMouse.X;

                float deltaY =
                    mouse.Y - _previousMouse.Y;

                _camera.Yaw -=
                    deltaX * _orbitSensitivity;

                _camera.Pitch -=
                    deltaY * _orbitSensitivity;

                _camera.Pitch =
                    MathHelper.Clamp(
                        _camera.Pitch,
                        -MathHelper.PiOver2 + 0.01f,
                        MathHelper.PiOver2 - 0.01f);
            }
        }

        private void UpdatePan(
            MouseState mouse,
            KeyboardState keyboard)
        {
            if (mouse.MiddleButton == ButtonState.Pressed &&
                keyboard.IsKeyDown(Keys.LeftShift))
            {
                float deltaX =
                    mouse.X - _previousMouse.X;

                float deltaY =
                    mouse.Y - _previousMouse.Y;

                Vector3 pivot = _camera.Pivot;

                float panAmount =
                    _camera.Distance *
                    _panSensitivity *
                    DistancePanScale;

                pivot -=
                    _camera.Right *
                    deltaX *
                    panAmount;

                pivot +=
                    _camera.Up *
                    deltaY *
                    panAmount;

                _camera.Pivot = pivot;
            }
        }

        private void UpdateZoom(
            MouseState mouse,
            KeyboardState keyboard)
        {
            int scrollDelta =
                mouse.ScrollWheelValue -
                _previousMouse.ScrollWheelValue;

            if (scrollDelta == 0)
                return;

            float zoomFactor =
                NormalZoomFactor;

            bool precision =
                keyboard.IsKeyDown(Keys.LeftShift) ||
                keyboard.IsKeyDown(Keys.RightShift);

            bool fast =
                keyboard.IsKeyDown(Keys.LeftControl) ||
                keyboard.IsKeyDown(Keys.RightControl);

            if (precision)
            {
                zoomFactor = PrecisionZoomFactor;
            }
            else if (fast)
            {
                zoomFactor = FastZoomFactor;
            }

            int wheelSteps =
                scrollDelta / 120;

            if (wheelSteps > 0)
            {
                for (int i = 0; i < wheelSteps; i++)
                {
                    _camera.Distance *= zoomFactor;
                }
            }
            else
            {
                for (int i = 0; i < -wheelSteps; i++)
                {
                    _camera.Distance /= zoomFactor;
                }
            }

            _camera.Distance =
                MathHelper.Clamp(
                    _camera.Distance,
                    _camera.MinimumDistance,
                    _camera.MaximumDistance);
        }
    }
}