public abstract class DW_Shape
{
    private string dw_color;

    public DW_Shape(string dwcolor)
    {
        dw_color = dwcolor;
    }

    public string DW_GetColor()
    {
        return dw_color;
    }

    public void DW_SetColor(string dwcolor)
    {
        dw_color = dwcolor;
    }
    
    public abstract double DW_GetArea();
}