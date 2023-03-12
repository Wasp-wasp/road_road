using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace road_road.View
{
    public partial class Autorisation : Window
    {
        string login;
        public Autorisation()
        {
            InitializeComponent();
        }
        
        private void BC_enter(object sender, RoutedEventArgs e)
        {
            login = L_login.Text.Trim();
            if (AuthenticationService.Autorisation(login, L_password.Text.Trim()))
            {                
                Account account = new Account(login);
                account.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введён логин или пароль");
            }
        }
    }
}
