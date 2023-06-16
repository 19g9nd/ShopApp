using MyShopApp.Messager.Messages.Base;
using System;


namespace MyShopApp.Messager.Services
{
    public interface IMessenger
    {
        void Send<TKey>(TKey arg) where TKey : IMessage;
        void Subscribe<TKey>(Action<IMessage> action) where TKey : IMessage;
    }
}
