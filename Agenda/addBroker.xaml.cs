using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
    /// Logique d'interaction pour addBroker.xaml
    /// </summary>
    public partial class addBroker : Page
    {
        private AgendaContext db = new AgendaContext();
        public addBroker()
        {
            InitializeComponent();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            bool fail = false;
            brokers brokers = new brokers();
            brokers broker = brokers;
            broker.lastname = lastnameBox.Text;
            broker.firstname = firstnameBox.Text;
            broker.mail = mailBox.Text;
            broker.phonenumber = phonenumberBox.Text;
            db.brokers.Add(broker);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {

                fail = true;
                db.brokers.Remove(broker);
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
            brokersList brokersListPage = new brokersList();
            main.frame.Navigate(brokersListPage);
        }
    }
}
