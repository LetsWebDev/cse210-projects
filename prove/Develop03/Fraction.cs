class Fraction
{
    public int DW_top;
    public int DW_bottom;
    public Fraction()
    {
        DW_top = 1;
        DW_bottom = 1;
    }
    public Fraction(int DW_number)
    {
        DW_top = DW_number;
        DW_bottom = 1;
    }
    public Fraction(int DW_topNumber, int DW_bottomNumber)
    {
        DW_top = DW_topNumber;
        DW_SetBottom(DW_bottomNumber);
    }

    public int DW_GetTop()
    {
        return DW_top;
    }
    public void DW_SetTop(int DW_number)
    {
        DW_top = DW_number;
    }

    public int DW_GetBottom()
    {
        return DW_bottom;
    }
    public void DW_SetBottom(int DW_number)
    {
        if (DW_number != 0)
        {
            DW_bottom = DW_number;
        }
        else
        {
            DW_bottom = 1;
        }
    }

    public void DW_SetFraction(int DW_topNumber, int DW_bottomNumber)
    {
        DW_top = DW_topNumber;
        DW_SetBottom(DW_bottomNumber);
    }

    public string DW_GetFractionString()
    {
        return $"{DW_top}/{DW_bottom}";
    }
    public double DW_GetDecimalValue()
    {
        return (double)DW_top/DW_bottom;
    }
}