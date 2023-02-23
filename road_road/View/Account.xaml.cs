using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using road_road.Data.Models;


namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        string log;
        static private DBContext context = new DBContext();

        public Account(string login)
        {
            
            InitializeComponent();
            //TB_login.Text = login;
            log = login;
            GenderID();
            Load_data();
        }


        private void but_main(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();

        }

        private void Load_data()
        {
            //TB_login.Text = AuthenticationService.Load_data(log) + "не робит";

            var user = context.Users.SingleOrDefault(x => x.Login == log);
            int? genderInt = user.IdGender;
            var gender = context.Genders.Where(x => x.IdGender == genderInt).SingleOrDefault();
            TB_login.Text = user.Login;
            TB_name.Text = user.FirstName;
            TB_secondname.Text = user.SecondName;
            TB_patronomic.Text = user.LastName;
            CB_gender.Text = gender.NameOfGender;
            TB_role.Text = user.Password;
            TB_mail.Text = user.EMail;
            TB_telephone.Text = user.Telephone;
        }

        private void GenderID()
        {
            var gender = AuthenticationService.GenderID();

            foreach (var i in gender)
                CB_gender.Items.Add(i.NameOfGender);
        }

        private void But_change_Click(object sender, RoutedEventArgs e)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == log);
            user.Login = TB_login.Text.Trim();
            user.FirstName = TB_name.Text.Trim();
            user.SecondName = TB_secondname.Text.Trim();
            user.LastName = TB_patronomic.Text.Trim();
            user.Password = TB_role.Text.Trim();
            user.IdGender = CB_gender.SelectedIndex + 1;
            context.SaveChanges();

        }
    }
}
