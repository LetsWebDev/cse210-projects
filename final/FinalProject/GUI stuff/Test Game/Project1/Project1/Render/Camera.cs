using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Render
{
    public class Camera
    {
        // Orbit target
        public Vector3 Pivot { get; set; }

        // Camera distance from pivot
        public float Distance { get; set; }
        public float MinimumDistance { get; set; }
        public float MaximumDistance { get; set; }

        // Rotation
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        // Projection settings
        public float NearPlane { get; set; }
        public float FarPlane { get; set; }

        // Derived state
        public Vector3 Position { get; private set; }
        public Vector3 Forward { get; private set; }
        public Vector3 Right { get; private set; }
        public Vector3 Up { get; private set; }

        // Matrices
        public Matrix ViewMatrix { get; private set; }
        public Matrix ProjectionMatrix { get; private set; }


        public Camera()
        {
            Pivot = Vector3.Zero;

            Distance = 10f;
            MinimumDistance = 0.1f;
            MaximumDistance = 1_000_000_000f;

            Yaw = 0f;
            Pitch = 0f;

            NearPlane = 0.1f;
            FarPlane = 1_000_000f;

            Update();
        }


        /// <summary>
        /// Updates camera position, orientation, and view matrix.
        /// Call after changing yaw, pitch, pivot, or distance.
        /// </summary>
        public void Update()
        {
            Quaternion rotation =
                Quaternion.CreateFromYawPitchRoll(
                    Yaw,
                    Pitch,
                    0f);


            Forward =
                Vector3.Transform(
                    Vector3.Forward,
                    rotation);

            Right =
                Vector3.Transform(
                    Vector3.Right,
                    rotation);

            Up =
                Vector3.Transform(
                    Vector3.Up,
                    rotation);


            Position =
                Pivot - Forward * Distance;


            ViewMatrix =
                Matrix.CreateLookAt(
                    Position,
                    Pivot,
                    Up);
        }


        /// <summary>
        /// Updates perspective projection.
        /// Call when viewport size changes.
        /// </summary>
        public void UpdateProjection(Viewport viewport)
        {
            ProjectionMatrix =
                Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.PiOver4,
                    viewport.AspectRatio,
                    NearPlane,
                    FarPlane);
        }


        /// <summary>
        /// Converts a world position into screen coordinates.
        /// Does not perform visibility checks.
        /// Visibility is handled by clipping before projection.
        /// </summary>
        public Vector2 WorldToScreen(
            Vector3 worldPosition,
            Viewport viewport)
        {
            Vector3 projected =
                viewport.Project(
                    worldPosition,
                    ProjectionMatrix,
                    ViewMatrix,
                    Matrix.Identity);


            return new Vector2(
                projected.X,
                projected.Y);
        }
    }
}