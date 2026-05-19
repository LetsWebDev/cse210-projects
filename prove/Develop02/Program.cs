//Ref 1     Chatgpt gave me the exact function that I need to call to change \n to \\n

using System;
using System.IO;

class Program
{
    static string DW_startMenu = File.ReadAllText("StartMenu.txt");
    static string DW_journalMenu = File.ReadAllText("JournalMenu.txt");
    static DW_Journal DW_journal = new DW_Journal();
    static int DW_index;
    static string DW_fileName;

    static void Main(string[] args)
    {
        while (true)
        {
            string DW_response = DW_Prompt(DW_startMenu);
            if(DW_response == "1")
            {
                //Create
                DW_journal.DW_title = DW_Prompt("Title:");
                DW_MenuJournal();
            }
            else if(DW_response == "2")
            {
                //load
                try
                {
                    DW_loadJournal();
                    DW_MenuJournal();
                }
                catch{}
            }
            else if(DW_response == "3")
            {
                //exit
                break;
            }
        }
    }
    
    static void DW_MenuJournal()
    {
        DW_journal.DW_DisplayJournal();
        DW_Prompt("");

        while(true)
        {
            string DW_response = DW_Prompt(DW_journalMenu);
            if(DW_response == "1")
            {
                //Display Journal
                DW_journal.DW_DisplayJournal();
            }
            else if(DW_response == "2")
            {
                //Add Entry
                DW_index = DW_journal.DW_CreateEntry();
                DW_journal.DW_book[DW_index].DW_DisplayEntry();
                string DW_text = DW_Prompt("");
                DW_journal.DW_WriteEntry(DW_index,DW_text);
            }
            else if(DW_response == "3")
            {
                //Edit Entry
                DW_index = int.Parse(DW_Prompt("Which Entry would you like to edit?"));
                DW_journal.DW_book[DW_index].DW_DisplayEntry();
                string DW_text = DW_Prompt("type:");
                DW_journal.DW_WriteEntry(DW_index,DW_text);
            }
            else if(DW_response == "4")
            {
                //Remove Entry
                DW_journal.DW_DisplayJournal();
                DW_index = int.Parse(DW_Prompt("Which Entry would you like to Remove?"));
                DW_journal.DW_RemoveEntry(DW_index);
            }
            else if(DW_response == "5")
            {
                //Save Journal
                DW_saveFile();
            }   
            else if(DW_response == "6")
            {
                //exit
                DW_journal = new DW_Journal();
                break;
            }   
        }
    }
    
    static void DW_loadJournal()
    {
        DW_fileName = DW_Prompt("Journal Name:");
        string[] DW_file = File.ReadAllLines(DW_fileName);
        List<string[]> DW_data = new List<string[]>();
        foreach (string DW_line in DW_file)
        {
            string[] DW_row = DW_line.Split("|");
            DW_data.Add(DW_row);
        }
        
        DW_journal.DW_title = DW_data[1][0];
        DW_journal.DW_startDate = DW_data[1][1];
        DW_journal.DW_endDate = DW_data[1][2];
        
        for (int DW_i = 3; DW_i < DW_data.Count; DW_i++)
        {
            DW_index = DW_journal.DW_CreateEntry();
            DW_journal.DW_book[DW_index].DW_date = DW_data[DW_i][0];
            DW_journal.DW_book[DW_index].DW_prompt = DW_data[DW_i][1];
            DW_journal.DW_book[DW_index].DW_text = DW_data[DW_i][2].Replace("\\n", "\n");
        }
    }
    
    static void DW_saveFile()
    {
        string DW_saveFile = $"title|StartDate|EndDate\n{DW_journal.DW_title}|{DW_journal.DW_startDate}|{DW_journal.DW_endDate}\nDate|Prompt|Entry";
        foreach (DW_Entry DW_entry in DW_journal.DW_book)
        {
            DW_saveFile += "\n" + DW_entry.DW_date;
            DW_saveFile += "|" + DW_entry.DW_prompt;

            //Ref 1
            DW_saveFile += "|" +  DW_entry.DW_text.Replace("\n", "\\n");
        }
        File.WriteAllText(DW_journal.DW_title + ".csv", DW_saveFile);
    }

    static public string DW_Prompt(string DW_prompt)
    {
        Console.WriteLine(DW_prompt);
        return Console.ReadLine();
    }

}