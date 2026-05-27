//Ref 3 Chatgpt helped me spot problems and gave me the correct built in functions that I was trying to use.
//Chatgpt showed me Join, which did what I was trying to code.
//https://chatgpt.com/s/t_6a161068bd088191b29858c2a51acb71

//Ref 4 Chatgpt reminded me that Join and other functions can access ToString automatically.
//https://chatgpt.com/s/t_6a164f36999c8191a267209d316f9c7e

//Exc 2    I improved optimisation by having the code pares through the list when it fails
//to find a word that isn't hidden. So instead of guessing randomly over and over again it
//has a finiten number of loops it can run through before it finds a valid word.

class Scripture_dw
{
    private Reference_dw reference_dw;
    private List<Word_dw> verses_dw;
    private int visibleCount_dw;
    private Random random;

    public Scripture_dw(string newReference_dw, string newVerses_dw)
    {
        random = new Random();
        verses_dw = new List<Word_dw>();
        SetVerses_dw(newVerses_dw);
        SetReference_dw(newReference_dw);
    }

    public void HideWord_dw()
    {
        if(visibleCount_dw > 0)
        {
            //Exc 2
            int index_dw = random.Next(verses_dw.Count);
            while (verses_dw[index_dw].GetHidden_dw())
            {
                index_dw = (index_dw + 1) % verses_dw.Count;
            }

            verses_dw[index_dw].SetHidden_dw(true);   
            visibleCount_dw --;             
        }
    }

    public bool GetIsAllHidden_dw()
    {
        if(visibleCount_dw > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override string ToString()
    {
        /*
        //Ref 4
        string output_dw = "";
        foreach(Word_dw word_dw in verses_dw)
        {
            output_dw += word_dw.ToString() + " ";
        }
        return output_dw;
        */
        string output_dw = reference_dw.ToString();
        output_dw += "\n" + string.Join(" ", verses_dw);
        return output_dw;
    }

    private void SetVerses_dw(string newVerses_dw)
    {
        foreach (string word_dw in newVerses_dw.Split(' '))
        {
            Word_dw newWord_dw = new Word_dw(word_dw);
            verses_dw.Add(newWord_dw);
            visibleCount_dw ++;
        }
    }

    private void SetReference_dw(string newReference_dw)
    {
        string[] reference_And_Verses_dw = newReference_dw.Split(":");
        string[] bookElements_And_Chapter_dw = reference_And_Verses_dw[0].Split(' ');
        string[] startVerse_And_EndVerse_dw = reference_And_Verses_dw[1].Split("-");

        int chapter_dw = int.Parse(bookElements_And_Chapter_dw[bookElements_And_Chapter_dw.Length - 1]);
        string book_dw = string.Join(" ", bookElements_And_Chapter_dw, 0, bookElements_And_Chapter_dw.Length - 1);


        int startVerse_dw = int.Parse(startVerse_And_EndVerse_dw[0]);
        int endVerse_dw;

        if(startVerse_And_EndVerse_dw.Length > 1)
        {
            endVerse_dw = int.Parse(startVerse_And_EndVerse_dw[1]);
        }
        else
        {
            endVerse_dw = startVerse_dw;
        }
        
        reference_dw = new Reference_dw(book_dw, chapter_dw, startVerse_dw, endVerse_dw);
    }
}