using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1.Simulation
{
    internal class ManMadeObject : SpaceObject
    {
        protected Vector3 dw_startDimensions;
        protected Vector3 dw_startCenterMass;
        protected List<Shape> dw_startModel;

        public ManMadeObject(string name = "____", string id = "__", double mass = 0, Vector3 position = default, Vector3 velocity = default, Quaternion orientation = default, Vector3 angularVelocity = default, Dictionary<string,SpaceObject> children = null, Vector3 startDimensions = default, Vector3 startCenterMass = default, List<Shape> startModel = null) : base(name, id, mass, position, velocity, orientation, angularVelocity, children)
        {
            dw_startDimensions = startDimensions;
            dw_startCenterMass = startCenterMass; 
            
            if (startModel == null)
            {
                dw_startModel = new List<Shape>();
            }
            else
            {
                dw_startModel = new List<Shape>(startModel);
            }
        }

        public List<Shape> DW_GetModel(double time)
        {
            return dw_startModel;
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
