using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using MyShopApp.Services;
using System.Linq;
using System.Windows.Input;

namespace MyShopApp.ViewModels
{
    public class RegisterVM :VMBase
    {
        private readonly IMessenger messenger;
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

        public ICommand RegisterCommand { get; }

        public RegisterVM(IMessenger messenger)
        {
            this.messenger = messenger;
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private bool CanRegister()
        {
            // Implement validation logic
            return !string.IsNullOrEmpty(Login) &&
                   !string.IsNullOrEmpty(Password);
        }

        private void Register()
        {
            using (var context = new DbContextcs())
            {
                if (context.Users.Any(u => u.Login == Login))
                {
                    ErrorMessage = "Username already exists";
                    return;
                }

                var user = new User { Login = login, Password = Password };
                context.Users.Add(user);
                context.SaveChanges();
                this.messenger.Send(new NavigationMessage(typeof(LoginVM)));
            }
        }
    }
}
