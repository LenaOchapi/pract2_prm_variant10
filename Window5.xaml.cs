using System;
using System.Collections.Generic;
using System.Data.Common;
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

/// НЕ РАБОТАЕТ СОРТИРОВКА!!!5ая задача не доделана,с ней я ещё буду разбираться

namespace pract2_prm_variant10
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            int columns = int.Parse(tbColumns.Text);
            int rows = int.Parse(tbRows.Text);

            int[,] matrix = GenerateRandomMatrix(columns, rows, -10, 10);

            PopulateDataGrid(matrix, dataGrid);
            int[,] sortedAsc = SortMatrixAscending(matrix);
            PopulateDataGrid(sortedAsc, dataGridVoz);
            int[,] sortedDesc = SortMatrixDescending(matrix);
            PopulateDataGrid(sortedDesc, dataGridUb);
        }
        private int[,] GenerateRandomMatrix(int columns, int rows, int minValue, int maxValue)
        {
            int[,] matrix = new int[columns, rows];
            Random random = new Random();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }

            return matrix;
        }

        private void PopulateDataGrid(int[,] matrix, DataGrid dataGrid)
        {
            int columns = matrix.GetLength(0);
            int rows = matrix.GetLength(1);

            dataGrid.Columns.Clear();
            dataGrid.Items.Clear();

            for (int i = 0; i < columns; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn()
                {
                    Header = $"Column {i + 1}",
                    Binding = new System.Windows.Data.Binding($"[{i}]")
                };
                dataGrid.Columns.Add(column);
            }

            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>();

                for (int j = 0; j < columns; j++)
                {
                    row.Add(matrix[j, i]);
                }
                dataGrid.Items.Add(row);
            }
        }

        private int[,] SortMatrixAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[] flatArray = new int[rows * columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flatArray[i * columns + j] = matrix[i, j];
                }
            }

            Array.Sort(flatArray);

 
            int[,] sorted = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sorted[i, j] = flatArray[i * columns + j % columns + (j / columns)];
                }
            }

            return sorted;
        }

        private int[,] SortMatrixDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);


            int[] flatArray = new int[rows * columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flatArray[i * columns + j] = matrix[i, j];
                }
            }


            Array.Sort(flatArray);
            Array.Reverse(flatArray);

            int[,] sorted = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sorted[i, j] = flatArray[i * columns + j % columns + (j / columns)];
                }
            }

            return sorted;
        }

    }
}
