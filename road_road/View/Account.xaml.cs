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
 
        public Account(string login)
        {
            InitializeComponent();
            TB_login.Text = login;
        }

        private void but_main(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();

        }

        private void Load_data()
        {
            //AuthenticationService.Login_UQ(TB_login.Text.Trim());
            Users user = new Users();
            TB_login.Text = user.Login;
        }


        

        
    }
}
