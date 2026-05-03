using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DW_Job DW_job1 = new DW_Job();
        DW_job1.DW_company = "Microsoft";
        DW_job1.DW_jobTitle = "Software Engineer";
        DW_job1.DW_startYear = 2019;
        DW_job1.DW_endYear = 2022;

        DW_Job DW_job2 = new DW_Job();
        DW_job2.DW_company = "Apple";
        DW_job2.DW_jobTitle = "Manager";
        DW_job2.DW_startYear = 2022;
        DW_job2.DW_endYear = 2023;

        DW_Resume DW_resume1 = new DW_Resume();
        DW_resume1.DW_name = "David Williams";
        DW_resume1.DW_jobs.Add(DW_job1);
        DW_resume1.DW_jobs.Add(DW_job2);
        DW_resume1.DW_Display();
    }
}