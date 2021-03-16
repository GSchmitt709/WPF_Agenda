using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agenda;

namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Page
    {
        private AgendaContext db = new AgendaContext();
        public addCustomer()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            bool fail = false;
            customers customers = new customers();
            customers customer = customers;
            customer.lastname = lastnameBox.Text;
            customer.firstname = firstnameBox.Text;
            customer.mail = mailBox.Text;
            customer.phonenumber = phonenumberBox.Text;
            Int32.TryParse(budgetBox.Text, out int budget);
            customer.budget = budget;
            db.customers.Add(customer);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                
                fail = true;
                db.customers.Remove(customer);
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
            customersList customersListPage = new customersList();
            main.frame.Navigate(customersListPage);
        }
    }
}
