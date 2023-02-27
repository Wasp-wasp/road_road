using road_road.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;



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
            BrigadeID();
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
            DG_chart.Visibility = Visibility.Hidden;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Visible;
        }


        
        private void BrigadeID()
        {
          
          
        }

        private void Date_Users()
        {
            using (var context = new DBContext())
            {
                users = context.Users.ToList();
            }
           
            DG_people.ItemsSource = users;
        }

     
        private void DG_users(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //   var context = new DBContext();
            //using (var context = new DBContext())
            //{
            //    users = context.Users.ToList();
            //}
            DG_people.ItemsSource = users;
            using (var context = new DBContext())
            {
                users = context.Users.ToList();
                //context.SaveChanges();
            }

            MessageBox.Show(System.Convert.ToString(users));
            // users = context.Users.ToList();

            //   var us = context.Users.SingleOrDefault(x => x.IdUser == x.IdUser);
            //   MessageBox.Show(System.Convert.ToString(us));
            ////   context.Entry(us).State = EntityState.Modified;
            //   context.SaveChanges();
        }

        private void DG_AGCpeople( object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            if (headername == "IdRole")
            {
                e.Column.Header = "Роль";
            }
            if (headername == "IdUser")
            {
                e.Column.Width=0;
            }

            if (headername == "IdGender")
            {
                e.Column.Header = "Гендер";
                e.Column.IsReadOnly = true;
            }

            if (headername == "Photo")
            {
                e.Column.Width = 0;
            }
        }




        private void BT_chart_Click(object sender, EventArgs e)
        {
            DG_chart.Visibility = Visibility.Visible;
            DG_people.Visibility = Visibility.Hidden;
            DG_smena.Visibility = Visibility.Hidden;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2022",
                    Values = new ChartValues<int>(AuthenticationService.WT())
                    //Values = new ChartValues<int?>(AuthenticationService.WT())
                    //Values = new ChartValues<int>{ 2, 3, 4, 9}
                }
            };
            MessageBox.Show(AuthenticationService.WT().ToString());
            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2023",
                Values = new ChartValues<double> { 11, 56, 42, 0, 20 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);


            var brigades = AuthenticationService.BrigadeID();
            string[] brigade = new string[brigades.Count()];

            for (int i = 0; i < brigade.Count(); i++)
            {
                brigade[i] = brigades.ElementAt(i);
            }
            Labels = brigade;
           // int s = AuthenticationService.count();
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}
