using MyShopApp.Classes;
using MyShopApp.Messager.Messages.Base;
using System;
namespace MyShopApp.Messager.Messages
{
    internal class SendLoginedUserMessage:IMessage
    {
        public User LoginedUser { get; set; }
        public DateTime? WhenLogined { get; set; }

        public SendLoginedUserMessage(User loginedUser)
        {
            this.LoginedUser = loginedUser;
        }
    }
}
