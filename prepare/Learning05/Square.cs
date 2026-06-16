class DW_Square:DW_Shape
{
    double dw_side;

    public DW_Square(string dwcolor, double dwside):base(dwcolor)
    {
        dw_side = dwside;
    }

    public override double DW_GetArea()
    {
        return dw_side*dw_side;
    }
}