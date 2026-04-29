using System;
using System.Dynamic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DW_DisplayWellcome();
        string DW_name = DW_PromptUserName();
        int DW_number = DW_PromptUserNumber();
        int DW_birth = DW_PromptUserBirthYear();
        int DW_age = DW_CalculateAge(DW_birth);
        int DW_square = DW_SquareNumber(DW_number);
        DW_DisplayResult(DW_name,DW_square,DW_age);
    }
    static void DW_DisplayWellcome()
    {
        Console.WriteLine("Wellcom to the Program!");
    }
    static string DW_PromptUserName()
    {
        Console.WriteLine("Please enter your name:");        
        string DW_name = Console.ReadLine();
        return(DW_name);
    }
    static int DW_PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:"); 
        int DW_number = int.Parse(Console.ReadLine());
        return(DW_number);
    }
    static int DW_PromptUserBirthYear()
    {
        Console.WriteLine("Please enter the you were born:"); 
        int DW_year = int.Parse(Console.ReadLine());
        return(DW_year);
    }
    static int DW_CalculateAge(int DW_birth)
    {
        Calendar cal = CultureInfo.CurrentCulture.Calendar;
        int year = cal.GetYear(DateTime.Now);
        int DW_age = year - DW_birth;
        return(DW_age);
    }
    static int DW_SquareNumber(int DW_number)
    {
        return(DW_number*DW_number);
    }
    static void DW_DisplayResult(string DW_name, int DW_square, int DW_age)
    {
        Console.WriteLine($"{DW_name}, the square of your number is {DW_square}.");        
        Console.WriteLine($"{DW_name}, you will turn {DW_age} this year.");           
    }
}