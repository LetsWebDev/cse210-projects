using System.Formats.Tar;

abstract class DW_Goal
{
    static int dw_score;
    static List<DW_Goal> dw_goals = new List<DW_Goal>();
    
    
    static public void DW_AwardPoints(int points)
    {
        dw_score += points;
    }

    static public int DW_GetScore()
    {
        return dw_score;
    }




    static public void DW_CreateSimpleGoal(string name, string description, int points, bool isComplete)
    {
        dw_goals.Add(new DW_SimpleGoal(name, description, points, isComplete));
    }

    static public void DW_CreateEternalGoal(string name, string description, int points)
    {
        dw_goals.Add(new DW_EternalGoal(name, description, points));
    }

    static public void DW_CreateCheckListGoal(string name, string description, int points, int target, int completion, int bonus)
    {
        dw_goals.Add(new DW_CheckListGoal(name, description, points, target, completion, bonus));
    }

    static public void DW_RemoveGoal(int index)
    {
        dw_goals.RemoveAt(index);
    }
    


    static public void DW_ListGoals()
    {
        foreach (DW_Goal dw_goal in dw_goals)
        {
            Help.Print($"{dw_goals.IndexOf(dw_goal) + 1} {dw_goal.DW_ToString()}");
        }
    }

    static public List<string> DW_GetAllClassValues()
    {
        List<string> dw_list = new List<string>();
        foreach (DW_Goal dw_goal in dw_goals)
        {
            dw_list.Add(dw_goal.DW_GetClassValues());
        }
        return dw_list;
    }

    static public void DW_SaveGoals(string fileName)
    {
        List<string> dw_fileLines = DW_GetAllClassValues();
        dw_fileLines.Insert(0,dw_score.ToString());
        File.WriteAllLines(fileName + ".txt", dw_fileLines);
    }

    static public void DW_LoadGoals(string dw_fileName)
    {
        dw_goals = new List<DW_Goal>();
        string[] dw_fileLines = File.ReadAllLines(dw_fileName + ".txt");
        dw_score = int.Parse(dw_fileLines[0]);
        dw_fileLines = dw_fileLines.Skip(1).ToArray();
        foreach (string dw_line in dw_fileLines)
        {
            string[] dw_ClassValues = dw_line.Split("\\");
            if(dw_ClassValues[0] == "SimpleGoal")
            {
                DW_Goal.DW_CreateSimpleGoal(dw_ClassValues[1], dw_ClassValues[2], int.Parse(dw_ClassValues[3]), bool.Parse(dw_ClassValues[4]));
            }
            else if(dw_ClassValues[0] == "EternalGoal")
            {
                DW_Goal.DW_CreateEternalGoal(dw_ClassValues[1], dw_ClassValues[2], int.Parse(dw_ClassValues[3]));  
            }
            else if(dw_ClassValues[0] == "CheckListGoal")
            {
                DW_Goal.DW_CreateCheckListGoal(dw_ClassValues[1], dw_ClassValues[2], int.Parse(dw_ClassValues[3]), int.Parse(dw_ClassValues[4]), int.Parse(dw_ClassValues[5]), int.Parse(dw_ClassValues[6]));
            }
        }
    }
    
    static public void DW_RecordAnEvent(int index)
    {
        dw_goals[index].DW_RecordEvent();
    }

    static public void DW_UndoAnEvent(int index)
    {
        dw_goals[index].DW_UndoEvent();
    }



    //
    //
    //  Protected and Public
    //
    //

    protected string dw_name;
    protected string dw_description;
    protected int dw_points;

    public DW_Goal(string name, string description, int points)
    {
        dw_name = name;
        dw_description = description;
        dw_points = points;
    }

    
    public abstract void DW_RecordEvent();
    public abstract void DW_UndoEvent();
    public abstract string DW_ToString();
    public abstract string DW_GetClassValues();
}