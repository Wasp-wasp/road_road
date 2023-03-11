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

        

        //private void BC_reg(object sender, RoutedEventArgs e)
        //{
        //    Registration reg = new Registration();
        //    reg.Show();
        //    this.Close();
        //}

        private void BC_admin(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Close();
        }
    }
}
