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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Validation;

namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour appointmentsList.xaml
    /// </summary>
    public partial class appointmentsList : Page
    {
        private AgendaContext db = new AgendaContext();
        public appointmentsList()
        {
            InitializeComponent();
            var appointments = db.appointments.ToList();
            dgAppointments.ItemsSource = appointments;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            bool fail = false;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {

                fail = true;
                statusLabel.Content = "Erreur d'enregistrement";

            }
            if (!fail)
            {
                statusLabel.Content = "Enregistrement reussi";
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            appointmentsList appointmentsListPage = new appointmentsList();
            main.frame.Navigate(appointmentsListPage);
        }
        private void AutoGenerate(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string col = (string)e.Column.Header;
            if ((col == "idAppointment"))
            {
                e.Column.IsReadOnly = true;
            }
            if (col == "brokers")
            {
                var cb = new DataGridComboBoxColumn();
                cb.ItemsSource = db.brokers.ToList();
                cb.SelectedValueBinding = new Binding("brokers");
                cb.DisplayMemberPath = "lastname";
                cb.Header = "_brokers";
                e.Column = cb;
            }
            if (col == "customers")
            {
                var cb = new DataGridComboBoxColumn();
                cb.ItemsSource = db.customers.ToList();
                cb.SelectedValueBinding = new Binding("customers");
                cb.DisplayMemberPath = "lastname";
                cb.Header = "_customers";
                e.Column = cb;
            }

        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            db.appointments.Remove((appointments)dgAppointments.SelectedItem);
            db.SaveChanges();
            MainWindow main = Application.Current.MainWindow as MainWindow;
            appointmentsList appointmentsListPage = new appointmentsList();
            main.frame.Navigate(appointmentsListPage);
        }


    }
}
