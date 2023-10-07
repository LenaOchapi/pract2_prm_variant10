using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pract2_prm_variant10
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите числа в массив.");
                return;
            }

            string[] numbers = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> validNumbers = new List<int>();
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int parsedNumber))
                {
                    validNumbers.Add(parsedNumber);
                }
                else
                {
                    MessageBox.Show("Введите корректные числа.");
                    return;
                }
            }

            int primeNumber = validNumbers.FirstOrDefault(IsPrimeNumber);

            int perfectNumber = validNumbers.FirstOrDefault(IsPerfectNumber);
            int temp = primeNumber;
            primeNumber = perfectNumber;
            perfectNumber = temp;

            List<int> updatedNumbers = new List<int>(validNumbers);
            int primeIndex = updatedNumbers.IndexOf(primeNumber);
            int perfectIndex = updatedNumbers.IndexOf(perfectNumber);
            updatedNumbers[primeIndex] = perfectNumber;
            updatedNumbers[perfectIndex] = primeNumber;

            ResultListBox.Items.Clear();
            foreach (int number in updatedNumbers)
            {
                ResultListBox.Items.Add(number);
            }
        }

        private bool IsPrimeNumber(int number)
        {
            if (number < 1)
                return false;

            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0 & number !=1)
                    return false;
            }

            return true;
        }

        private bool IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                    sum += i;
            }

            return sum == number;
        }
    }
}
