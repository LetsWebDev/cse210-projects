using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Project1.Simulation
{
    internal abstract class SpaceObject
    {
        protected string dw_name;
        protected string dw_id;
        protected double dw_startMass;
        protected Vector3 dw_startPosition;
        protected Vector3 dw_startVelocity;
        protected Quaternion dw_startOrientation;
        protected Vector3 dw_startAngularVelocity;
        protected Dictionary<string,SpaceObject> dw_children;

        public SpaceObject(string name = "____", string id = "__", double mass = 0, Vector3 position = default, Vector3 velocity = default, Quaternion orientation = default, Vector3 angularVelocity = default, Dictionary<string,SpaceObject> children = null)
        {
            dw_name = name;
            dw_id = id;
            dw_startMass = mass;
            dw_startPosition = position;
            dw_startVelocity = velocity;
            dw_startOrientation = orientation;
            dw_startAngularVelocity = angularVelocity;
            if (children == null)
            {
                dw_children = new Dictionary<string, SpaceObject>();
            }
            else
            {
                dw_children = new Dictionary<string, SpaceObject>(children);
            }
        }

        public void DW_SetName(string name)
        {
            dw_name = name;
        }

        public void DW_SetID(string ID)
        {
            dw_id = ID;
        }

        public void DW_SetSpaceObjectData(string line)
        {
            string[] dw_data_array = line.Split('/');

            dw_startMass = double.Parse(dw_data_array[0]);
            dw_startPosition = DW_Convert.Str_to_V3(dw_data_array[1]);
            dw_startVelocity = DW_Convert.Str_to_V3(dw_data_array[2]);
            dw_startOrientation = DW_Convert.Str_to_Qua(dw_data_array[3]);
            dw_startAngularVelocity = DW_Convert.Str_to_V3(dw_data_array[4]);
        }
        public void DW_SetChildren(Dictionary<string,SpaceObject> children)
        {
            dw_children = new Dictionary<string, SpaceObject>(children);
        }

        public void DW_AddChild(string id, SpaceObject child)
        {
            dw_children.Add(id, child);
        }

        public string DW_GetName()
        {
            return dw_name;
        }

        public string DW_GetID()
        {
            return dw_id;
        }

        abstract public Vector3 DW_GetPosition(double time);

        abstract public Vector3 DW_GetVelocity(double time);
        virtual public double DW_GetMass(double time)
        {
            return dw_startMass;
        }
        virtual public Quaternion DW_GetOrientation(double time)
        {
            return dw_startOrientation;
        }

        virtual public Vector3 DW_GetAngularVelocity(double time)
        {
            return dw_startAngularVelocity;
        }
        public string DW_SpaceObjectDataToString()
        {
            string dw_str = "";

            dw_str += DW_Convert.db_to_Str(dw_startMass) + "/";
            dw_str += DW_Convert.V3_to_Str(dw_startPosition) + "/";
            dw_str += DW_Convert.V3_to_Str(dw_startVelocity) + "/";
            dw_str += DW_Convert.Qua_to_Str(dw_startOrientation) + "/";
            dw_str += DW_Convert.V3_to_Str(dw_startAngularVelocity);

            return dw_str;
        }

        public Dictionary<string, SpaceObject> DW_GetChildren()
        {
            return dw_children;
        }
    }
}
