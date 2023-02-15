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
            if (AuthenticationController.Avtorisation(L_login.Text.Trim(), L_password.Text.Trim()))
            {
                Admin account = new Admin();
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
            registration reg = new registration();
            reg.Show();
            this.Close();
        }
    }
}
