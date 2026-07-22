using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace Project1.Simulation
{
    internal class SpaceSimulation
    {
        private Dictionary<string, SpaceObject> dw_universe;
        private List<string[]> dw_file;
        private double dw_time;

        private string dw_file_path;
        private string dw_file_name;

        public SpaceSimulation()
        {
            dw_universe = new Dictionary<string, SpaceObject>();
            dw_file = new List<string[]>();
            dw_time = 0;

            dw_file_path = "C:\\Users\\Senzou\\Desktop\\CSE210\\cse210-projects\\final\\FinalProject\\GUI stuff\\Test Game\\Project1\\Project1\\Simulation\\Universe.txt";
            dw_file_name = "Universe.txt";
        }

        public void DW_UpdateSpaceSimulation()
        {
            dw_time += 1;
        }


        public List<string[]> DW_LoadFile()
        {
            string[] dw_file_array = File.ReadAllLines(dw_file_path);
            List<string[]> dw_file_list = new List<string[]>();
            foreach (string dw_line in dw_file_array)
            {
                dw_file_list.Add(dw_line.Split(":"));
            }
            return dw_file_list;
        }

        public void DW_LoadUniverse()
        {
            List<string[]> dw_file = DW_LoadFile();

            SpaceObject dw_spaceObject = null;


            for (int i = 0; i < dw_file.Count; i++)
            {
                if (dw_file[i][0] == "SpaceObject")
                {
                    dw_spaceObject = DW_LoadSpaceObject(i, dw_file);

                    if (dw_file[i][5] == "0")
                    {
                        dw_universe.Add(dw_file[i][3], dw_spaceObject);
                    }
                    else
                    {
                        string[] dw_parants = dw_file[i][5].Split("/");

                        SpaceObject dw_spaceParent = null;
                        Dictionary<string, SpaceObject> dw_temp = null;
                        dw_temp = dw_universe;

                        foreach (string parant in dw_parants)
                        {
                            dw_spaceParent = dw_temp[parant];
                            dw_temp = dw_spaceParent.DW_GetChildren();
                        }

                        dw_temp.Add(dw_file[i][3], dw_spaceObject);

                    }
                }
            }
        }
        public SpaceObject DW_LoadSpaceObject(int a, List<string[]> dw_file)
        {
            SpaceObject dw_spaceObject = null;

            if (dw_file[a][1] == "Galaxy")
            {
                dw_spaceObject = DW_LoadGalaxy(dw_file[a], dw_file[a + 1], dw_file[a + 2]);
            }
            else if (dw_file[a][1] == "CelestialObject")
            {
                dw_spaceObject = DW_LoadCelestialObject(dw_file[a], dw_file[a + 1]);
            }
            else if (dw_file[a][1] == "ManMadeObject")
            {
                dw_spaceObject = DW_LoadManMadeObject(dw_file[a]);
            }

            return dw_spaceObject;
        }
        public Galaxy DW_LoadGalaxy(string[] line_galaxy, string[] line_bulge, string[] line_disc)
        {
            //Shape
            Ellipsoid dw_bulge = (Ellipsoid)ShapeBuilder.BuildIt(line_bulge[1] + ":" + line_bulge[2]);
            Ellipsoid dw_disc = (Ellipsoid)ShapeBuilder.BuildIt(line_disc[1] + ":" + line_disc[2]);

            //SpaceObject
            Galaxy dw_galaxy = new Galaxy(startBulge: dw_bulge, startDisc: dw_disc);

            dw_galaxy.DW_SetName(line_galaxy[2]);
            dw_galaxy.DW_SetID(line_galaxy[3]);

            //SetValues
            dw_galaxy.DW_SetSpaceObjectData(line_galaxy[4]);

            return dw_galaxy;
        }
        public CelestialObject DW_LoadCelestialObject(string[] line_celestial, string[] line_surface)
        {
            //Shape
            Ellipsoid dw_surface = (Ellipsoid)ShapeBuilder.BuildIt(line_surface[1] + ":" + line_surface[2]);

            //SpaceObject
            CelestialObject dw_celestial = new CelestialObject(startSurface: dw_surface);

            dw_celestial.DW_SetName(line_celestial[2]);
            dw_celestial.DW_SetID(line_celestial[3]);

            //SetValues
            dw_celestial.DW_SetSpaceObjectData(line_celestial[4]);

            return dw_celestial;
        }
        public ManMadeObject DW_LoadManMadeObject(string[] line_manMade)
        {
            //Shape

            //SpaceObject
            ManMadeObject dw_manMade = new ManMadeObject();


            dw_manMade.DW_SetName(line_manMade[2]);
            dw_manMade.DW_SetID(line_manMade[3]);

            //SetValues
            dw_manMade.DW_SetSpaceObjectData(line_manMade[4]);

            return dw_manMade;

        }



        //
        //
        //



        public void DW_SaveUniverse()
        {
            dw_file = new List<string[]>();
            DW_SaveChildren(dw_universe, "0");

            List<string> dw_list_str = new List<string>();
            foreach (string[] line in dw_file)
            {
                dw_list_str.AddRange(line);
            }

            string[] dw_file_array = dw_list_str.ToArray();

            File.WriteAllLines(dw_file_path, dw_file_array);
        }

        public void DW_SaveChildren(Dictionary<string, SpaceObject> children, string parentPath)
        {
            string[] dw_str_array = { "" };
            Dictionary<string, SpaceObject> dw_temp;

            foreach (SpaceObject dw_spaceObject in children.Values)
            {
                dw_str_array = DW_SaveSpaceObject(dw_spaceObject);
                dw_str_array[0] += ":" + parentPath;
                dw_file.Add(dw_str_array);

                dw_temp = dw_spaceObject.DW_GetChildren();

                string dw_newPath;

                if (parentPath == "0")
                {
                    dw_newPath = dw_spaceObject.DW_GetID();
                }
                else
                {
                    dw_newPath = parentPath + "/" + dw_spaceObject.DW_GetID();
                }


                DW_SaveChildren(dw_temp, dw_newPath);
            }
        }

        public string[] DW_SaveSpaceObject(SpaceObject spaceObject)
        {
            string[] dw_str_array = { "" };

            if (spaceObject.GetType() == typeof(Galaxy))
            {
                dw_str_array = DW_SaveGalaxy((Galaxy)spaceObject);
            }
            else if (spaceObject.GetType() == typeof(CelestialObject))
            {
                dw_str_array = DW_SaveCelestialObject((CelestialObject)spaceObject);
            }
            else if (spaceObject.GetType() == typeof(ManMadeObject))
            {
                dw_str_array = DW_SaveManMadeObject((ManMadeObject)spaceObject);
            }

            return dw_str_array;
        }
        public string[] DW_SaveGalaxy(Galaxy galaxy)
        {
            string[] dw_str_array = new string[4];

            dw_str_array[0] =
                "SpaceObject:Galaxy:" +
                galaxy.DW_GetName() + ":" +
                galaxy.DW_GetID() + ":" +
                galaxy.DW_SpaceObjectDataToString();

            dw_str_array[1] = "Shape:";
            dw_str_array[1] += ShapeBuilder.StoreIt(galaxy.DW_GetBulge());
            dw_str_array[2] = "Shape:";
            dw_str_array[2] += ShapeBuilder.StoreIt(galaxy.DW_GetDisc());

            return dw_str_array;
        }

        public string[] DW_SaveCelestialObject(CelestialObject celestialObject)
        {
            string[] dw_str_array = new string[3];
            dw_str_array[0] =
                "SpaceObject:CelestialObject:" +
                celestialObject.DW_GetName() + ":" +
                celestialObject.DW_GetID() + ":" +
                celestialObject.DW_SpaceObjectDataToString();

            dw_str_array[1] = "Shape:";
            dw_str_array[1] += ShapeBuilder.StoreIt(celestialObject.DW_GetSurface());

            return dw_str_array;
        }
        public string[] DW_SaveManMadeObject(ManMadeObject manMadeObject)
        {
            string[] dw_str_array = new string[2];
            dw_str_array[0] =
                "SpaceObject:ManMadeObject:" +
                manMadeObject.DW_GetName() + ":" +
                manMadeObject.DW_GetID() + ":" +
                manMadeObject.DW_SpaceObjectDataToString();

            return dw_str_array;
        }



        /*






        =============================






        */



        public Dictionary<string, SpaceObject> DW_GetUniverse()
        {
            return dw_universe;
        }


        public void DW_TestManualUniverse()
        {
            // Fake file lines matching the loaders after Split(":")
            string[] galaxyLine =
            {
                "SpaceObject",
                "Galaxy",
                "Sun",
                "S1",
                "1000/0,0,0/0,0,0/0,0,0,1/0,0,0",
                "0"
            };

            string[] bulgeLine =
            {
                "Shape",
                "Ellipsoid",
                "0,0,0/0,0,0,1/0,0,0/1000/500/false"
            };

            string[] discLine =
            {
                "Shape",
                "Ellipsoid",
                "0,0,0/0,0,0,1/0,0,0/900/100/false"
            };


            // Create galaxy.
            Galaxy sun = DW_LoadGalaxy(galaxyLine, bulgeLine, discLine);

            // Add galaxy to universe.
            dw_universe.Add(galaxyLine[3], sun);


            // Fake file line for planet.
            string[] planetLine =
            {
                "SpaceObject",
                "CelestialObject",
                "Earth",
                "E1",
                "10/100,0,0/0,0,0/0,0,0,1/0,0,0",
                "S1"
            };

            string[] surfaceLine =
            {
                "Shape",
                "Ellipsoid",
                "0,0,0/0,0,0,1/0,0,0/100/50/false"
            };


            // Create planet.
            CelestialObject earth = DW_LoadCelestialObject(planetLine, surfaceLine);


            // Add Earth as child of Sun.
            sun.DW_AddChild(planetLine[3], earth);
        }

    }
}