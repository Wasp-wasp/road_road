using road_road.Data.Models;
using road_road.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;

namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        
        public List<Users> users { get; set; }
        public List<Genders> genders { get; set; }
        public List<Roles> roles { get; set; }

        public AdminWindow()
        {
            InitializeComponent();
            Date_Users();
            CB_yearItem();
            DG_smena.Visibility = Visibility.Hidden;
            DG_chart.Visibility = Visibility.Hidden;
        }

        private void BT_people_Click(object sender, RoutedEventArgs e)
        {
            
            DG_chart.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Visible;
            DG_smena.Visibility = Visibility.Hidden;
          
        }

        private void BT_smena_Click(object sender, RoutedEventArgs e)
        {   
            BT_AddUser.Visibility= Visibility.Hidden;
            DG_chart.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Visible;
        }

        public void Date_Users()
        {
            using (var context = new DBContext())
            {
               var users = context.Users.Select(x => new UserViewModel
               {
                    NameRole = x.IdRoleNavigation.NameOfRole,
                    NameGender = x.IdGenderNavigation.NameOfGender,
                    DateOfBers = x.DateOfBers,
                    SecondName = x.SecondName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Telephone = x.Telephone,
                    EMail = x.EMail,
                    Photo = x.Photo,
                    Login = x.Login,
                    Password = x.Password
               }).ToList();
                
                DG_people.ItemsSource = users;
            }
        }


        private void DG_users(object sender, SelectionChangedEventArgs e)
        {
            UserViewModel selectedItem = (UserViewModel)DG_people.SelectedItem;
            if (selectedItem != null)
            {
                string login = selectedItem.Login;
                Admin admin = new Admin(login, this);
                admin.Show();
            }
            //Date_Users();
                
        }

        
        public void CB_yearItem()
        {
            CB_years.Items.Add("2019");
            CB_years.Items.Add("2020");
            CB_years.Items.Add("2021");
            CB_years.Items.Add("2022");
        }
        
        public void CB_yearsChange(object sender, EventArgs e)
        {
            Chart();
        }
        private void BT_chart_Click(object sender, EventArgs e)
        {
            DG_chart.Visibility = Visibility.Visible;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Hidden;
            Chart();
        }
        public void Chart()
        {
            string title = CB_years.SelectedItem.ToString();
            
            SeriesCollection seriesCollection = new SeriesCollection();

            ColumnSeries columnSeries = new ColumnSeries
            {
                Title = CB_years.SelectedItem.ToString(),
                Values = new ChartValues<int>(AuthenticationService.WT(title))
            };

            //adding series will update and animate the chart automatically

            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "2023",
            //    Values = new ChartValues<double> { 11, 56, 42, 0, 20 }
            //});

            seriesCollection.Add(columnSeries);
            ChartGrid.Series = seriesCollection;


            //also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);


            var brigades = AuthenticationService.BrigadeID(title);
            string[] brigade = new string[brigades.Count()];

            for (int i = 0; i < brigade.Count(); i++)
            {
                brigade[i] = brigades.ElementAt(i);
            }
            Labels = brigade;
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void BT_add_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(this);
            registration.Show();
            
        }
    }
}
