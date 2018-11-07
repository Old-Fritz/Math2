using System;
using System.Collections.Generic;
using static System.Math;

namespace WpfApplication1
{
    public class FunctionsArray
    {
        public FunctionsArray()
        {
            array = new List<Function>();;
            array.Add(new Function("x^2", (x => x * x)));
            array.Add(new Function("sqrt(|cos(x^2)|)", (x => Sqrt(Abs(Cos(x*x))))));
            array.Add(new Function("ln(2x)*tg(7^(x/300))", (x => Log(2*x)*Tan(Pow(7,x/300)))));
            array.Add(new Function("65x^4+12x^3-6x^2-5x+532", (x => 65*Pow(x,4)+12*Pow(x,3)-6*x*x-5*x+532)));
            array.Add(new Function("e^(cosx)", (x => Exp(Cos(x)))));
        }
        
        private List<Function> array;

        public Function get(int index)
        {
            if (array.Count > index && index >=0)
                return array[index];
            return null;
        }

        public int size()
        {
            return array.Count;
        }
    }
}