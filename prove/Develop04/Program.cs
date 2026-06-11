// David Williams
// 6/11/2026
// CSE210

/*
I added a log that keeps track of the activities you did and for how long.
It also stores your responses to the Listing activity.
*/

using System;
using System.Diagnostics;

class Program
{
    static List<string> dw_log;

    static void Main(string[] args)
    {
        DW_Activity dw_1;
        string dw_state = "menu";
        string dw_startMessage;
        string dw_activityName;
        int dw_num;

        DW_LoadLog();
        
        while (true)
        {
            if(dw_state == "menu")
            {
                DW_Clear();
                DW_Print("Menu Options\n");
                DW_Print("1. Start breathing activity\n");
                DW_Print("2. Start reflecting activity\n");
                DW_Print("3. Start listing activity\n");
                DW_Print("4. Show log\n");
                DW_Print("5. Quit\n");
                dw_num = DW_PromptNum("Select a choice from the menu: ");

                if(dw_num == 1)
                {
                    dw_state = "breathing";
                }
                else if(dw_num == 2)
                {
                    dw_state = "reflecting";
                }
                else if(dw_num == 3)
                {
                    dw_state = "listing";
                }
                else if(dw_num == 4)
                {
                    dw_state = "log";
                }
                else if(dw_num == 5)
                {
                    break;
                }
            }
            else if(dw_state == "breathing")
            {
                DW_Clear();
                dw_startMessage = $"Welcome to the Breathing Activity.\n\nThis activity will help you relax by walking you through breathing in and out slowly. Clear you mind and focus on your breathing.\n\n";
                dw_activityName = "Breathing Activity";
                dw_1 = new DW_Breathing(dw_startMessage,10,dw_activityName);
                

                dw_1.DW_StartSession();
                DW_Clear();
                dw_1.DW_Print("Get ready...\n");
                dw_1.DW_Spinner(4);
                dw_1.DW_Print("\n");
                dw_1.DW_Breath();
                dw_1.DW_EndSession();
                
                DW_AppendLog(dw_1.DW_GetNewLog());
                DW_LoadLog();
                dw_state = "menu";
            }
            else if(dw_state == "reflecting")
            {
                DW_Clear();
                dw_startMessage = $"Welcome to the Reflecting Activity.\n\nThis activity will help you reflect on times in your life when you have shown strength and resilence. This will help you recognize the power you have and how you can use it in other aspects of your life.\n\n";
                dw_activityName = "Reflecting Activity";
                dw_1 = new DW_Reflecting(dw_startMessage,10,dw_activityName);
                

                dw_1.DW_StartSession();
                DW_Clear();
                dw_1.DW_Print("Get ready...\n");
                dw_1.DW_Spinner(4);
                dw_1.DW_Print("\n");
                dw_1.DW_Reflect();
                dw_1.DW_EndSession();
                
                DW_AppendLog(dw_1.DW_GetNewLog());
                DW_LoadLog();
                dw_state = "menu";
            }
            else if(dw_state == "listing")
            {
                DW_Clear();
                dw_startMessage = $"Welcome to the Listing Activity.\n\nThis activity will help reflect on the good things in your life by having you list as many things as you can in a certain area.\n\n";
                dw_activityName = "Listing Activity";
                dw_1 = new DW_Listing(dw_startMessage,10,dw_activityName);
                

                dw_1.DW_StartSession();
                DW_Clear();
                dw_1.DW_Print("Get ready...\n");
                dw_1.DW_Spinner(4);
                dw_1.DW_Print("\n");
                dw_1.DW_List();
                dw_1.DW_EndSession();

                DW_AppendLog(dw_1.DW_GetNewLog());
                DW_LoadLog();
                dw_state = "menu";

                
            }
            else if(dw_state == "log")
            {
                DW_Clear();
                DW_PrintLog();
                DW_Prompt("");
                dw_state = "menu";
            }
            
        } 
    }

    static void DW_LoadLog()
    {
        if (!File.Exists("Log.txt"))
        {
            File.Create("Log.txt").Close();
        }
        dw_log = new List<string>(File.ReadLines("Log.txt"));
    }

    static void DW_PrintLog()
    {
        foreach(string line in dw_log)
        {
            DW_Print($"{line}\n");
        }
    }

    static void DW_AppendLog(List<string> dwList)
    {
        dwList.Insert(0,"------------------");
        File.AppendAllLines("Log.txt",dwList);
    }
    
    static int DW_PromptNum(string dwMessage)
    {
        int dw_num;
        string dw_answer;
        //Ref1
        do
        {
            dw_answer = DW_Prompt(dwMessage);
        } while(!int.TryParse(dw_answer, out dw_num));

        return dw_num;
    }

    static string DW_Prompt(string dwMessage)
    {
        Console.Write(dwMessage);
        return Console.ReadLine();
    }

    static void DW_Print(string dwMessage)
    {
        Console.Write(dwMessage);
    }

    static void DW_Clear()
    {
        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.Clear();
        Console.Write("\n\n\n");
    }
}