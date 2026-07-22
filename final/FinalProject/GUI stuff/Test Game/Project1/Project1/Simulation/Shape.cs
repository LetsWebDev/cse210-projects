using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

//ChatGPT generated
//ref1: Array_to_Array()
//ref2: Str_to_Array()

namespace Project1.Simulation
{
    internal class Shape
    {
        public Vector3 dw_position;
        public Quaternion dw_orentation;
        public Vector3 dw_pivot;

        public Shape(Vector3 position, Quaternion orentation, Vector3 pivot)
        {
            this.dw_position = position;
            this.dw_orentation = orentation;
            this.dw_pivot = pivot;
        }
    }

    internal class Ellipsoid : Shape
    {
        public double dw_majorRadius;
        public double dw_minorRadius;
        public bool dw_isHalf;

        public Ellipsoid(Vector3 position, Quaternion orentation, Vector3 pivot, double majorRadius, double minorRadius, bool isHalf) : base(position, orentation, pivot)
        {
            dw_majorRadius = majorRadius;
            dw_minorRadius = minorRadius;
            dw_isHalf = isHalf;
        }
    }

    internal class Cone : Shape
    {
        public double dw_radius;
        public double dw_height;
        public Cone(Vector3 position, Quaternion orentation, Vector3 pivot, double radius, double height) : base(position, orentation, pivot)
        {
            dw_radius = radius;
            dw_height = height;
        }
    }

    internal class Cylinder : Cone
    {
        public Cylinder(Vector3 position, Quaternion orentation, Vector3 pivot, double radius, double height) : base(position, orentation, pivot, radius, height) { }
    }

    internal class QuadrilateralPrism : Shape
    {
        public Vector3 dw_dimensions;
        public Vector2 dw_corner1;
        public Vector2 dw_corner2;
        public QuadrilateralPrism(Vector3 position, Quaternion orentation, Vector3 pivot, Vector3 dimensions, Vector2 corner1, Vector2 corner2) : base(position, orentation, pivot)
        {
            dw_dimensions = dimensions;
            dw_corner1 = corner1;
            dw_corner2 = corner2;
        }
    }
    internal class Laser : Shape
    {
        public Vector3 dw_target;
        public double dw_focalPoint;
        public double dw_percision;
        public Laser(Vector3 position, Quaternion orentation, Vector3 pivot, Vector3 target, double focalPoint, double percision) : base(position, orentation, pivot)
        {
            dw_target = target;
            dw_focalPoint = focalPoint;
            dw_percision = percision;
        }
    }






    internal class DW_Convert
    {
        //
        // Type To Str
        //
        static public string Bool_to_Str(bool value)
        {
            return $"{value}";
        }
        static public string db_to_Str(double db)
        {
            return $"{db}";
        }
        static public string V2_to_Str(Vector2 v)
        {
            return $"{v.X},{v.Y}";
        }
        static public string V3_to_Str(Vector3 v)
        {
            return $"{v.X},{v.Y},{v.Z}";
        }
        static public string Qua_to_Str(Quaternion qua)
        {
            return $"{qua.X},{qua.Y},{qua.Z},{qua.W}";
        }

        //
        // Str To Type
        //
        static public bool Str_to_Bool(string str)
        {
            return bool.Parse(str);
        }
        static public double Str_to_db(string str)
        {
            return double.Parse(str);
        }
        static public Vector2 Str_to_V2(string str)
        {
            float[] dw_float_array = Str_to_Array(str, float.Parse);
            return new Vector2(dw_float_array[0], dw_float_array[1]);
        }
        static public Vector3 Str_to_V3(string str)
        {
            /*
            string[] dw_str_array = str.Split(',');
            float[] dw_float_array = new float[dw_str_array.Length];

            dw_float_array[0] = float.Parse(dw_str_array[0]);
            dw_float_array[1] = float.Parse(dw_str_array[1]);
            dw_float_array[2] = float.Parse(dw_str_array[2]);

            return new Vector3(dw_float_array[0], dw_float_array[1], dw_float_array[2]);
            */
            float[] dw_float_array = Str_to_Array(str, float.Parse);
            return new Vector3(dw_float_array[0], dw_float_array[1], dw_float_array[2]);
        }

