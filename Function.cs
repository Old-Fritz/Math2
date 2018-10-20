using System;

namespace WpfApplication1
{
    public class Function
    {
        public string Name { get; }
        public delegate double FuncDel(double x);
        public FuncDel Func { get; }
        public FuncDel DDerivative { get; }
        
        public Function(string name, FuncDel f,FuncDel d)
        {
            Name = name;
            Func = f;
            DDerivative = d;
        }
    }
}