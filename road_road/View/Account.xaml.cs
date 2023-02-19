using System.Linq;
using System.Windows;
using System.Windows.Controls;
using road_road.Data.Models;


namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
 
        public Account()
        {
            InitializeComponent();
        }

        private void but_main(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();

        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
    }
}
