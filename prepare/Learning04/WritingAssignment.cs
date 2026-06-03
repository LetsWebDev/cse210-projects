using System.Runtime.InteropServices.Swift;

class DW_WritingAssignment:DW_Assignment
{
    string dw_title;

    public DW_WritingAssignment(string dwName, string dwTopic, string dwTitle):base(dwName, dwTopic)
    {
        dw_title = dwTitle;
    }

    public string DW_GetWritingInformation()
    {
        return $"{dw_title} by {DW_GetName()}";
    }
}
