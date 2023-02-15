using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        
        private void But_enter(object sender, RoutedEventArgs e)
        {
            Autorisation autorisation = new Autorisation();
            autorisation.Show();
            this.Close();
        }

        private void But_reg(object sender, RoutedEventArgs e)
        {
            Users user= new Users();
            user.Login = TB_name.Text.Trim();
            AuthenticationService.Registration(user);
            //TODO
        }
    }
}
