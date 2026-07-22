using Microsoft.Xna.Framework;
using System;

namespace Project1.GameMath
{
    public static class Ellipse
    {
        public static Vector3 Point(
            Vector3 center,
            Vector3 axisA,
            Vector3 axisB,
            float angle)
        {
            return
                center +
                axisA * MathF.Cos(angle) +
                axisB * MathF.Sin(angle);
        }
    }
}