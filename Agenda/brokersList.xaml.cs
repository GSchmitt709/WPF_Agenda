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
    /// Logique d'interaction pour brokersList.xaml
    /// </summary>
    public partial class brokersList : Page
    {
        private AgendaContext db = new AgendaContext();
        public brokersList()
        {
            InitializeComponent();
            var brokers = db.brokers.ToList();
            dgBrokers.ItemsSource = brokers;
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
            brokersList brokersListPage = new brokersList();
            main.frame.Navigate(brokersListPage);
        }

        private void AutoGenerate(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string col = (string)e.Column.Header;
            if ((col == "idBroker"))
            {
                e.Column.IsReadOnly = true;
            }
            if (col == "appointments")
            {
                e.Cancel = true;
            }
            
        }
        

        private void Delete(object sender, RoutedEventArgs e)
        {
            db.brokers.Remove((brokers)dgBrokers.SelectedItem);
            db.SaveChanges();
            MainWindow main = Application.Current.MainWindow as MainWindow;
            brokersList brokersListPage = new brokersList();
            main.frame.Navigate(brokersListPage);
        }
    }
}
