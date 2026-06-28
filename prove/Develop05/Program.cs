using System;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        
        int dw_input;
        string dw_menu;
        string dw_goalTypeMenu;
        string dw_fileName = "Goals";
        List<string> dw_fileLines = new List<string>();


        dw_menu = $"""

Menu Options:
    1. Create New Goal
    2. Remove Goal
    3. List Goals
    4. Save Goals
    5. Load Goals
    6. Record Event
    7. Undo Event
    8. Quit
Select a choice from the menu: 
""";



        dw_goalTypeMenu = $"""
Goal Options:
    1. Simple Goal
    2. Eternal Goal
    3. Check List Goal
Select a choice from the menu: 
""";
       


        while (true)
        {
            Help.Clear();
            Help.Print($"You have {DW_Goal.DW_GetScore()} points.");
            dw_input = Help.PromptInt(dw_menu);

            if(dw_input == 1)
            {
                //Create New Goal
                dw_input = Help.PromptInt(dw_goalTypeMenu);

                string dw_name;
                string dw_description;
                int dw_points;

                if(dw_input == 1)
                {
                    //Create Simple Goal
                    dw_name = Help.PromptStr("What is the name of your goal? ");
                    dw_description = Help.PromptStr("What is a short description of it? ");
                    dw_points = Help.PromptInt("What is the amount of points associated with this goal? ");
                    DW_Goal.DW_CreateSimpleGoal(dw_name, dw_description, dw_points, false);
                }
                else if (dw_input == 2)
                {
                    //Create Eternal Goal
                    dw_name = Help.PromptStr("What is the name of your goal? ");
                    dw_description = Help.PromptStr("What is a short description of it? ");
                    dw_points = Help.PromptInt("What is the amount of points associated with this goal? ");
                    DW_Goal.DW_CreateEternalGoal(dw_name, dw_description, dw_points);
                }
                else if (dw_input == 3)
                {
                    //Create Check List Goal
                    dw_name = Help.PromptStr("What is the name of your goal? ");
                    dw_description = Help.PromptStr("What is a short description of it? ");
                    dw_points = Help.PromptInt("What is the amount of points associated with this goal? ");
                    int dw_target = Help.PromptInt("How many times do you want this to be accomplished? ");
                    int dw_completion = 0;
                    int dw_bonus = Help.PromptInt("What is the Bonus for completing this goal? ");
                    DW_Goal.DW_CreateCheckListGoal(dw_name, dw_description, dw_points, dw_target, dw_completion, dw_bonus);
                }
            }
            else if(dw_input == 2)
            {
                //Remove Goal
                Help.Clear();
                DW_Goal.DW_ListGoals();
                int dw_index = Help.PromptInt("Which Goal would you like to remove? ");
                DW_Goal.DW_RemoveGoal(dw_index - 1);
            }
            else if(dw_input == 3)
            {
                //List Goals
                Help.Clear();
                DW_Goal.DW_ListGoals();
                Help.PromptStr();
            }
            else if(dw_input == 4)
            {
                //Save Goals
                Help.Clear();
                string dw_fileName2 = Help.PromptStr($"Save: {dw_fileName}\nAlternate Name: ");
                if(dw_fileName2 != "")
                {
                    dw_fileName = dw_fileName2;
                }
                
                DW_Goal.DW_SaveGoals(dw_fileName);

            }
            else if(dw_input == 5)
            {
                //Load Goals
                
                Help.Clear();
                string dw_fileName2 = Help.PromptStr($"Load File: {dw_fileName}\nAlternate File: ");
                if(dw_fileName2 != "")
                {
                    dw_fileName = dw_fileName2;
                }

                DW_Goal.DW_LoadGoals(dw_fileName);
                
            }
            else if(dw_input == 6)
            {
                //Record Event
                Help.Clear();
                DW_Goal.DW_ListGoals();
                int dw_index = Help.PromptInt("Which Goal did you achieve? ");
                DW_Goal.DW_RecordAnEvent(dw_index-1);
            }
            else if(dw_input == 7)
            {
                //Undo Event
                Help.Clear();
                DW_Goal.DW_ListGoals();
                int dw_index = Help.PromptInt("Which Goal do you wish to undo? ");
                DW_Goal.DW_UndoAnEvent(dw_index-1);
            }
            else if(dw_input == 8)
            {
                //Quit
                break;
            }
        }
    }
}

//
//  I am useing "Help" as the name of my class
//  to make searching for it very quick.
//
//  Naming it DW_Help would cause all my classes
//  to appear focing me to carfully type it out.
//
//  With "Help" I can search he, hel, or help and
//  press tab to auto complete.
//
class Help
{
    static public void Clear()
    {
        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.Clear();
        Console.Write("\n\n\n");
    }

    static public void Print(string text = "")
    {
        Console.WriteLine(text);
    }

    static public void Print(List<string> list)
    {
        foreach(string text in list)
        {
            Console.WriteLine(text); 
        }
    }

    static public void Print(int num, string text)
    {
        while (num > 0)
        {
            Console.WriteLine();
        }
        Console.Write(text);
    }

    static public string PromptStr(string prompt = "")
    {
        Print(prompt);
        return Console.ReadLine();
    }

    static public int PromptInt(string prompt = "")
    {
        string dw_str;
        int dw_int;

        dw_str = PromptStr(prompt);

        while (!int.TryParse(dw_str, out dw_int))
        {
            dw_str = PromptStr($"{prompt}\nYou must enter a Number!\n");
        }

        return dw_int;
    }
}