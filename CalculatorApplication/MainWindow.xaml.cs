using System.Windows;
using System.Windows.Controls;

namespace CalculatorApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator SelectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            btnAC.Click += BtnAC_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercentage.Click += BtnPercentage_Click;
            btnEquals.Click += BtnEquals_Click;
        }

        // Equals button
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                // Switch statement to determine which operator was selected
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                lblResult.Content = result.ToString();
            }
        }

        // Percentage button
        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                lblResult.Content = tempNumber.ToString();
            }
        }

        // Converting selected button to a negative
        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                // Multiplying last number to -1 to convert to a negative
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }
        }

        // Clear button
        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
            result = 0;
            lastNumber = 0;

        }

        // Operation button
        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "0";
            }

            // Determining which operator was chosen
            if (sender == btnAdd)
                SelectedOperator = SelectedOperator.Addition;
            if (sender == btnSubtract)
                SelectedOperator = SelectedOperator.Subtraction;
            if (sender == btnMultiply)
                SelectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivide)
                SelectedOperator = SelectedOperator.Division;

        }

        // Decimal button
        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {
                // Do Nothing
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}.";
            }
        }

        // Number button
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (sender == btnZero)
                selectedValue = 0;
            if (sender == btnOne)
                selectedValue = 1;
            if (sender == btnTwo)
                selectedValue = 2;
            if (sender == btnThree)
                selectedValue = 3;
            if (sender == btnFour)
                selectedValue = 4;
            if (sender == btnFive)
                selectedValue = 5;
            if (sender == btnSix)
                selectedValue = 6;
            if (sender == btnSeven)
                selectedValue = 7;
            if (sender == btnEight)
                selectedValue = 8;
            if (sender == btnNine)
                selectedValue = 9;


            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                // Adds 7 to the information output
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }

    // Enum method to return selected operator
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    // Math class for calculation
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Cannot divide by 0", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }
}
