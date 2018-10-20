using System.Collections.Generic;

namespace WpfApplication1
{
    public class FunctionsArray
    {
        public FunctionsArray()
        {
            array = new List<Function>();
            Function func = new Function("x*x", (x => x * x), (x=>2));
            array.Add(func);
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