using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopApp.ViewModels
{
	public class MainVM : VMBase
	{

		private VMBase? activeViewModel;
		private readonly IMessenger messenger;

		public VMBase? ActiveViewModel
		{
			get { return activeViewModel; }
			set { this.PropertyChange(out activeViewModel, value); }
		}

        public MainVM(IMessenger messenger)
        {
			this.messenger = messenger;

			this.messenger.Subscribe<NavigationMessage>((message) =>
			{
				if (message is NavigationMessage navigationMessage)
				{
					var serviceObj = App.ServiceContainer.GetInstance(navigationMessage.NavigateTo);

					if (serviceObj is  VMBase vm)
						this.ActiveViewModel = vm;
				}
			});
		}
	}

	
}