using System;

class Program
{
    static void Main(string[] args)
    {
        List<DW_Shape> dw_list = new List<DW_Shape>();

        dw_list.Add(new DW_Square("#ffffff", 2));
        dw_list.Add(new DW_Rectangle("#000000", 3,4));
        dw_list.Add(new DW_Circle("#aaaaaa", 5));
        
        foreach (DW_Shape dw_item in dw_list)
        {
            string dw_color = dw_item.DW_GetColor();
            double dw_area = dw_item.DW_GetArea();
            Console.WriteLine(dw_color);
            Console.WriteLine(dw_area);
        }
    }
}