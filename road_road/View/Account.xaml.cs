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
            log = login;
            GenderID();
            Load_data();
        }

        private void Load_data()
        {
            var user = context.Users.SingleOrDefault(x => x.Login == log);
            int? genderInt = user.IdGender;
            var gender = context.Genders.Where(x => x.IdGender == genderInt).SingleOrDefault();
            TB_login.Text = user.Login;
            TB_name.Text = user.FirstName;
            TB_secondname.Text = user.SecondName;
            TB_patronomic.Text = user.LastName;
            CB_gender.Text = gender.NameOfGender;
            TB_password.Text = user.Password;
            DP_DateOfBers.SelectedDate = user.DateOfBers;
            TB_mail.Text = user.EMail;
            TB_telephone.Text = user.Telephone;
        }

        private void GenderID()
        {
            var gender = AuthenticationService.GenderID();

            foreach (var i in gender)
                CB_gender.Items.Add(i.NameOfGender);
        }

        private void But_Edit_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow(log);
            admin.Show();
            this.Close();
        }
    }
}
