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
    /// Logique d'interaction pour addAppointment.xaml
    /// </summary>
    public partial class addAppointment : Page
    {
        private AgendaContext db = new AgendaContext();
        public addAppointment()
        {
            InitializeComponent();
            var customers = db.customers.ToList();
            cbClients.ItemsSource = customers;
            var brokers = db.brokers.ToList();
            cbBrokers.ItemsSource = brokers;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            bool fail = false;
            appointments appointments = new appointments();
            appointments appointment = appointments;
            appointment.customers = (customers)cbClients.SelectedItem;
            appointment.brokers = (brokers)cbBrokers.SelectedItem;
            DateTime dt = (DateTime)date.SelectedDate;
            DateTime datehour = new DateTime(dt.Year, dt.Month, dt.Day, Convert.ToInt32(hour.Text), Convert.ToInt32(minute.Text), 0) ;
            appointment.dateHour = datehour;
            appointment.subject = subject.Text;

            db.appointments.Add(appointment);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {

                fail = true;
                db.appointments.Remove(appointment);
                AddLabel.Content = "Erreur d'enregistrement";

            }
            if (!fail)
            {
                AddLabel.Content = "Enregistrement reussi";
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            appointmentsList appointmentsListPage = new appointmentsList();
            main.frame.Navigate(appointmentsListPage);
        }
    }
    
}
