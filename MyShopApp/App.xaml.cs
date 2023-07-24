using SimpleInjector;
using System.Windows;
using MyShopApp.ViewModels;
using MyShopApp.Messager.Services;
using MyShopApp.Views;
using MyShopApp.Messager.Messages.Base;
using MyShopApp.Repositories;
using MyShopApp.Services;

namespace MyShopApp
{
    
    public partial class App : Application
    {
        public static Container ServiceContainer { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureContainer();

            StartWindow<LoginVM>();
        }

        private void ConfigureContainer()
        {
            ServiceContainer.RegisterSingleton<IMessenger, Messenger>();

            ServiceContainer.RegisterSingleton<MainVM>();
            ServiceContainer.RegisterSingleton<RegisterVM>();
            ServiceContainer.RegisterSingleton<UserRepositoryDapper>();
            ServiceContainer.RegisterSingleton<UserRepository>();
            ServiceContainer.RegisterSingleton<ProductRepository>();
            ServiceContainer.RegisterSingleton<DbContextcs>();
            ServiceContainer.RegisterSingleton<UserVM>();
            ServiceContainer.RegisterSingleton<LoginVM>();
            ServiceContainer.RegisterSingleton<AdminVM>();
            ServiceContainer.RegisterSingleton<AddProductVM>();
            ServiceContainer.RegisterSingleton<OrderVM>();
            ServiceContainer.Verify();
        }

        private void StartWindow<T>() where T : VMBase
        {
            var startView = new MainWindow();

            var startViewModel = ServiceContainer.GetInstance<MainVM>();
            startViewModel.ActiveViewModel = ServiceContainer.GetInstance<T>();
            startView.DataContext = startViewModel;

            startView.ShowDialog();
        }
    }
}
