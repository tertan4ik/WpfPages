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
    public class User : INotifyPropertyChanged
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
        private string _Specialization = "";
        public string Specialization
        {
            get => _Specialization;
            set
            {
                if (_Specialization != value)
                {
                    _Specialization = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Password = "";
        public string Password
        {
            get => _Password;
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _Passwordconfirm = "";
        public string Passwordconfirm
        {
            get => _Passwordconfirm;
            set
            {
                if (_Passwordconfirm != value)
                {
                    _Passwordconfirm = value;
                    OnPropertyChanged();
                }
            }
        }
        private static int FindLastId()
        {
            if (File.ReadAllText("Last_D_ID.txt") != "")
            {
                return Convert.ToInt32(File.ReadAllText("Last_D_ID.txt"));
            }
            else
            {
                return 0;
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




        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        public void Savetofile()
        {
            if (_Name != "" && _Surname != "" && Lastname != "" && Specialization != "" && Password != "" && Passwordconfirm != "")
            {
                if (_Passwordconfirm == _Password)
                {
                  string filePath;
                if (currentID >= 10000)
                {
                    ID = $"{currentID}";
                }
                else if(currentID >= 1000)
                {
                 ID = $"0{currentID}";
                }
                else if (currentID >= 100)
                {
                    ID = $"00{currentID}";
                }
                else if (currentID >= 10)
                {
                    ID = $"000{currentID}";
                }
                else 
                {
                    ID = $"0000{currentID}";
                }
                        filePath = $".\\Users\\D_{ID}.json";
                        File.WriteAllText("Last_D_ID.txt", currentID.ToString());
                        string jsonString = JsonSerializer.Serialize(this);
                        File.WriteAllText(filePath, jsonString);
                    }
                    Name = "";
                    Surname = "";
                    Lastname = "";
                    Specialization = "";
                    Password = "";
                    Passwordconfirm = "";
                    ID = "";
                    currentID++;


                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }




        }

        public bool Loadfromfile(string id)
        {
            string fileName = $".\\Users\\D_{id}.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                User user = JsonSerializer.Deserialize<User>(jsonString)!;

                if (user.Password == _Password)
                {
                    MessageBox.Show("Вы вошли");


                    Name = user.Name;
                    Surname = user.Surname;
                    Lastname = user.Lastname;
                    Specialization = user.Specialization;
                    ID = user.ID;
                    return true;



                }
                else
                {
                    MessageBox.Show("Неверное id или пароль");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                return false;
            }
        }

        public int Numberofusers()
        {
            return Last_ID;
        }

    }
}
