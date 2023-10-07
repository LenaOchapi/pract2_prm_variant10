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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int[] array = Array.ConvertAll(InputTextBox.Text.Split(' '), int.Parse);
            if (array.Length < 10)
            {
                MessageBox.Show("Недостаточное количество элементов массива!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int result = FindElement(array);
            if (result != -1)
            {
                OutputListBox.Items.Add($"Найден элемент: {array[result]}, его индекс: {result}");
            }
            else
            {
                OutputListBox.Items.Add("0");
            }
        }

        private int FindElement(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[0] && array[i] < array[9])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
