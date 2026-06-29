
class DW_CheckListGoal:DW_Goal
{
    int dw_target;
    int dw_completion;
    int dw_bonus;

    public DW_CheckListGoal(string name, string description, int points, int target, int completion, int bonus):base(name, description, points)
    {
        dw_target = target;
        dw_completion = completion;
        dw_bonus = bonus;
    }
    
    public override void DW_RecordEvent()
    { 
        DW_AwardPoints(dw_points);
        dw_completion ++;

        if(dw_completion >= dw_target)
        {
            DW_AwardPoints(dw_bonus);
        }
    }

    public override void DW_UndoEvent()
    {
        if(dw_completion >= dw_target)
        {
            DW_AwardPoints(-dw_bonus);
        }

        DW_AwardPoints(-dw_points);
        dw_completion --;
    }

    public override string DW_GetClassValues()
    {
        return $"CheckListGoal\\{dw_name}\\{dw_description}\\{dw_completion}\\{dw_points}\\{dw_target}\\{dw_bonus}";
    }

    public override string DW_ToString()
    {
        string dw_checkmark = " ";
        if (dw_completion >= dw_target)
        {
            dw_checkmark = "/";
        }
        return $"[{dw_checkmark}] {dw_name} ({dw_description}) --- Completion Percentage: {dw_completion}/{dw_target}"; 
        
    }
}