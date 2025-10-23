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

        private List<AppointmentStory> _Appointmentstories = null;
        
        public List<AppointmentStory>  Appointmentstories
        {
            get => _Appointmentstories;
            set
            {
                if (_Appointmentstories != value)
                {
                    _Appointmentstories = value;
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

        public bool Savetofile()
        {
    
        
            if (_Name != "" && _Lastname != "" && _Surname != "" && _Birthday != null)
            {
                string filePath;
               

                
                if (currentID >= 1000000)
                {
                    ID = $"{currentID}";
                }
                else if(currentID >= 100000)
                {
                 ID = $"0{currentID}";
                }
                else if (currentID >= 10000)
                {
                    ID = $"00{currentID}";
                }
                else if (currentID >= 1000)
                {
                    ID = $"000{currentID}";
                }
                else if (currentID >= 100)
                {
                    ID = $"0000{currentID}";
                }
                else if (currentID >= 10)
                {
                    ID = $"00000{currentID}";
                }
                else
                {
                    ID = $"000000{currentID}";
                }

               
                filePath = $".\\Pacients\\P_{ID}.json";

                File.WriteAllText("Last_P_ID.txt", currentID.ToString());
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(filePath, jsonString);

                MessageBox.Show("Pacient added");
                currentID++;

                return true;
            }
            else
            {
                MessageBox.Show("Заполните обязательные поля: Имя, Фамилия, Отчество, Дата рождения");
                return false;
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
                ID = pacient.ID;
                Appointmentstories = pacient.Appointmentstories;
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
                string filePath = $".\\Pacients\\P_{ID}.json";
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(filePath, jsonString);
        }

     public void Reception(string id)
        {
            string filePath = $".\\Pacients\\P_{ID}.json";
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, jsonString);   
        }


    }

}

