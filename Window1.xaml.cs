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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void FindRepeatedDigitsButton_Click(object sender, RoutedEventArgs e)
        {
            long number;
            if (long.TryParse(NumberTextBox.Text, out number))
            {
                List<int> digits = new List<int>();
                while (number > 0)
                {
                    long digit = number % 10;
                    digits.Add((int)digit);
                    number /= 10;
                }

                var repeatedDigits = digits.GroupBy(x => x)
                                          .Where(x => x.Count() > 1)
                                          .Select(x => x.Key)
                                          .ToList();

                DigitListBox.ItemsSource = repeatedDigits;
                ResultTextBlock.Text = "Повторяющиеся числа: " + string.Join(", ", repeatedDigits);
            }
            else
            {
                ResultTextBlock.Text = "неправельный ввод!";
            }
        }
    }
 
}
