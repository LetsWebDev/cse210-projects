class DW_Reflecting:DW_Activity
{
    List<string> dw_prompts;
    List<string> dw_questions;
    public DW_Reflecting(string dwStartMessage, int dwDuration, string dwEndMessage):base(dwStartMessage, dwDuration, dwEndMessage)
    {
        dw_prompts = new List<string> 
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Recall a moment when you overcame a significant fear.",
            "Think of a time when you showed patience in a frustrating situation.",
            "Remember a time when you bounced back from a failure.",
            "Think of a time when you had to make a tough ethical choice."
        }; 
        dw_questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "Who else was impacted by your actions in this moment?",
            "What strength did you rely on the most during this time?"
        };   
    }  

    public override void DW_Reflect()
    {
        int dw_num;
        string dw_str;

        DW_Print("Consider the Following prompt\n");
        dw_num = DW_Activity.DW_r.Next(dw_prompts.Count);
        dw_str = dw_prompts[dw_num];
        DW_Print($" --- {dw_str} ---\n");
        DW_Prompt("When you have something in mind, press enter to contiue.\n");
        DW_Print("Now ponder on each of the following questions as they related to this experience.\nYou may begin in: ");
        DW_Counter(4);
        DW_Clear();
        
        dw_endTime = DateTime.Now.AddSeconds(dw_duration);
        do
        {
            dw_num = DW_Activity.DW_r.Next(dw_questions.Count);
            dw_str = dw_questions[dw_num];
            DW_Print($"> {dw_str}");
            DW_Spinner(8);
            DW_Print("\n");

        }while(dw_endTime > DateTime.Now);

        dw_responses.Add($"Reflecting Activity: {dw_duration}");
    }
}