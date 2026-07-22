using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1.Simulation
{
    internal class Galaxy:SpaceObject
    {
        private Ellipsoid dw_startBulge;
        private Ellipsoid dw_startDisc;
        public Galaxy(string name = "____", string id = "__", double mass = 0, Vector3 position = default, Vector3 velocity = default, Quaternion orientation = default, Vector3 angularVelocity = default, Dictionary<string, SpaceObject> children = null, Ellipsoid startBulge = default, Ellipsoid startDisc = default) : base(name, id, mass, position, velocity, orientation, angularVelocity, children)
        {
            dw_startBulge = startBulge;
            dw_startDisc = startDisc;
        }

        public Ellipsoid DW_GetBulge()
        {
            return dw_startBulge;
        }

        public Ellipsoid DW_GetDisc()
        {
            return dw_startDisc;
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
