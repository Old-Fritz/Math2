
using System;

public class TrapMethod
{
    public delegate double FuncDel(double x);

    public double calculate(FuncDel f, FuncDel dderivative, double a, double b, double precision, out double fault, out int split)
    {
        if (b < a)
        {
            double temp = a;
            a = b;
            b = temp;
        }
        
        double S1, S2;
        split = 1;
        S2 = calcS(f, a, b, split);
        do
        {
            S1 = S2;
            split *= 2;
            S2 = calcS(f, a, b, split);
        } while (Math.Abs(S2-S1)>precision);

        fault = calcFault(dderivative,a,b,split);

        return S2+fault;
    }

    private double calcS(FuncDel f, double a, double b, int split)
    {
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

    private double calcFault(FuncDel dderivative, double a, double b, int split)
    {
        return (-dderivative((b - a) / 2) * split * Math.Pow((b - a)/split,3)) / 12;
    }
}