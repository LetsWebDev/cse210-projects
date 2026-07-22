using Project1.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

//using var game = new Project1.Game1();
//game.Run();


SpaceSimulation simulation = new SpaceSimulation();
simulation.DW_LoadUniverse();
simulation.DW_SaveUniverse();

/*
double mass = 1;
Vector3 position = new Vector3(1, 2, 3);
Vector3 velocity = new Vector3(1, 2, 3);
Quaternion orientation = new Quaternion(0, 0, 0, 0);
Vector3 angularVelocity = new Vector3(1,2,3);
List<SpaceObject> children = new List<SpaceObject>();
Ellipsoid bulge = (Ellipsoid)ShapeBuilder.BuildIt("Ellipsoid:1,2,3/1,2,3,4/");
Ellipsoid disc = (Ellipsoid)ShapeBuilder.BuildIt("");

Galaxy MiklyWay = new Galaxy(mass, position, velocity, orientation, angularVelocity, children, bulge, disc);



Shape laser1 = ShapeBuilder.BuildIt("Laser:1,2,3/1,2,3,4/1,2,3/1,2,3/1000/2000");

string dw_str = ShapeBuilder.StoreIt(laser1);

string dw_file = "C:\\Users\\Senzou\\Desktop\\CSE210\\cse210-projects\\final\\FinalProject\\GUI stuff\\Test Game\\Project1\\Project1\\Simulation\\Universe.txt";
string[] dw_str_array = [dw_str];
File.WriteAllLines(dw_file, dw_str_array);
*/