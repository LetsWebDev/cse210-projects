class DW_MathAssignment:DW_Assignment
{
    string dw_textbookSection;
    string dw_problems;
    
    public DW_MathAssignment(string dwName, string dwTopic, string dwTextbook, string dwProblems):base(dwName, dwTopic)
    {
        dw_textbookSection = dwTextbook;
        dw_problems = dwProblems;
    }

    public string DW_GetHomeworkList()
    {
        return $"Section {dw_textbookSection} Problems {dw_problems}";
    }
}