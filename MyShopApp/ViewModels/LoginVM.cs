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
        private readonly UserRepositoryDapper usersRepository;
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
        public LoginVM(UserRepositoryDapper usersRepository, IMessenger messenger)
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


        private MyCommand? loginCommand;

        public MyCommand LoginCommand
        {
            get => this.loginCommand ??= new MyCommand(
                action: () => LoginExecute(),
                predicate: () => !string.IsNullOrWhiteSpace(this.Login) && !string.IsNullOrWhiteSpace(this.Password));
            set => base.PropertyChange(out this.loginCommand, value);
        }

        private MyCommand? registerCommand;

        public MyCommand RegisterCommand
        {
            get => this.registerCommand ??= new MyCommand(
                action: () => RegisterExecute(),
                predicate: () => true);
            set => base.PropertyChange(out this.registerCommand, value);
        }
        private void RegisterExecute()
        {
            this.messenger.Send(new NavigationMessage(typeof(RegisterVM)));
        }

            private void LoginExecute()
        {
            User user = this.usersRepository.Login(this.Login, this.Password);

            if (user != null && user.Password == Password)
            {


                if (user.isAdmin == true)
                {
                    //this.messenger.Send(new NavigationMessage(typeof(//)));

                    ErrorMessage = "admin login";
                }
                else
                {
                    // this.messenger.Send(new NavigationMessage(typeof(//UserVM)));
                    // Open user 

                    ErrorMessage = "user login";
                }
            }
            else
                {
                // Login failed
                ErrorMessage = "Invalid login credentials.";
            }
        }

    }
}
