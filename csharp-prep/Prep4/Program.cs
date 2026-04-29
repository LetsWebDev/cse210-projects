//Chat ref0

using System;

//ref0
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give me some numbers please.");
        List<int> DW_numbers = new List<int>();
        
        DW_numbers = Get_numbers(DW_numbers);
        Print_stats(DW_numbers);
        DW_numbers.Sort();
        Print_list(DW_numbers);
        /*
        do
        {
            DW_num = int.Parse(Console.ReadLine());
            if(DW_num != 0)
            {
                DW_numbers.Add(DW_num);
            }
        }while(DW_num != 0);
        */

    }
    static List<int> Get_numbers(List<int> DW_list)
    {
        while (true)
        {
            int DW_num = int.Parse(Console.ReadLine());
            if(DW_num == 0)
            {
                break;
            }
            DW_list.Add(DW_num);
        }
        return DW_list;
    }

    static void Print_stats(List<int> DW_list)
    {
        int DW_sum = DW_list.Sum();
        double DW_average = DW_list.Average();
        int DW_max = DW_list.Max();
        Console.WriteLine($"The sum is: {DW_sum}\nThe average is: {DW_average}\nThe largest number is: {DW_max}");
    }

    static void Print_list(List<int> DW_list)
    {
        foreach(int DW_num in DW_list)
        {
            Console.WriteLine(DW_num);
        }
    }
}