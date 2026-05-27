//Ref 2: Chatgpt helped me learn the problems in my code.
//I found out that int can not be set to null. They default to zero.
//It also caught that I forgot to add "-" to "John 10:13" --> "John 10:1-3"
//https://chatgpt.com/s/t_6a1603f4504881919e5becc9bb1e09f7

class Reference_dw
{
    private string book_dw;
    private int chapter_dw;
    private int startVerse_dw;
    private int endVerse_dw;

    public Reference_dw(string newbook_dw, int newchapter_dw, int newstartVerse_dw)
    {
        book_dw = newbook_dw;
        chapter_dw = newchapter_dw;
        startVerse_dw = newstartVerse_dw;
        endVerse_dw = startVerse_dw;
    }
    public Reference_dw(string newbook_dw, int newchapter_dw, int newstartVerse_dw, int newendVerse_dw)
    {
        book_dw = newbook_dw;
        chapter_dw = newchapter_dw;
        startVerse_dw = newstartVerse_dw;
        endVerse_dw = newendVerse_dw;
    }
    public override string ToString()
    {
        string output_dw = $"{book_dw} {chapter_dw}:{startVerse_dw}";
        if(startVerse_dw != endVerse_dw)
        {
            output_dw += "-" + endVerse_dw;
        }
        return output_dw;
    }
}