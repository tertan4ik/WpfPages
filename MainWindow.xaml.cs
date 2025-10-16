using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_DataBinding_Ver2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        bool signin = false;
        bool register=false;
        bool pacientfind=false;
        public MainWindow()
        {
          


            InitializeComponent();

            

        }

        public void Registration(object sender, RoutedEventArgs e)
        {

  
                var user = (User)Resources["UserReg"];
                user.Savetofile();
                user = null;

            var pacient = (Pacient)Resources["Pacientshow"];
            pacient.Numberofpacients(user.Numberofusers());

        }

        public void Login(object sender, RoutedEventArgs e)
        {
          
            var user=(User)Resources["UserLog"];
            signin= user.Loadfromfile(user.ID);


            var pacient = (Pacient)Resources["Pacientshow"];
            pacient.Numberofpacients(user.Numberofusers());


        }

        public void Addpacient(object sender, RoutedEventArgs e)
        {
            var pacient = (Pacient)Resources["Pacientadd"];
            if (signin)
            {
             
                pacient.Savetofile();
            }
            else
            {
                MessageBox.Show("Вы не вошли в аккаунт");
            }
        }

        public void ShowPacient(object sender, RoutedEventArgs e)
        {
    
            var pacientshow = (Pacient)Resources["Pacientshow"];
            if (signin)
            {
                pacientshow.Loadfromfile();
            }
            else
            {
                MessageBox.Show("Вы не вошли в аккаунт");
            }
        }

        private void Redactpacient(object sender, RoutedEventArgs e)
        {
            if (signin)
            {
                var pacient = (Pacient)Resources["Pacientshow"];
                pacient.UpdatePacient();
            }
            else
            {
                MessageBox.Show("Вы не вошли в аккаунт");
            }


        }

        public void Receptpacient(object sender, RoutedEventArgs e)
        {
            if (signin)
            {
                var user = (User)Resources["UserLog"];
                var pacient = (Pacient)Resources["Pacientshow"];
                pacient.Reception(user.ID);
            }
            else
            {
                MessageBox.Show("Вы не вошли в аккаунт");
            }



        }


    }
}