using road_road.Data.Models;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        static private DBContext context = new DBContext();
        string log;
        public Admin(string login)
        {
            InitializeComponent();
            log = login;
            Load_data();
        }
        private void Load_data()
        {
            //TB_login.Text = AuthenticationService.Load_data(log) + "не робит";

            var user = context.Users.SingleOrDefault(x => x.Login == log);
            int? genderInt = user.IdGender;
            var gender = context.Genders.Where(x => x.IdGender == genderInt).SingleOrDefault();
            TB_login.Text = user.Login;
            TB_firstname.Text = user.FirstName;
            TB_secondname.Text = user.SecondName;
            TB_lastname.Text = user.LastName;
            CB_gender.Text = gender.NameOfGender;
            TB_password.Text = user.Password;
        }

        private void Edit_But(object sender, RoutedEventArgs e)
        {
            var user = context.Users.SingleOrDefault(x => x.Login == log);
            user.Login = TB_login.Text.Trim();
            user.FirstName = TB_firstname.Text.Trim();
            user.SecondName = TB_secondname.Text.Trim();
            user.LastName = TB_lastname.Text.Trim();
            user.Password = TB_password.Text.Trim();
            //user.IdGender = CB_gender.SelectedIndex + 1;
            context.SaveChanges();
            this.Close();
        }
        
        
    }
}
