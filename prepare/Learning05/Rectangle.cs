class DW_Rectangle:DW_Shape
{
    double dw_length;
    double dw_width;

    public DW_Rectangle(string dwcolor, double dwlength, double dwwidth): base(dwcolor)
    {
        dw_length = dwlength;
        dw_width = dwwidth;
    }

    public override double DW_GetArea()
    {
        return dw_length*dw_width;
    }
}