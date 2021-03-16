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
using System.Data.Entity.Core.Metadata.Edm;

namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour customersList.xaml
    /// </summary>
    public partial class customersList : Page
    {
        private AgendaContext db = new AgendaContext();
        public customersList()
        {
            InitializeComponent();
            var customers = db.customers.ToList();
            dgCustomers.ItemsSource = customers;
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
            customersList customersListPage = new customersList();
            main.frame.Navigate(customersListPage);
        }

        private void AutoGenerate(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        string col = (string)e.Column.Header;
            if ((col == "idCustomer"))
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
            db.customers.Remove((customers)dgCustomers.SelectedItem);
            db.SaveChanges();
            MainWindow main = Application.Current.MainWindow as MainWindow;
            customersList customersListPage = new customersList();
            main.frame.Navigate(customersListPage);
        }
    }
}
