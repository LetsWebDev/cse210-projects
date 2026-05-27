//Ref 1: Chatgpt helped me learn the problems in my code.
//https://chatgpt.com/s/t_6a1600d4008c81918352f88f5af9edb6

class Word_dw
{
    private string word_dw;
    private string hint_dw;
    private bool isHidden_dw;

    public Word_dw(string input_dw)
    {
        word_dw = input_dw;
        hint_dw = "";
        //Ref 1
        for (int i=0; i<input_dw.Length; i++)
        {
            hint_dw += "_";
        }

        isHidden_dw = false;
    }
    public void SetHidden_dw(bool input_dw)
    {
        isHidden_dw = input_dw;
    }
    public bool GetHidden_dw()
    {
        return isHidden_dw;
    }

    //Ref 1
    public override string ToString()
    {
        if (isHidden_dw)
        {
            return hint_dw;
        }
        else
        {
            return word_dw;
        }
    }
}