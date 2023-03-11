using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using road_road.Data.Models;

namespace road_road.View
{
    //работа с интерфейсом
    public partial class Registration : Window
    {
        AdminWindow admin;
        public Registration(AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
            GenderID();
            
        }

        private void GenderID()
        {
            var gender = AuthenticationService.GenderID();

            foreach (var i in gender)
                CB_gender.Items.Add(i.NameOfGender);
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
                admin.Date_Users();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введён логин или пароль");
            }
            
        }
    }
}