        static public Quaternion Str_to_Qua(string str)
        {
            /*
            string[] dw_str_array = str.Split(',');
            float[] dw_float_array = new float[dw_str_array.Length];
            for (int i = 0; i < dw_str_array.Length; i++)
            {
                dw_float_array[i] = float.Parse(dw_str_array[i]);
            }
            return new Quaternion(dw_float_array[0], dw_float_array[1], dw_float_array[2], dw_float_array[3]);
            */
            float[] dw_float_array = Str_to_Array(str, float.Parse);
            return new Quaternion(dw_float_array[0], dw_float_array[1], dw_float_array[2], dw_float_array[3]);
        }

        //ref1
        static public T[] Array_to_Array<T>(string[] source, Func<string, T> parser)
        {
            T[] result = new T[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = parser(source[i]);
            }

            return result;
        }
        //ref2
        static public T[] Str_to_Array<T>(string str, Func<string, T> parser)
        {
            T[] dw_array = Array_to_Array(str.Split(','), parser);
            return dw_array;
        }
    }
    









    internal class ShapeBuilder
    {
        static public Shape BuildIt(string str)
        {
            Console.WriteLine(str);
            //str = "Ellipsoid:3,4,0/1,2,3,4/3,3,3/54554.44/0.11134/true"
            string[] dw_str_array1 = str.Split(':');
            string[] dw_str_array2 = dw_str_array1[1].Split('/');
            List<string> dw_list = new List<string>(dw_str_array2);
            return Build(dw_str_array1[0], dw_list);
        }
        static public Shape Build(string shape, List<string> list)
        {
            if (shape == "Ellipsoid")
            {
                return DW_BuildEllipsoid(list);
            }
            else if (shape == "Cone")
            {
                return DW_BuildCone(list);
            }
            else if (shape == "Cylinder")
            {
                return DW_BuildCylinder(list);
            }
            else if (shape == "QuadrilateralPrism")
            {
                return DW_BuildQuadrilateralPrism(list);
            }
            else if (shape == "Laser")
            {
                return DW_BuildLaser(list);
            }
            else
            {
                throw new InvalidOperationException("Unknown shape type");
            }
        }
        static public Ellipsoid DW_BuildEllipsoid(List<string> list)
        {
            Vector3 dw_position = DW_Convert.Str_to_V3(list[0]);
            Quaternion dw_orentation = DW_Convert.Str_to_Qua(list[1]);
            Vector3 dw_pivot = DW_Convert.Str_to_V3(list[2]);

            double dw_majorRadius = DW_Convert.Str_to_db(list[3]);
            double dw_minorRadius = DW_Convert.Str_to_db(list[4]);
            bool dw_isHalf = DW_Convert.Str_to_Bool(list[5]);

            return new Ellipsoid(dw_position,
                dw_orentation,
                dw_pivot,
                dw_majorRadius,
                dw_minorRadius,
                dw_isHalf);
        }

        static public Cone DW_BuildCone(List<string> list)
        {
            Vector3 dw_position = DW_Convert.Str_to_V3(list[0]);
            Quaternion dw_orentation = DW_Convert.Str_to_Qua(list[1]);
            Vector3 dw_pivot = DW_Convert.Str_to_V3(list[2]);


            double dw_radius = DW_Convert.Str_to_db(list[3]);
            double dw_height = DW_Convert.Str_to_db(list[4]);

            return new Cone(dw_position,
                dw_orentation,
                dw_pivot,
                dw_radius,
                dw_height);
        }

        static public Cylinder DW_BuildCylinder(List<string> list)
        {
            Vector3 dw_position = DW_Convert.Str_to_V3(list[0]);
            Quaternion dw_orentation = DW_Convert.Str_to_Qua(list[1]);
            Vector3 dw_pivot = DW_Convert.Str_to_V3(list[2]);

            double dw_radius = DW_Convert.Str_to_db(list[3]);
            double dw_height = DW_Convert.Str_to_db(list[4]);

            return new Cylinder(dw_position,
                dw_orentation,
                dw_pivot,
                dw_radius,
                dw_height);
        }

