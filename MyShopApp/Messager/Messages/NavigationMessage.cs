using MyShopApp.Messager.Messages.Base;
using System;

namespace MyShopApp.Messager.Messages
{
    public class NavigationMessage : IMessage
    {
        public Type NavigateTo { get; set; }

        public NavigationMessage(Type navigateTo)
        {
            this.NavigateTo = navigateTo;
        }
    }
}
