class DW_Entry
{
    public string DW_date;
    public string DW_prompt;
    public string DW_text;

    public void DW_DisplayEntry()
    {
        Console.WriteLine("\n" + DW_date);
        Console.WriteLine(DW_prompt);
        Console.WriteLine(DW_text + "\n");
    }
}