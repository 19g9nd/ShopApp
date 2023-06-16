using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MyShopApp.ViewModels;
namespace MyShopApp
{
    
    public partial class App : Application
    {
        public static Container ServiceContainer { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //ConfigureContainer();

            //StartWindow<LoginVM>();
        }

    }
}
