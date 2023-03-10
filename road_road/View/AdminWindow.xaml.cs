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
        static private DBContext context = new DBContext();

        public List<Users> users { get; set; }
        public List<Genders> genders { get; set; }
        public List<Roles> roles { get; set; }
        string log;
        int Role;

        public AdminWindow(string login)
        {
            InitializeComponent();
            log = login;
            Access();
            Date_Users();
            Date_Tasks();
            CB_yearItem();
            DG_task.Visibility = Visibility.Hidden;
            DG_chart.Visibility = Visibility.Hidden;
            BT_AddTask.Visibility = Visibility.Hidden;
        }
       
        private void Access()
        {
            var role = context.Users.Where(x => x.Login == log).Select(x => x.IdRole);
            if (role.First() == 1)
            {
                DG_people.Visibility = Visibility.Hidden;
            }
        }

        private void BT_people_Click(object sender, RoutedEventArgs e)
        {
            BT_AddUser.Visibility = Visibility.Visible;
            DG_chart.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Visible;
            DG_task.Visibility = Visibility.Hidden;
            BT_AddTask.Visibility = Visibility.Hidden;
        }

        private void BT_task_Click(object sender, RoutedEventArgs e)
        {   
            BT_AddUser.Visibility= Visibility.Hidden;
            DG_chart.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Hidden;
            DG_task.Visibility = Visibility.Visible;
            BT_AddTask.Visibility = Visibility.Visible;
        }
        public void Date_Tasks()
        {
            using (var context = new DBContext())
            {
                var task = context.Tasks.Select(x => new TaskViewModel
                {
                    IdTask = x.IdTask,
                    DateBegin = x.DateTimeBegin,
                    DateEnd = x.DateTimeEnd,
                    NameTypeTask = x.IdTypeTaskNavigation.NameTypeTask,
                    NameObject = x.IdObjectNavigation.NameOfObject,
                    Town = x.IdPlaceNavigation.IdTownNavigation.NameOfTown,
                    Highway = x.IdPlaceNavigation.IdHighwayNavigation.NameOfHighway,
                    Street = x.IdPlaceNavigation.IdStreetNavigation.NameOfStreet,
                    NameMaterial = x.IdMaterialNavigation.NameOfMaterial,
                    NameTechnic = x.IdTechnicNavigation.IdTypeOfTechnicNavigation.NameTypeOfTechnic,
                    NameBrigade = x.IdBrigadeNavigation.NameOfBrigade,
                    IdPlaceNavigation = x.IdPlaceNavigation
                }).ToList();

                DG_task.ItemsSource = task;
            }
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
        }

        private void DG_tasks_select(object sender, SelectionChangedEventArgs e)
        {
            TaskViewModel selectedItem = (TaskViewModel)DG_task.SelectedItem;
            if (selectedItem != null)
            {
                int id_task = selectedItem.IdTask;
                AddTask addTask = new AddTask(id_task, this);
                addTask.Show();
            }
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
            DG_task.Visibility = Visibility.Hidden;
            BT_AddUser.Visibility = Visibility.Hidden;
            BT_AddTask.Visibility = Visibility.Hidden;
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

            seriesCollection.Add(columnSeries);
            ChartGrid.Series = seriesCollection;

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

        private void BT_exit_Click(object sender, RoutedEventArgs e)
        {
            Autorisation autorisation = new Autorisation();
            autorisation.Show();
            this.Close();
        }

        private void BT_addtask_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(this);
            registration.Show();
        }
    }
}
