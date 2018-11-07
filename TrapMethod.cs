using System;

public class TrapMethod
{
    public delegate double FuncDel(double x);

    public double calculate(FuncDel f, double a, double b, double precision, out double fault, out int split)
    {   
        double S1, S2;
        split = 1;
        S2 = calcS(f, a, b, split);
        do
        {
            S1 = S2;
            split *= 2;
            S2 = calcS(f, a, b, split);
        } while (Math.Abs(S2-S1)>precision && split<10000000);

        fault = Math.Abs(S2-S1);  // оценка Рунге

        return S2;
    }

    private double calcS(FuncDel f, double a, double b, int split)
    {
        // Вычисление площади трапеций
        double S = 0;
        double dX = (b - a) / split;
        double y1 = f(a);
        for (int i = 0; i < split; i++)
        {
            double y2 = f(a + dX * (i + 1));
            S += (y1 + y2) / 2.0f * dX;
            y1 = y2;
        }

        return S;
    }
}