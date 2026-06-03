class DW_Assignment
{
    private string dw_studentName;
    private string dw_topic;

    public DW_Assignment(string dwName, string dwTopic)
    {
        dw_studentName = dwName;
        dw_topic = dwTopic;
    }

    public string DW_GetName()
    {
        return dw_studentName;
    }

    public string DW_GetTopic()
    {
        return dw_topic;
    }

    public string DW_GetSummery()
    {
        return $"{dw_studentName} - {dw_topic}";
    }
}