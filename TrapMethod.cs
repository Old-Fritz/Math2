
using System;

public class TrapMethod
{
    public delegate double FuncDel(double x);

    public double calculate(FuncDel f, double x)
    {
        return f(x);
    }
}