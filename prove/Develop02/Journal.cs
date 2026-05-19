class DW_Journal
{
    public string DW_title;
    public string DW_startDate;
    public string DW_endDate;
    public List<DW_Entry> DW_book = new List<DW_Entry>();
    private Random random = new Random();
    
    public int DW_CreateEntry()
    {
        DW_Entry DW_entry = new DW_Entry();
        DW_entry.DW_prompt = DW_GeneratePrompt();
        DW_book.Add(DW_entry);
        return DW_book.Count() - 1;
    }

    public void DW_WriteEntry(int DW_index, string DW_text)
    {
        if (DW_IndexIsValid(DW_index))
        {
            if (DW_book[DW_index].DW_date == null)
            {
                DW_book[DW_index].DW_date = DateTime.Today.ToString();
                DW_endDate = DateTime.Today.ToString();
                DW_book[DW_index].DW_text = DW_text;
            }
            else
            {
                DW_book[DW_index].DW_date += ", " + DateTime.Today.ToString();
                DW_book[DW_index].DW_text += "\n--------\n" + DW_text;
            }
        }
        else
        {
            Console.Write("Bad Response");
        }
        
    }

    public void DW_RemoveEntry(int DW_index)
    {
        if (DW_IndexIsValid(DW_index))
        {
            DW_book.RemoveAt(DW_index);        
        }
        else
        {
            Console.Write("Bad Response");
        }
    }

    public void DW_DisplayJournal()
    {
        Console.WriteLine("\n\n=======================\n\n");
        Console.WriteLine(DW_title + "\n");
        Console.WriteLine(DW_startDate + " - " + DW_endDate + "\n\n");
        foreach(DW_Entry DW_entry in DW_book)
        {
            Console.WriteLine(DW_book.IndexOf(DW_entry));
            DW_entry.DW_DisplayEntry();
        }
        Console.WriteLine("\n\n=======================\n\n");
    }

    string DW_GeneratePrompt()
    {
        string[] DW_line = File.ReadAllLines("Prompts.csv");
        return DW_line[random.Next(0,DW_line.Length)];
    }

    bool DW_IndexIsValid(int DW_index)
    {
        if(0 <= DW_index && DW_index < DW_book.Count())
        {
            return(true);
        }
        else
        {
            return(false);            
        }
    }
}