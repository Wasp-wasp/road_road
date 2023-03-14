using road_road.Data.Models;
using System;
using System.Linq;
using System.Windows;


namespace road_road.View
{
    /// <summary>
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        static private DBContext context = new DBContext();
        AdminWindow admin;
        int tasks;

        public AddTask(int id_task, AdminWindow admin)
        {
            InitializeComponent();
            this.admin = admin;
            tasks = id_task;
            TownID();
            StreetID();
            HighWayID();
            ObjectID();
            BrigadeID();
            TypeTaskID();
            TechnicID();
            Load_date();
        }

        private void TownID()
        {
            var town = AuthenticationService.TownID();

            foreach (var i in town)
                CB_Town.Items.Add(i.NameOfTown);
        }
        private void StreetID()
        {
            var street = AuthenticationService.StreetID();

            foreach (var i in street)
                CB_Street.Items.Add(i.NameOfStreet);
        }
        private void HighWayID()
        {
            var highway = AuthenticationService.HighWayID();

            foreach (var i in highway)
                CB_HighWay.Items.Add(i.NameOfHighway);
        }
        private void ObjectID()
        {
            var nameObject = AuthenticationService.ObjectID();

            foreach (var i in nameObject)
                CB_NameObject.Items.Add(i.NameOfObject);
        }
        private void BrigadeID()
        {
            var brigade = AuthenticationService.BrigadeID();

            foreach (var i in brigade)
                CB_NameBrigade.Items.Add(i.NameOfBrigade);
        }
        private void TypeTaskID()
        {
            var typeTask = AuthenticationService.TypeTaskID();

            foreach (var i in typeTask)
                CB_NameBrigade.Items.Add(i.NameTypeTask);
        }
        private void TechnicID()
        {
            var technic = AuthenticationService.TechnicID();

            foreach (var i in technic)
                CB_NameTechnic.Items.Add(i.NameTypeOfTechnic);
        }

        private void Load_date()
        {
            var task = context.Tasks.SingleOrDefault(x => x.IdTask == tasks);
            //CB_HighWay.SelectedIndex = Convert.ToInt32(task.Id);
            CB_NameObject.SelectedIndex = Convert.ToInt32(task.IdObject) - 1;
            CB_NameTechnic.SelectedIndex = Convert.ToInt32(task.IdTechnic) - 1;
            CB_NameBrigade.SelectedIndex = Convert.ToInt32(task.IdBrigade) - 1;
            CB_TypeTask.SelectedIndex = Convert.ToInt32(task.IdTypeTask) - 1;

            //CB_Town.SelectedIndex = Convert.ToInt32(task.IdPlaceNavigation.IdTown) - 1;
            //CB_Street.SelectedIndex = Convert.ToInt32(task.IdPlaceNavigation.IdStreet) - 1;
            //CB_HighWay.SelectedIndex = Convert.ToInt32(task.IdPlaceNavigation.IdHighway) - 1;
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
