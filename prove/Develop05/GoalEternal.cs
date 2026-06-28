class DW_EternalGoal:DW_Goal
{
    public DW_EternalGoal(string name, string description, int points):base(name, description, points){}
    
    public override void DW_RecordEvent()
    { 
        DW_AwardPoints(dw_points);
    }

    public override void DW_UndoEvent()
    {
        DW_AwardPoints(-dw_points);
    }

    public override string DW_GetClassValues()
    {
        return $"EternalGoal\\{dw_name}\\{dw_description}\\{dw_points}";
    }

    public override string DW_ToString()
    {
        return $"[ ] {dw_name} ({dw_description})";
    }
}