using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace road_road.View
{
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }
        
        private void BC_enter(object sender, RoutedEventArgs e)
        {
            if (AuthenticationService.Autorisation(L_login.Text.Trim(), L_password.Text.Trim()))
            {
                Account account = new Account();
                account.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введён логин или пароль");
            }
        }

        

        private void BC_reg(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}
