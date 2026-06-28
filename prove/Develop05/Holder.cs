/*
class DW_Holder
{
    List<DW_Goal> dw_userGoals;
    int dw_score;
    string dw_filename;

    public DW_Holder()
    {
        dw_userGoals = new List<DW_Goal>();
        dw_score = 0;
        dw_filename = "Holder.txt";
    }

    public void DW_Save(string filename = null)
    {
        //finish
        //string dw_text;


        foreach (DW_Goal dw_goal in dw_userGoals)
        {
            dw_goal.DW_ToString();
            //store data
        }





        if(filename == null)
        {
            filename = dw_filename;
        }

        //File.WriteAllText(filename, dw_text);

        dw_filename = filename;
    }

    public void DW_Load(string filename = null)
    {
        //finsih
        if(filename == null)
        {
            filename = dw_filename;
        }

        string[] dw_file = File.ReadAllLines(filename);

        foreach(string dw_line in dw_file)
        {
            
        }

        dw_filename = filename;        
    }

    public void DW_CreateEternalGoal(string name, string description, int points)
    {
        dw_userGoals.Add(new DW_EternalGoal(name, description, points));
    }
    public void DW_CreateSimpleGoal(string name, string description, int points, bool isComplete)
    {
        dw_userGoals.Add(new DW_SimpleGoal(name, description, points, isComplete));
    }
    public void DW_CreateCheckListGoal(string name, string description, int points, int target, int completion, int bonus)
    {
        dw_userGoals.Add(new DW_CheckListGoal(name, description, points, target, completion, bonus));
    }
}
*/