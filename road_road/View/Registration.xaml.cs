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
            RoleID();
            
        }

        private void GenderID()
        {
            var gender = AuthenticationService.GenderID();

            foreach (var i in gender)
                CB_gender.Items.Add(i.NameOfGender);
        }
        private void RoleID()
        {
            var role = AuthenticationService.RoleID();

            foreach (var i in role)
                CB_role.Items.Add(i.NameOfRole);
        }
        

        private void Add_But(object sender, RoutedEventArgs e)
        {
            if (AuthenticationService.Login_UQ(TB_login.Text.Trim()))
            {
                if (TB_login.Text == "")
                {
                    MessageBox.Show("Поле логин не заполненно");
                }
                else if (TB_firstname.Text == "")
                {
                    MessageBox.Show("Поле Имя не заполненно");
                }
                else if (TB_secondname.Text == "")
                {
                    MessageBox.Show("Поле Фамилия не заполненно");
                }
                else if (TB_password.Text == "")
                {
                    MessageBox.Show("Поле Пароль не заполненно");
                }
                else if (DP_DateOfBers.SelectedDate == null)
                {
                    MessageBox.Show("Поле Дата рождения не заполненно");
                }
                else
                {
                    Users user = new Users();
                    user.Login = TB_login.Text.Trim();
                    user.FirstName = TB_firstname.Text.Trim();
                    user.SecondName = TB_secondname.Text.Trim();
                    user.LastName = TB_lastname.Text.Trim();
                    user.Password = TB_password.Text.Trim();
                    user.IdGender = CB_gender.SelectedIndex + 1;
                    user.IdRole = CB_role.SelectedIndex + 1;
                    user.DateOfBers = DP_DateOfBers.SelectedDate;
                    user.Telephone = TB_telephone.Text.Trim();
                    user.EMail= TB_email.Text.Trim();
                    AuthenticationService.Registration(user);
                    admin.Date_Users();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неправильно введён логин или пароль");
            }
            
        }
    }
}
