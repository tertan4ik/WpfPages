using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>


    public partial class MainPage : Page
    {
        public ObservableCollection<Pacient> Pacients { get; set; } = new();
        public Pacient? Selectedpacient{ get; set; }

        public MainPage(User user)
        {

            InitializeComponent();
            UserInfo.DataContext = user;
            Fillusers();

     
        }

        public void Gotoadd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPacientPage(Pacients));
        }
        public void Gotoredact(object sender, RoutedEventArgs e)
        {
            if(Selectedpacient!=null)
            {
                NavigationService.Navigate(new RedactPage(Selectedpacient));
            }
            else
            {
                MessageBox.Show("Выберите пациента");
            }
        }
        public void GotoRecept(object sender, RoutedEventArgs e)
        {
            if(Selectedpacient!=null)
            {
                NavigationService.Navigate(new AppointmentPage(Selectedpacient));
            }
            else
            {
                MessageBox.Show("Выберите пациента");
            }
       
        }
        public void Fillusers()
        {

             string folderPath = ".\\Pacients";
             string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

                Pacients.Clear();

                foreach (string filePath in jsonFiles)
                {                 
                        string jsonString = File.ReadAllText(filePath);
                        Pacient pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                        Pacients.Add(pacient);                   
                }

                DataContext = this;           
      
        }

        public void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (Selectedpacient == null)
            {
                MessageBox.Show("Пользователь не выбран");
                return;
            }
            bool confirm = MessageBox.Show("Вы действительно хотите удалить запись?","Подтверждение удаления",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes;
            if (confirm)
            {
                    string filePath = $".\\Pacients\\P_{Selectedpacient.ID}.json";
                    File.Delete(filePath);
                    Pacients.Remove(Selectedpacient);
            }

        }


    }
}
