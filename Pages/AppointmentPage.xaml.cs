using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp_DataBinding_Ver2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    /// 
    public partial class AppointmentPage : Page
    {
        Pacient pacient;
        AppointmentStory Appointment;
        public AppointmentPage(Pacient p)
        {
            InitializeComponent();
            pacient = p;
            DataContext = pacient;
        }

        public void EndReception(object sender, RoutedEventArgs e)
        {
            var newAppointment = new AppointmentStory
            {
                Date= DateTime.Now,
                DoctorId = pacient.ID,
                Diagnosis = nDiagnosis.Text,
                Recommendations =nRecomendations.Text
            };

            if (pacient.Appointmentstories == null)
                pacient.Appointmentstories = new List<AppointmentStory>();

            pacient.Appointmentstories.Add(newAppointment);
            pacient.UpdatePacient();

            NavigationService.GoBack();
        }

        public void Back(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
        }

    }
}
