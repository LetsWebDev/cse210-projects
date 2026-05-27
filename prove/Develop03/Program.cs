//Ref 5 Chatgpt Idetified a better way to use try{}
//https://chatgpt.com/s/t_6a1656b05e84819199146ff1324c967e
//Exc 1    I added the fuctionality for the user to set how many word get hidden each time.
using System;
using System.Formats.Asn1;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string reference_dw = "2 Nephi 31:18";
        string file_dw = File.ReadAllText("Scripture.txt");
        Scripture_dw scripture_dw = new Scripture_dw(reference_dw,file_dw);
        int num_dw = 1;

        while(true)
        {
            Print_dw(scripture_dw.ToString());
            string answer_dw = Prompt_dw("");
            if(answer_dw == "quit" || answer_dw == "q" || answer_dw == "Q" || answer_dw == "exit" || answer_dw == "e" || answer_dw == "0")
            {
                break;
            }
            //Ref 5
            //Exc 1
            if(int.TryParse(answer_dw, out int temp_dw))
            {
                num_dw = temp_dw;
            }
            if(num_dw > 0)
            {
                for(int i = 0; i < num_dw; i++){
                    scripture_dw.HideWord_dw();
                }
            }
            else
            {
                break;
            }

            
            
            if (scripture_dw.GetIsAllHidden_dw())
            {
                Print_dw(scripture_dw.ToString());
                Prompt_dw("");
                break;            
            }
        }
    }

    static void Print_dw(string print_dw)
    {
        Console.Write(print_dw);
    }

    static string Prompt_dw(string question_dw)
    {
        Print_dw($"\n{question_dw}");
        return Console.ReadLine();
    }
}

/*
class Program
{
    public static List<int> cards_dw;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        cards_dw = new List<int>();
        SetDeck_dw(cards_dw,20);
        DisplayDeck_dw(cards_dw);
        Shuffle_dw(cards_dw,20);

    } 
    static public void Shuffle_dw(List<int> list_dw, int num_dw)
    {
        for (int i = 1; i <= num_dw; i++)
        {
            list_dw = OneShuffle_dw(list_dw,2);
            DisplayDeck_dw(list_dw);
        }
    }
    static public List<int> SetDeck_dw(List<int> list_dw, int num_dw)
    {
        for (int i = 1; i <= num_dw; i++)
        {
            list_dw.Add(i);
        }
        return list_dw;
    }
    static public List<int> OneShuffle_dw(List<int> list_dw, int num_dw)
    {
        List<int> newlist_dw = new List<int>();
        newlist_dw.Add(list_dw[0]);
        for (int i = 1; i < list_dw.Count; i++)
        {
            if ((i/num_dw) % 2 < 1)
            {
                newlist_dw.Insert(0,list_dw[i]);
            }
            else
            {
                newlist_dw.Add(list_dw[i]);
            }
        }
        return newlist_dw;
    }
    static public void DisplayDeck_dw(List<int> list_dw)
    {
        int num_dw = 0;
        for (int i = 0; i < list_dw.Count; i++)
        {
            Console.Write(list_dw[i] + " ");
            if (i + 1 == list_dw[i])
            {
                num_dw++;
            }
        }
        if(num_dw == list_dw.Count)
        {
            Console.WriteLine($"  -->     {num_dw}");
        }
        else
        {
            Console.WriteLine($"          {num_dw}");
        }
    }
}
*/