
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using road_road.Data.Models;


namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        static private roContext context = new roContext();
        private void BC_enter(object sender, RoutedEventArgs e)
        {

            var user = context.Users.SingleOrDefault(x => x.Login == L_login.Text.Trim() && x.Password == L_password.Text.Trim());
            if (user != null)
            {

                Admin account = new Admin();
                account.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Не правельно введён логин или пароль");
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
