class DW_Book
{
    //Create Entry container called book
    static List<DW_Page> DW_book = new List<DW_Page>();

    static void DW_AddEntry(DW_Page DW_pageN)
    {
        DW_book.Add(DW_pageN);
    }

    static void DW_EditEntry()
    {
        Console.WriteLine("EditEntry");
    }

    static void DW_DeleteEntry(int DW_index)
    {
        DW_book.RemoveAt(DW_index)
        
    }

    static void DW_Display()
    {
        foreach(DW_Page DW_pageN in DW_book)
        {
            DW_pageN.DW_Display();
        }
    }
}

