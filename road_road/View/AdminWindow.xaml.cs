using road_road.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



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
        

    }
}
