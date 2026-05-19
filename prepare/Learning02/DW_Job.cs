class DW_Job
{
    public string DW_company;
    public string DW_jobTitle;
    public int DW_startYear;
    public int DW_endYear;
    public void DW_Display()
    {
        Console.WriteLine($"{DW_jobTitle} ({DW_company}) {DW_startYear}-{DW_endYear}");
    }
}

/*
public class DW_Job
{
    public:
        string DW_company;
        string DW_jobTitle;
        int DW_startYear;
        int DW_endYear;
        void toString()
    {
        Console.WriteLine($"{DW_jobTitle} ({DW_company}) {DW_startYear}-{DW_endYear}");
    }
}
*/