using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PatientDetails.ViewModels;
using PatientDetails.Models;

namespace PatientDetails.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem selectedListBoxItem = sender as ListBoxItem;
            Patient selectedPatient = selectedListBoxItem.Content as Patient;
            (DataContext as PatientViewModel).SwitchToDetailsPage(selectedPatient);
        }
    }
}
