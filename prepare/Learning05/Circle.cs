class DW_Circle : DW_Shape
{
    double dw_radius;

    public DW_Circle(string dwcolor, double dwradius) : base(dwcolor)
    {
        dw_radius = dwradius;
    }

    public override double DW_GetArea()
    {
        return Math.PI*Math.Pow(dw_radius,2);
    }
}