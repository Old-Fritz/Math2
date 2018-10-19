using System;

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
            result.Text = method.calculate(x => array.get(0).Func(x), 2).ToString();
        }
    }
}