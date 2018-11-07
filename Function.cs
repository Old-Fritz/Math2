namespace WpfApplication1
{
    public class Function
    {
        public string Name { get; }
        public delegate double FuncDel(double x);
        public FuncDel Func { get; }
        
        public Function(string name, FuncDel f)
        {
            Name = name;
            Func = f;
        }
    }
}