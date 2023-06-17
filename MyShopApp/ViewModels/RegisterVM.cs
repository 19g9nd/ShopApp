using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using MyShopApp.Repositories;
using MyShopApp.Services;
using System;
using System.Linq;

namespace MyShopApp.ViewModels
{
    public class RegisterVM :VMBase
    {
        private readonly UserRepository usersRepository;
        private readonly IMessenger messenger;
        private readonly DbContextcs context = new DbContextcs();
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        private MyCommand? registerCommand;

        public MyCommand RegisterCommand
        {
            get => this.registerCommand ??= new MyCommand(
                action: () => RegisterExecute(),
                predicate: () => !string.IsNullOrWhiteSpace(this.Login) && !string.IsNullOrWhiteSpace(this.Password) && !string.IsNullOrWhiteSpace(this.Email));
            set => base.PropertyChange(out this.registerCommand, value);
        }
        public RegisterVM(IMessenger messenger)
        {
            this.usersRepository = new UserRepository(context);
            this.messenger = messenger;
           
        }


        private void RegisterExecute()
        {
            if (context.Users.Any(u => u.Login == Login))
            {
                ErrorMessage = "Username already exists";
                return;
            }
            
            try
            {
            var user = new User(Login, Password, Email, false);
                if(user.Password.Length <5 && !user.Email.Contains('@'))
                    {
                    throw new Exception("Cannot add user!");
                }
            this.usersRepository.Add(user);
                Console.WriteLine($"User {user.Login} added");
            this.messenger.Send(new NavigationMessage(typeof(LoginVM)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
        }
    }
}  
