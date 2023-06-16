using ConsoleApp5;
using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
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
    public class LoginVM : VMBase
    {
        private string login;
        private string password;
        private string errorMessage;
        private readonly UserRepository usersRepository;
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
        public LoginVM(UserRepository usersRepository, IMessenger messenger)
        {
            this.usersRepository = usersRepository;
            this.messenger = messenger;
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


        private void LoginExecute()
        {
            User user = userRepository.GetUserByLogin(Login);

            if (user != null && user.Password == Password)
            {

                //У пользователя есть поле исАдмн если тру то тогда откроется 
                // Login successful
                //    if (исАдмин тру)
                //    {
                //      //  this.messenger.Send(new NavigationMessage(typeof(//AdminVM)));
                //      

                    //    }

                    //    else
                    //    {
                    //       // this.messenger.Send(new NavigationMessage(typeof(//UserVM)));
                    //        // Open user 


                    //  }
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
