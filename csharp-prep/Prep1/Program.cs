using System;

class Program
{
    static void Main(string[] args)
    {
        string dw_firstname = Dw_Question("What is your First Name?");
        string dw_lastname = Dw_Question("What is your Last Name?");

        Console.WriteLine($"\nYour name is {dw_lastname}.");
        Console.WriteLine($"{dw_firstname} {dw_lastname}");
    }

    static string Dw_Question(string text)
    {
        Console.WriteLine(text);
        string dw_answer = Console.ReadLine();
        return(dw_answer);
    }
}
