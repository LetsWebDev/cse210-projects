
class DW_SimpleGoal:DW_Goal
{
    bool dw_isComplete;
    public DW_SimpleGoal(string name, string description, int points, bool isComplete):base(name, description, points)
    {
        dw_isComplete = isComplete;
    }
    
    public override void DW_RecordEvent()
    { 
        DW_AwardPoints(dw_points);
        dw_isComplete = true;
    }

    public override void DW_UndoEvent()
    {
        DW_AwardPoints(-dw_points);
        dw_isComplete = false;
    }

    public override string DW_GetClassValues()
    {
        return $"SimpleGoal\\{dw_name}\\{dw_description}\\{dw_points}\\{dw_isComplete}";
    }

    public override string DW_ToString()
    {
        if (dw_isComplete)
        {
            return $"[/] {dw_name} ({dw_description})";
        }
        else
        {
            return $"[ ] {dw_name} ({dw_description})"; 
        }
    }
}
