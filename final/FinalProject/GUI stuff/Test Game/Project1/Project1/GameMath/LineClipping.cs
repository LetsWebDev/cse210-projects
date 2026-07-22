using Microsoft.Xna.Framework;
using Project1.Render;

namespace Project1.GameMath
{
    public static class LineClipping
    {
        public static bool ClipNearPlane(
            Vector3 start,
            Vector3 end,
            Camera camera,
            out Vector3 clippedStart,
            out Vector3 clippedEnd)
        {
            clippedStart = start;
            clippedEnd = end;


            // Convert points into camera space
            Vector3 cameraStart =
                Vector3.Transform(
                    start,
                    camera.ViewMatrix);

            Vector3 cameraEnd =
                Vector3.Transform(
                    end,
                    camera.ViewMatrix);


            float near =
                camera.NearPlane;


            bool startInside =
                cameraStart.Z <= -near;

            bool endInside =
                cameraEnd.Z <= -near;


            // Both points are behind the near plane
            if (!startInside && !endInside)
            {
                return false;
            }


            // Both points are visible
            if (startInside && endInside)
            {
                return true;
            }


            // Find intersection with near plane
            float t =
                (-near - cameraStart.Z) /
                (cameraEnd.Z - cameraStart.Z);


            Vector3 intersection =
                Vector3.Lerp(
                    start,
                    end,
                    t);


            if (!startInside)
            {
                clippedStart = intersection;
                clippedEnd = end;
            }
            else
            {
                clippedStart = start;
                clippedEnd = intersection;
            }


            return true;
        }
    }
}