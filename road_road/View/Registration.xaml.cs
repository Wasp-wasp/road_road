using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using road_road.Data.Models;

namespace road_road.View
{
    //работа с интерфейсом
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            GenderID();
        }


        private void GenderID()
        {
            var gender = AuthenticationService.GenderID();

            foreach (var i in gender)
                CB_gender.Items.Add(i.NameOfGender);
        }
        
        private void But_enter(object sender, RoutedEventArgs e)
        {
            Autorisation autorisation = new Autorisation();
            autorisation.Show();
            this.Close();
        }

        private void But_reg(object sender, RoutedEventArgs e)
        {
            if (AuthenticationService.Login_UQ(TB_login.Text.Trim()))
            {
                Users user = new Users();
                user.Login = TB_login.Text.Trim();
                user.FirstName = TB_name.Text.Trim();
                user.SecondName = TB_secondname.Text.Trim();
                user.LastName = TB_patronomic.Text.Trim();
                user.Password = TB_password.Text.Trim();

                user.IdGender = CB_gender.SelectedIndex + 1;
                AuthenticationService.Registration(user);

                Account account = new Account(TB_login.Text);
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
