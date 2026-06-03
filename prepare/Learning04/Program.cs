using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        DW_Assignment dw_new = new DW_Assignment("Samuel Bennett","Multiplication");
        Console.WriteLine(dw_new.DW_GetSummery());
        
        Console.WriteLine();

        DW_MathAssignment dw_math = new DW_MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(dw_math.DW_GetSummery());
        Console.WriteLine(dw_math.DW_GetHomeworkList());
        
        Console.WriteLine();

        DW_WritingAssignment dw_english = new DW_WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(dw_english.DW_GetSummery());
        Console.WriteLine(dw_english.DW_GetWritingInformation());
    }
}

