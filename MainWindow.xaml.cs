using System;
using System.Security.Cryptography.X509Certificates;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TrapMethod method = new TrapMethod();
            FunctionsArray array = new FunctionsArray();
            double fault;
            int split;
            Function f = array.get(0);
            tresult.Text = method.calculate(x => f.Func(x), x=>f.DDerivative(x),
                10,20,0.001f,out fault ,out split).ToString();
            tfault.Text = fault.ToString();
            tsplit.Text = split.ToString();
        }
    }
}