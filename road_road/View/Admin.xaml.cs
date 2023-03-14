using road_road.Data.Models;
using System;
using System.Linq;
using System.Windows;

namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        static private DBContext context = new DBContext();
        string log;
        AdminWindow admin;
        public Admin(string login, AdminWindow admin)
        {
            InitializeComponent();
            log = login;
            this.admin = admin;
            Load_data();
            GenderID();
            RoleID();
        }
        private void Load_data()
        {            
            var user = context.Users.SingleOrDefault(x => x.Login == log);
            CB_gender.SelectedIndex = Convert.ToInt32(user.IdGender) - 1;
            CB_role.SelectedIndex = Convert.ToInt32(user.IdRole) - 1;
            TB_login.Text = user.Login;
            TB_firstname.Text = user.FirstName;
            TB_secondname.Text = user.SecondName;
            TB_lastname.Text = user.LastName;
            TB_password.Text = user.Password;
            DP_DateOfBers.SelectedDate = user.DateOfBers;
            TB_telephone.Text = user.Telephone;
            TB_email.Text = user.EMail;
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

        private void Edit_But(object sender, RoutedEventArgs e)
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
            else if (DP_DateOfBers.SelectedDate == null)
            {
                MessageBox.Show("Поле Дата рождения не заполненно");
            }

            else 
            {
                var user = context.Users.SingleOrDefault(x => x.Login == log);
                user.Login = TB_login.Text.Trim();
                user.FirstName = TB_firstname.Text.Trim();
                user.SecondName = TB_secondname.Text.Trim();
                user.LastName = TB_lastname.Text.Trim();
                user.Password = TB_password.Text.Trim();
                user.IdGender = CB_gender.SelectedIndex + 1;
                user.IdRole = CB_role.SelectedIndex + 1;
                user.DateOfBers = DP_DateOfBers.SelectedDate;
                user.Telephone = TB_telephone.Text.Trim();
                user.EMail = TB_email.Text.Trim();
                context.SaveChanges();
                admin.Date_Users();
                this.Close();
            }
        }
        private void Delete_But(object sender, RoutedEventArgs e)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == log);
            context.Remove(user);
            context.SaveChanges();
            admin.Date_Users();
            this.Close();
        }
    }
}
