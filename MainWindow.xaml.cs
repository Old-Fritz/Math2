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
            result.Text = method.calculate(x => array.get(0).Func(x), 10,20,0.00000000001f,out fault ,out split).ToString();
        }
    }
}