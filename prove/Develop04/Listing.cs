class DW_Listing : DW_Activity
{
    List<string> dw_prompts;

    public DW_Listing(string dwStartMessage, int dwDuration, string dwEndMessage):base(dwStartMessage, dwDuration, dwEndMessage)
    {
        dw_prompts = new List<string> 
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are simple things in your home that give you comfort?",
            "What are talents or skills you are grateful to have?",
            "Who are people that make you laugh?",
            "What are challenges you have overcome that made you stronger?",
            "What are good things that happened to you unexpectedly this week?"
        };
    }

    public override void DW_List()
    {

        int dw_num;
        string dw_str;
        string dw_response;

        DW_Print("List as many responses you can to the following prompt:\n");
        dw_num = DW_Activity.DW_r.Next(dw_prompts.Count);
        dw_str = dw_prompts[dw_num];
        DW_Print($" --- {dw_str} ---\n");
        DW_Print("You may begin in: \n");
        DW_Counter(6);
        
        dw_endTime = DateTime.Now.AddSeconds(dw_duration);
        do
        {
            dw_response = DW_Prompt($"> ");
            dw_responses.Add(dw_response);
        }while(dw_endTime > DateTime.Now);

        DW_Print($"You listed {dw_responses.Count} items!\n");


        dw_responses.Insert(0,dw_str);
        DW_SaveList();
    }
}