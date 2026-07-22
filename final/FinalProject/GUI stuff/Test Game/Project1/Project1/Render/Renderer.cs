using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.GameMath;

namespace Project1.Render
{
    public class Renderer
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Camera _camera;

        private readonly BasicEffect _worldEffect;
        private readonly BasicEffect _screenEffect;

        private readonly VertexPositionColor[] _triangleVertices =
            new VertexPositionColor[3];


        public Renderer(
            GraphicsDevice graphicsDevice,
            Camera camera)
        {
            _graphicsDevice = graphicsDevice;
            _camera = camera;


            _worldEffect = new BasicEffect(graphicsDevice)
            {
                VertexColorEnabled = true,
                LightingEnabled = false,
                TextureEnabled = false
            };


            _screenEffect = new BasicEffect(graphicsDevice)
            {
                VertexColorEnabled = true,
                LightingEnabled = false,
                TextureEnabled = false
            };
        }


        public void Begin()
        {
            _graphicsDevice.BlendState =
                BlendState.Opaque;

            _graphicsDevice.DepthStencilState =
                DepthStencilState.Default;

            _graphicsDevice.RasterizerState =
                RasterizerState.CullNone;


            // World rendering setup
            _worldEffect.World =
                Matrix.Identity;

            _worldEffect.View =
                _camera.ViewMatrix;

            _worldEffect.Projection =
                _camera.ProjectionMatrix;


            // Screen rendering setup
            Viewport viewport =
                _graphicsDevice.Viewport;


            _screenEffect.World =
                Matrix.Identity;

            _screenEffect.View =
                Matrix.Identity;

            _screenEffect.Projection =
                Matrix.CreateOrthographicOffCenter(
                    0,
                    viewport.Width,
                    viewport.Height,
                    0,
                    0,
                    1);
        }


        public void End()
        {
        }



        // =====================================================
        // World Geometry
        // =====================================================

        public void FillTriangle(
            Vector3 p1,
            Vector3 p2,
            Vector3 p3,
            Color color)
        {
            _triangleVertices[0] =
                new VertexPositionColor(p1, color);

            _triangleVertices[1] =
                new VertexPositionColor(p2, color);

            _triangleVertices[2] =
                new VertexPositionColor(p3, color);


            foreach (EffectPass pass in
                _worldEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                _graphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList,
                    _triangleVertices,
                    0,
                    1);
            }
        }


        public void FillQuadrilateral(
            Vector3 p1,
            Vector3 p2,
            Vector3 p3,
            Vector3 p4,
            Color color)
        {
            FillTriangle(
                p1,
                p2,
                p3,
                color);

            FillTriangle(
                p1,
                p3,
                p4,
                color);
        }



        // =====================================================
        // Projected Visual Aids
        // =====================================================

        public void DrawLine3D(
            Vector3 start,
            Vector3 end,
            Color color,
            float thickness = 2f)
        {
            Viewport viewport =
                _graphicsDevice.Viewport;

            if (!LineClipping.ClipNearPlane(
                start,
                end,
                _camera,
                out Vector3 clippedStart,
                out Vector3 clippedEnd))
            {
                return;
            }


            Vector2 screenStart =
                _camera.WorldToScreen(
                    clippedStart,
                    viewport);


            Vector2 screenEnd =
                _camera.WorldToScreen(
                    clippedEnd,
                    viewport);


            DrawLine2D(
                screenStart,
                screenEnd,
                color,
                thickness);
        }



        private void DrawLine2D(
            Vector2 start,
            Vector2 end,
            Color color,
            float thickness)
        {
            Vector2 direction =
                Vector2.Normalize(
                    end - start);


            Vector2 perpendicular =
                new Vector2(
                    -direction.Y,
                     direction.X);


            perpendicular *=
                thickness * 0.5f;


            Vector2 startLeft =
                start + perpendicular;

            Vector2 startRight =
                start - perpendicular;

            Vector2 endLeft =
                end + perpendicular;

            Vector2 endRight =
                end - perpendicular;



            DrawScreenTriangle(
                startLeft,
                endLeft,
                endRight,
                color);


            DrawScreenTriangle(
                startLeft,
                endRight,
                startRight,
                color);
        }

        public void DrawBezierCurve3D(
            Vector3 p0,
            Vector3 p1,
            Vector3 p2,
            Vector3 p3,
            Color color,
            int segments = 32,
            float thickness = 2f)
        {
            Vector3 previousPoint =
                GameMath.BezierCurve.Cubic(
                    p0,
                    p1,
                    p2,
                    p3,
                    0f);


            for (int i = 1; i <= segments; i++)
            {
                float t =
                    i / (float)segments;


                Vector3 currentPoint =
                    GameMath.BezierCurve.Cubic(
                        p0,
                        p1,
                        p2,
                        p3,
                        t);


                DrawLine3D(
                    previousPoint,
                    currentPoint,
                    color,
                    thickness);


                previousPoint = currentPoint;
            }
        }

        public void DrawEllipse3D(
    Vector3 center,
    Vector3 axisA,
    Vector3 axisB,
    Color color,
    int segments = 64,
    float thickness = 2f)
        {
            Vector3 previousPoint =
                GameMath.Ellipse.Point(
                    center,
                    axisA,
                    axisB,
                    0f);


            for (int i = 1; i <= segments; i++)
            {
                float angle =
                    MathHelper.TwoPi *
                    i /
                    segments;


                Vector3 currentPoint =
                    GameMath.Ellipse.Point(
                        center,
                        axisA,
                        axisB,
                        angle);


                DrawLine3D(
                    previousPoint,
                    currentPoint,
                    color,
                    thickness);


                previousPoint = currentPoint;
            }
        }



        private void DrawScreenTriangle(
            Vector2 p1,
            Vector2 p2,
            Vector2 p3,
            Color color)
        {
            VertexPositionColor[] vertices =
            {
                new VertexPositionColor(
                    new Vector3(p1, 0),
                    color),

                new VertexPositionColor(
                    new Vector3(p2, 0),
                    color),

                new VertexPositionColor(
                    new Vector3(p3, 0),
                    color)
            };


            foreach (EffectPass pass in
                _screenEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                _graphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList,
                    vertices,
                    0,
                    1);
            }
        }
    }
}