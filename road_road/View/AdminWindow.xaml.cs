using road_road.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        public List<Users> users { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
            Date_Users();
        }

        private void BT_people_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Visible;
            DG_smena.Visibility = Visibility.Hidden;
          
        }

       
     
        private void BT_smena_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Visible;
        }

        private void BT_report_Click(object sender, RoutedEventArgs e)
        {
            DG_report.Visibility = Visibility.Visible;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Hidden;
        }

        

        private void Date_Users()
        {
            using (var context = new DBContext())
            {
                //context.Configuration.ProxyCreationEnabled = false;
                users = context.Users.ToList();
            }
           
            DG_people.ItemsSource = users;
           // DG_people.Columns[1].HeaderStringFormat = "SubjectMarks";
        }

     
        private void DG_users(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //DG_people.Columns[0]. = "название столбца";
           
           // DG_people.Columns[0].;
        }
    }
}
