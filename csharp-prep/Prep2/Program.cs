class Program
{
    static void Main(string[] args)
    {
        bool DW_is_grading = true;
        while (DW_is_grading){
        Console.WriteLine("\n\nWhat is your Grade percentage?");
        int DW_per = int.Parse(Console.ReadLine());
        string DW_grade;
        if (DW_per >= 90)
        {
            DW_grade = "A";
        }
        else if (DW_per >= 80)
        {
            DW_grade = "B";
        }
        else if (DW_per >= 70)
        {
            DW_grade = "C";
        }
        else if (DW_per >= 60)
        {
            DW_grade = "D";
        }
        else
        {
            DW_grade = "F";
        }

        int DW_dec = DW_per%10;
        if (DW_grade != "F")
            {
                if (DW_per >= 100)
                    {
                        DW_grade = $"{DW_grade}+";
                    }
                else if (DW_dec < 3)
                    {
                        DW_grade = $"{DW_grade}-";
                    }
                else if (DW_dec > 7)
                    {
                        
                        DW_grade = $"{DW_grade}+";
                    }
            }
            
        Console.WriteLine(DW_grade);
        Console.WriteLine($"Your grade is a {DW_grade}");
        if (DW_per >= 70)
            {
                Console.WriteLine($"Congraduations! {DW_grade} is high enough to pass. You can move on to the next class.");
            }
        else
            {
                Console.WriteLine($"Sorry, {DW_grade} is not high enough to pass. Retake the class.");
            }
        
        Console.WriteLine("\nDo you want to be graded again?");
        string DW_answer = Console.ReadLine();
        if ("no" == DW_answer)
        {
            DW_is_grading = false;
        }
        }
    }
}