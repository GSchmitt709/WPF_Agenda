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

namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AgendaContext db = new AgendaContext();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = db;
            customersList customersListPage = new customersList();
            frame.Navigate(customersListPage);
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            addCustomer addCustomerPage = new addCustomer();
            frame.Navigate(addCustomerPage);
        }

        private void CustomersList_Click(object sender, RoutedEventArgs e)
        {
            customersList customersListPage = new customersList();
            frame.Navigate(customersListPage);
        }

        private void AddBroker_Click(object sender, RoutedEventArgs e)
        {
            addBroker addBrokerPage = new addBroker();
            frame.Navigate(addBrokerPage);
        }

        private void BrokersList_Click(object sender, RoutedEventArgs e)
        {
            brokersList brokersListPage = new brokersList();
            frame.Navigate(brokersListPage);
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            addAppointment addAppointmentPage = new addAppointment();
            frame.Navigate(addAppointmentPage);
        }

        private void AppointmentsList_Click(object sender, RoutedEventArgs e)
        {
            appointmentsList appointmentsListPage = new appointmentsList();
            frame.Navigate(appointmentsListPage);
        }
    }
}
