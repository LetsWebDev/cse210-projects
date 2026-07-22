using Microsoft.Xna.Framework;

namespace Project1.GameMath
{
    public static class BezierCurve
    {
        public static Vector3 Cubic(
            Vector3 p0,
            Vector3 p1,
            Vector3 p2,
            Vector3 p3,
            float t)
        {
            float u = 1 - t;

            return
                u * u * u * p0 +
                3 * u * u * t * p1 +
                3 * u * t * t * p2 +
                t * t * t * p3;
        }
    }
}