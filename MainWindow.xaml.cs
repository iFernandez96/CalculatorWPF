using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double prevNum, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (labelResult.Content.ToString().Contains("."))
            {
                //Do nothing
            }
            else
            {
                labelResult.Content = $"{labelResult.Content}.";
            }

        }


        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            double NewNum;
            if (double.TryParse(labelResult.Content.ToString(), out NewNum))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMaths.Add(prevNum,NewNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMaths.Subtraction(prevNum,NewNum);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMaths.Multiplication(prevNum,NewNum);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMaths.Division(prevNum,NewNum);
                        break;
                    case SelectedOperator.Mod:
                        result = SimpleMaths.Modulus(prevNum,NewNum);
                        break;

                }
                labelResult.Content = result.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        { 
            if (double.TryParse(labelResult.Content.ToString(), out prevNum))
            {
                labelResult.Content = "0";      
            }
            if (sender == buttonMultiplication)
                selectedOperator = SelectedOperator.Multiplication;
            else if (sender == buttonDivision)
                selectedOperator = SelectedOperator.Division;
            else if (sender == buttonAddition)
                selectedOperator = SelectedOperator.Addition;
            else if (sender == buttonSubtraction)
                selectedOperator = SelectedOperator.Subtraction;
            else if (sender == buttonMod)
                selectedOperator = SelectedOperator.Mod;
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResult.Content.ToString(), out prevNum))
            {
                prevNum = prevNum * -1;
                labelResult.Content = prevNum.ToString();
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            labelResult.Content= "0";
            result = 0;
            prevNum = 0;
        }


        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse(((Button)sender).Content.ToString());

            if (labelResult.Content.ToString() != "0")
                labelResult.Content = $"{labelResult.Content}{selectedValue}";
            else
                labelResult.Content = $"{selectedValue}";
        }
    }
    public enum SelectedOperator
    {
        Multiplication,
        Division,
        Addition,
        Subtraction,
        Mod
    }

    public class SimpleMaths
    {
        public static double Add(double n1, double n2)
        { 
            return n1 + n2; 
        }
        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Cannot divide by 0!", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
        
        public static double Modulus(double n1, double n2)
        { 
            return n1 % n2;
        }
    }
}