        static public QuadrilateralPrism DW_BuildQuadrilateralPrism(List<string> list)
        {
            Vector3 dw_position = DW_Convert.Str_to_V3(list[0]);
            Quaternion dw_orentation = DW_Convert.Str_to_Qua(list[1]);
            Vector3 dw_pivot = DW_Convert.Str_to_V3(list[2]);

            Vector3 dw_dimensions = DW_Convert.Str_to_V3(list[3]);
            Vector2 dw_corner1 = DW_Convert.Str_to_V2(list[4]);
            Vector2 dw_corner2 = DW_Convert.Str_to_V2(list[5]);
            
            //return new QuadrilateralPrism(dw_position, dw_orentation, dw_pivot, dw_dimensions, dw_corner1, dw_corner2);
            return new QuadrilateralPrism(
            dw_position,
            dw_orentation,
            dw_pivot,
            dw_dimensions,
            dw_corner1,
            dw_corner2);

        }

        static public Laser DW_BuildLaser(List<string> list)
        {
            Vector3 dw_position = DW_Convert.Str_to_V3(list[0]);
            Quaternion dw_orentation = DW_Convert.Str_to_Qua(list[1]);
            Vector3 dw_pivot = DW_Convert.Str_to_V3(list[2]);

            Vector3 dw_target = DW_Convert.Str_to_V3(list[3]);
            double dw_focalPoint = DW_Convert.Str_to_db(list[4]);
            double dw_percision = DW_Convert.Str_to_db(list[5]);

            return new Laser(dw_position,
                dw_orentation,
                dw_pivot,
                dw_target,
                dw_focalPoint,
                dw_percision);

        }

        static public string StoreIt(Shape shape)
        {
            string dw_type = "";
            string dw_data = "";
            if (shape.GetType() == typeof(Ellipsoid))
            {
                dw_type = "Ellipsoid";
                dw_data = DW_StoreEllipsoid((Ellipsoid)shape);
            }
            else if (shape.GetType() == typeof(Cone))
            {
                dw_type = "Cone";
                dw_data = DW_StoreCone((Cone)shape);
            }
            else if (shape.GetType() == typeof(Cylinder))
            {
                dw_type = "Cylinder";
                dw_data = DW_StoreCylinder((Cylinder)shape);
            }
            else if (shape.GetType() == typeof(QuadrilateralPrism))
            {
                dw_type = "QuadrilateralPrism";
                dw_data = DW_StoreQuadrilateralPrism((QuadrilateralPrism)shape);
            }
            else if (shape.GetType() == typeof(Laser))
            {
                dw_type = "Laser";
                dw_data = DW_StoreLaser((Laser)shape);
            }

            return $"{dw_type}:{dw_data}";
        }

        static public string DW_StoreShape(Shape shape)
        {
            string dw_str = "";

            dw_str += DW_Convert.V3_to_Str(shape.dw_position) + '/';
            dw_str += DW_Convert.Qua_to_Str(shape.dw_orentation) + '/';
            dw_str += DW_Convert.V3_to_Str(shape.dw_pivot);

            return dw_str;
        }

        static public string DW_StoreEllipsoid(Ellipsoid shape)
        {
            string dw_str = DW_StoreShape(shape) + '/';

            dw_str += DW_Convert.db_to_Str(shape.dw_majorRadius) + '/';
            dw_str += DW_Convert.db_to_Str(shape.dw_minorRadius) + '/';
            dw_str += DW_Convert.Bool_to_Str(shape.dw_isHalf);

            return dw_str;
        }

        static public string DW_StoreCone(Cone shape)
        {
            string dw_str = DW_StoreShape(shape) + '/';

            dw_str += DW_Convert.db_to_Str(shape.dw_radius) + '/';
            dw_str += DW_Convert.db_to_Str(shape.dw_height);

            return dw_str;
        }

        static public string DW_StoreCylinder(Cylinder shape)
        {
            return DW_StoreCone(shape);
        }

        static public string DW_StoreQuadrilateralPrism(QuadrilateralPrism shape)
        {
            string dw_str = DW_StoreShape(shape) + '/';

            dw_str += DW_Convert.V3_to_Str(shape.dw_dimensions) + '/';
            dw_str += DW_Convert.V2_to_Str(shape.dw_corner1) + '/';
            dw_str += DW_Convert.V2_to_Str(shape.dw_corner2);

            return dw_str;
        }

        static public string DW_StoreLaser(Laser shape)
        {
            string dw_str = DW_StoreShape(shape) + '/';

            dw_str += DW_Convert.V3_to_Str(shape.dw_target) + '/';
            dw_str += DW_Convert.db_to_Str(shape.dw_focalPoint) + '/';
            dw_str += DW_Convert.db_to_Str(shape.dw_percision);

            return dw_str;
        }
    }
}