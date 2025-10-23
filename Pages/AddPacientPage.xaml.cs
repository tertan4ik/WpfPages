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
    /// Логика взаимодействия для AddPacientPage.xaml
    /// </summary>
    public partial class AddPacientPage : Page
    {
        private ObservableCollection<Pacient> _pacients;
        Pacient pacient=new Pacient();
        public AddPacientPage(ObservableCollection<Pacient> pacients)
        {
            _pacients = pacients;
            InitializeComponent();
            DataContext = pacient;
        }
        public void Addpacient(object sender, RoutedEventArgs e)
        {
          
           if (pacient.Savetofile())
            {
                _pacients.Add(pacient);
            }

  

        }

        private void Gotomain(object sender, RoutedEventArgs e)
        {
            
            NavigationService.GoBack();
        }
    }
}
