using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Function m_checkedFunction = null;
        private FunctionsArray m_functionsArray;
        private TrapMethod m_method;


        public MainWindow()
        {
            InitializeComponent();
            m_method = new TrapMethod();
            m_functionsArray = new FunctionsArray();
            // Добавление всех функций в интерфейс
            for(int i = 0;i<m_functionsArray.size();i++)
                addFunction(m_functionsArray.get(i));
        }

        private void addFunction(Function fun)
        {
            // Добавление функции в интерфейс
            RadioButton rb = new RadioButton {IsChecked = false, GroupName = "functionsCheck", Content = fun.Name};
            rb.Checked += functionChoose;
            functionStack.Children.Add(rb);
        }

        private void inputCorrect(object sender, TextChangedEventArgs e)
        {
            string newText = ((TextBox) sender).Text;

            //Удаление лишних символов
            Regex rgx = new Regex("[^-0-9,.]");
            newText = rgx.Replace(newText, "");
            rgx = new Regex("[.]");
            newText = rgx.Replace(newText, ",");
            
	        // Удаление лишних точек
            while(true)
            {
                int ind1 = newText.IndexOf(',');
                if(ind1>=0)
                {
                    int ind2 = newText.IndexOf(',',ind1+1);
                    if (ind2 > 0 || ind1 == 0)
                        newText = newText.Remove(ind1, 1);
                    else
                        break;
                }
                else
                    break;
            }
	
            // Удаление лишних '-'
            while(true)
            {
                int ind1 = newText.IndexOf('-');
                if(ind1==0)
                {
                    int ind2 = newText.IndexOf('-', ind1+1);
                    if(ind2>0)
                        newText = newText.Remove(ind2,1);
                    else
                        break;
                }
                else if(ind1>0)
                    newText = newText.Remove(ind1,1);
                else
                    break;
            }

            //((TextBox) sender).
            ((TextBox) sender).Text = newText;
        }

        private void calculate(object sender, RoutedEventArgs routedEventArgs)
        {
            // Отказ от  вычисления, если одно из полей не заполнено
            if (tLowLimit.Text.Length == 0 || tUpLimit.Text.Length == 0 || tPrecision.Text.Length == 0)
            {
                MessageBox.Show("Зваолните все поля");
                return;
            }

            double lowLimit = Double.Parse(tLowLimit.Text);
            double upLimit = Double.Parse(tUpLimit.Text);
            double precision = Double.Parse(tPrecision.Text);

            if (precision <=0)
            {
                MessageBox.Show("Нулевая или отрицательная погрешность технически нереализуема, измените значение");
                return;
            }

            // Отказ от вычисления при отстутствии выбранной функции
            if (m_checkedFunction == null)
            {
                MessageBox.Show("Выберерите интегрируемую функцию");
                return;
            }

            // Вычисление результата
            double fault;
            int split;
            double result = m_method.calculate(x => m_checkedFunction.Func(x),
                lowLimit, upLimit, precision, out fault, out split);

            tResult.Text = result.ToString();
            tFault.Text = fault.ToString();
            tSplit.Text = split.ToString();

        }

        private void functionChoose(object sender, RoutedEventArgs routedEventArgs)
        {
            // Поиск функции по имени
            string functionName = ((RadioButton) sender).Content.ToString();
            for (int i = 0; i < m_functionsArray.size(); i++)
            {
                if (m_functionsArray.get(i).Name.Equals(functionName))
                    m_checkedFunction = m_functionsArray.get(i);
            }
        }

        private void checkInput(object sender, RoutedEventArgs e)
        {
            string newText = ((TextBox) sender).Text;
            
            // Удаление - или . в конце строки
            if (newText.Length == 0)
                return;
            char lastSym = newText[newText.Length-1];
            if (lastSym == '-' || lastSym == ',')
                newText =  newText.Remove(newText.Length - 1);
            
            ((TextBox) sender).Text = newText;
        }
    }
}