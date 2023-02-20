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
            TB_gender.Text = gender.NameOfGender;
            TB_role.Text = user.Password;
        }


        

        
    }
}
