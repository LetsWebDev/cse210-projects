class DW_Resume
{
    public string DW_name;
    public List<DW_Job> DW_jobs = new List<DW_Job>();
    public void DW_Display()
    {
        Console.WriteLine($"Name: {DW_name}\nJobs:");
        foreach (DW_Job DW_jobN in DW_jobs)
        {
            DW_jobN.DW_Display();
        }
    }
}