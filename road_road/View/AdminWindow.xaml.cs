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

namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void BT_people_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Visible;
            DG_smena.Visibility = Visibility.Hidden;
          
        }

       
     
        private void BT_smena_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Visible;
        }

        private void BT_report_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Visible;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Hidden;
        }
    }
}
