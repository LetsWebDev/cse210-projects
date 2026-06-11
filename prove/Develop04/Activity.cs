// Ref1 BraveAI helped me understand TryParse()
// No link availabe for BraveAI

class DW_Activity
{
    protected static Random DW_r = new Random();

    string dw_startMessage;
    protected int dw_duration;
    string dw_activityName;
    protected DateTime dw_endTime;

    protected List<string> dw_responses;

    public DW_Activity(string dwStartMessage, int dwDuration, string dwActivityName)
    {
        dw_startMessage = dwStartMessage;
        dw_duration = dwDuration;
        dw_activityName = dwActivityName;
        dw_responses = new List<string>();
    }

    public void DW_StartSession()
    {
        DW_Print(dw_startMessage);
        DW_Counter(4);
        dw_duration = DW_PromptNum("How long, in seconds, would you like for your session? ");
    }

    public void DW_EndSession()
    {
        DW_Print("\nWell Done!!\n");
        DW_Spinner(3);
        DW_Print($"\nYou have completed another {dw_duration} seconds of the {dw_activityName}.\n");
        DW_Spinner(4);
    }
    
    public void DW_Spinner(int dwNum)
    {
        string[] dw_s = ["\\", "|", "/", "-"];
        DateTime dw_spinTime = new DateTime();
        dw_spinTime = DateTime.Now.AddSeconds(dwNum);
        for(int i = 0; DateTime.Now < dw_spinTime; i++)
        {
            Console.Write(dw_s[i%4]);
            Thread.Sleep(300);
            Console.Write($"\b \b");
        }
        

        /*
        for (int i = 0; i < dwNum*3; i++)
        {
            Console.Write(dw_s[i%4]);
            Thread.Sleep(200);
            Console.Write($"\b \b");
        }
        */
    }

    public void DW_Counter(int dwNum)
    {
        for (int i = dwNum; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write($"\b \b");
        }
    }

    public List<string> DW_GetNewLog()
    {
        return dw_responses;
    }

    public int DW_PromptNum(string dwMessage)
    {
        int dw_num;
        string dw_answer;
        //Ref1
        do
        {
            dw_answer = DW_Prompt(dwMessage);
        } while(!int.TryParse(dw_answer, out dw_num));

        return dw_num;
    }

    public string DW_Prompt(string dwMessage)
    {
        Console.Write(dwMessage);
        return Console.ReadLine();
    }

    public void DW_Print(string dwMessage)
    {
        Console.Write(dwMessage);
    }
    public void DW_Clear()
    {
        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.Clear();
        Console.Write("\n\n\n");
    }

    public virtual void DW_Breath(){}
    public virtual void DW_Reflect(){}
    public virtual void DW_List(){}
    public virtual void DW_SaveList(){}
}