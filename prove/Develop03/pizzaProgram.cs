/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction DW_pizza = new Fraction(3,4);
        Random DW_slice = new Random();

        DW_print(DW_pizza.DW_GetFractionString());

        DW_pizza.DW_SetFraction(1,1);
        DW_print(DW_pizza.DW_GetDecimalValue());

        DW_pizza.DW_SetFraction(10,2);
        DW_print(DW_pizza.DW_GetDecimalValue());
        
        DW_pizza.DW_SetFraction(3,4);
        DW_print(DW_pizza.DW_GetFractionString());

        DW_pizza.DW_SetFraction(1,3);
        DW_print(DW_pizza.DW_GetFractionString());

        for (int i = 0; i<20; i++)
        {
            DW_pizza.DW_SetTop(DW_slice.Next(0,14));
            DW_pizza.DW_SetBottom(DW_slice.Next(1,14));
            string DW_string = DW_pizza.DW_GetFractionString();
            double DW_decimal = DW_pizza.DW_GetDecimalValue();
            DW_print($"Fraction {i}: string: {DW_string} Number: {DW_decimal}");
        }

    }
    static void DW_print(object DW_text)
    {
        Console.WriteLine(DW_text);
    }
}
*/