using System;

class Program
{
    static void Main(string[] args)
    {
        string DW_play_agian;
        do
        {
            Random randomGenerator = new Random();
            Console.WriteLine("Lets Play guess the magic number.\nHow big should we go?");
            int DW_max_range = int.Parse(Console.ReadLine());
            int DW_magic = randomGenerator.Next(1,DW_max_range);
            int DW_guess;
            int DW_gamecount = 0;
            do{
                Console.WriteLine("What is your guess?");
                DW_guess = int.Parse(Console.ReadLine());

                if(DW_guess < DW_magic)
                {
                    Console.WriteLine("Thats too small");
                }
                else if(DW_guess > DW_magic)
                {
                    Console.WriteLine("Thats too big");
                }
                else
                {
                    Console.WriteLine("Thats just right.");
                }

                DW_gamecount++;
            }while(DW_magic != DW_guess);
            string DW_output = "Bad luck";
            if(DW_gamecount < (DW_max_range / 2))
            {
                DW_output = "Great job";
            }
            if(DW_gamecount < (DW_max_range / 3))
            {
                DW_output = "Awssome work!";
            }
            if(DW_gamecount == 1)
            {
                DW_output = "INCREDIBLE!";
            Console.WriteLine($"You scored in {DW_gamecount} guess. {DW_output}");
            }
            else
            {
            Console.WriteLine($"You scored in {DW_gamecount} guesses. {DW_output}");
                
            }
            Console.WriteLine("Do you want to play again?");
            DW_play_agian = Console.ReadLine();
        }while(DW_play_agian != "no");
    }
}