using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1.Simulation
{
    internal class CelestialObject : SpaceObject
    {
        protected Ellipsoid dw_startSurface;

        public CelestialObject(string name = "____", string id = "__", double mass = 0, Vector3 position = default, Vector3 velocity = default, Quaternion orientation = default, Vector3 angularVelocity = default, Dictionary<string, SpaceObject> children = null, Ellipsoid startSurface = default) : base(name, id, mass, position, velocity, orientation, angularVelocity, children)
        {
            dw_startSurface = startSurface;
        }
        public Ellipsoid DW_GetSurface()
        {
            return dw_startSurface;
        }
        override public Vector3 DW_GetPosition(double time)
        {
            return dw_startPosition;
        }

        override public Vector3 DW_GetVelocity(double time)
        {
            return dw_startVelocity;
        }
    }
}

