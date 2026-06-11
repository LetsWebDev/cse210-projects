class DW_Breathing : DW_Activity
{
    public DW_Breathing(string dwStartMessage, int dwDuration, string dwEndMessage):base(dwStartMessage, dwDuration, dwEndMessage)
    {
        
    }    

    public override void DW_Breath()
    {
        dw_endTime = DateTime.Now.AddSeconds(dw_duration);
        do
        {
            DW_Print("Breath in...\n");
            DW_Counter(3);
            DW_Print("Breath out...\n");
            DW_Counter(3);
            DW_Print("\n");
        }while(dw_endTime > DateTime.Now);
        
        dw_responses.Add($"Breathing Activity: {dw_duration}");
    }
}