using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_DataBinding_Ver2
{

    public class Pacient : INotifyPropertyChanged
    {

        static int Last_ID = FindLastId();
        static int currentID = Last_ID + 1;

        private string _Name = "";
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Lastname = "";
        public string Lastname
        {
            get => _Lastname;
            set
            {
                if (_Lastname != value)
                {
                    _Lastname = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Surname = "";
        public string Surname
        {
            get => _Surname;
            set
            {
                if (_Surname != value)
                {
                    _Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _Birthday = DateTime.Today;
        public DateTime Birthday
        {
            get => _Birthday;
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value.Date;
                    OnPropertyChanged();
                }
            }
        }
        private string _LastAppointment = "";
        public string LastAppointment
        {
            get => _LastAppointment;
            set
            {
                if (_LastAppointment != value)
                {
                    _LastAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _LastDoctor = "";
        public string LastDoctor
        {
            get => _LastDoctor;
            set
            {
                if (_LastDoctor != value)
                {
                    _LastDoctor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Diagnosis = "";
        public string Diagnosis
        {
            get => _Diagnosis;
            set
            {
                if (_Diagnosis != value)
                {
                    _Diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Recomendations = "";
        public string Recomendations
        {
            get => _Recomendations;
            set
            {
                if (_Recomendations != value)
                {
                    _Recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _ID = "";
        public string ID
        {
            get => _ID;
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        private static int FindLastId()
        {
            if (File.Exists("Last_P_ID.txt") && File.ReadAllText("Last_P_ID.txt") != "")
            {
                return Convert.ToInt32(File.ReadAllText("Last_P_ID.txt"));
            }
            else
            {
                return 0;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void Savetofile()
        {
            int aou = allusers;
            allusers = 0;
            if (_Name != "" && _Lastname != "" && _Surname != "" && _Birthday != null)
            {
                string filePath;
                string idString;
                
                if (currentID >= 10000)
                {
                    idString = $"{currentID}";
                }
                else if (currentID >= 1000)
                {
                    idString = $"0{currentID}";
                }
                else if (currentID >= 100)
                {
                    idString = $"00{currentID}";
                }
                else if (currentID >= 10)
                {
                    idString = $"000{currentID}";
                }
                else
                {
                    idString = $"0000{currentID}";
                }

                ID = idString;
                filePath = $".\\Pacients\\P_{ID}.json";

                File.WriteAllText("Last_P_ID.txt", currentID.ToString());
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(filePath, jsonString);

                Name = "";
                Lastname = "";
                Surname = "";
                Birthday = DateTime.Now;
                LastAppointment = "";
                LastDoctor = "";
                Diagnosis = "";
                Recomendations = "";
                ID = "";
                currentID++;

                allusers = aou;
            }
            else
            {
                MessageBox.Show("Заполните обязательные поля: Имя, Фамилия, Отчество, Дата рождения");
            }
        }





        public bool Loadfromfile()
        {
            string fileName = $".\\Pacients\\P_{ID}.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                Pacient pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;

                Name = pacient.Name;
                Lastname = pacient.Lastname;
                Surname = pacient.Surname;
                Birthday = pacient.Birthday;
                LastAppointment = pacient.LastAppointment;
                LastDoctor = pacient.LastDoctor;
                Diagnosis = pacient.Diagnosis;
                Recomendations = pacient.Recomendations;
                ID = pacient.ID;
                return true;
            }
            else
            {
                MessageBox.Show("Пациент не найден");
                return false;
            }
        }



        public void UpdatePacient()
        {
            int aou = allusers;
            allusers = 0;


            string filePath = $".\\Pacients\\P_{ID}.json";
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(filePath, jsonString);

            allusers = aou;
            

        }

     public void Reception(string id)
        {
            int aou = allusers;
            allusers = 0;


            LastDoctor = id;
            LastAppointment = DateTime.Now.Date.ToString();
            string filePath = $".\\Pacients\\P_{ID}.json";
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, jsonString);
            allusers = aou;
    
        }


        private int _allusers = 0;
        public int allusers
        {
            get => _allusers;
            set
            {
                if (_allusers != value)
                {
                    _allusers = value;
                    OnPropertyChanged();
                }
            }
        }
        public void Numberofpacients(int numberofusers)
        {
           allusers= numberofusers +Last_ID;
        }
    }

}

