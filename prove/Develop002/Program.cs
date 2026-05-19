using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static string DW_menu = File.ReadAllText("Menu.txt");
    static string DW_response;
    static DW_Journal DW_journal = new DW_Journal();

    static void Main(string[] args)
    {
        string DW_state = "Menu";
        while (true)
        {
            if(DW_state == "Menu")
            {
                DW_Prompt(DW_menu);
                
                if(DW_response == "1")
                {
                    //Creat Journal
                    DW_state = "Journal";
                }
                else if(DW_response == "2")
                {
                    //Load Journal
                    //C:\Users\Senzou\Desktop\CSE210\cse210-projects\prove\Develop02\stone.csv
                    DW_Prompt("File Path:");
                    DW_BuildJournal(DW_response);
                    DW_state = "Journal";
                }
                else if(DW_response == "3")
                {
                    //Save Journal
                }
                else if(DW_response == "4" ||
                    DW_response == "4:" ||
                    DW_response == "exit" ||
                    DW_response == "Exit" ||
                    DW_response == "e" ||
                    DW_response == "E")
                {
                    break;
                }
            }
            
            if(DW_state == "Journal")
            {
                
            }
            
            if(DW_state == "Entry")
            {
                
            }
            
        }
    }
    static void DW_Prompt(string DW_prompt)
    {
        Console.WriteLine(DW_prompt);
        DW_response = Console.ReadLine().Trim();
    }
    static void DW_BuildJournal(string DW_filePath)
    {
        //C:\Users\Senzou\Desktop\CSE210\cse210-projects\prove\Develop02\stone.csv
        List <string> DW_file = File.ReadAllLines(DW_filePath).ToList();
        foreach (string DW_line in DW_file)
        {
            string[] DW_row = DW_line.Split("|");
            foreach (string DW_column in DW_row)
            {
                Console.WriteLine(DW_column);
            }
            
            DW_journal.DW_AddEntry();
            
        }
    }
}

/*
class Program
{
    static void Main(string[] args)
    {
        string DW_mode = "Menu";
        string DW_menu = File.ReadAllText("Menu.txt");
        while (true)
        {
            if(DW_mode == "Menu")
            {
                Console.WriteLine(DW_menu);
                string DW_selection = Console.ReadLine();
                if (DW_selection == "1")
                {
                    //Creat new Journel
                    DW_mode = "Journeling";
                }
                else if (DW_selection == "2")
                {
                    //Load a Journel
                    DW_journel = Program.DW_LoadJournel()
                    DW_mode = "Journeling";
                }
                else if (DW_selection == "3")
                {
                    //Save this Journel
                }
                else if (DW_selection == "4")
                {
                    break;
                }
            }
            else if (DW_mode == "Journeling")
            {
                
            }
        }
    }
    static DW_Journel DW_LoadJournel(string DW_filename)
    {
        //string DW_string = File.ReadAllText(DW_filename);
        //List<string> DW_journel = File.ReadAllLines(DW_filename).ToList();

        DW_Journel DW_journel = 
        return DW_journel
    }

    static void DW_SaveJournel(string DW_filename, string DW_data)
    {
        File.WriteAllText(DW_filename,DW_data);
    }
}
*/
