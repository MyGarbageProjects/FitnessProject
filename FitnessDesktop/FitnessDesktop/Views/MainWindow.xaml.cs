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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = ListView1.ActualWidth;
            //3% оставляем чтоб небыло сдвига.
            double[] widthCol = {
                37 * width / 100,
                20 * width / 100,
                25 * width / 100,
                15 * width / 100 };

            GridView sdf = (ListView1.View as GridView);
            Console.WriteLine();
            for (int i = 0; i < widthCol.Length; i++)
                sdf.Columns[i].Width = widthCol[i];
        }
    }
}
