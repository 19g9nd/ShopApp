using ConsoleApp5;
using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Services;
using MyShopApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyShopApp.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string errorMessage;
        private readonly IMessenger messenger;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }

        private readonly UserRepositoryDapper userRepository;

        public LoginVM()
        {
            userRepository = new UserRepositoryDapper("Server= localhost; Database=MyShopDb; Integrated Security=True;");

            LoginCommand = new RelayCommand(LoginExecute);
        }

        private void LoginExecute()
        {
            User user = userRepository.GetUserByLogin(Login);

            if (user != null && user.Password == Password)
            {
                // Login successful
                if (user.Login == "Admin")
                {
                    // Open admin 
                  
                }
             
                else
                {
                    // Open user 
               

                }
            }
            else
            {
                // Login failed
                ErrorMessage = "Invalid login credentials.";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
