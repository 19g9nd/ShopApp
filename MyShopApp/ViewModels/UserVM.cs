using ConsoleApp5.Classes;
using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using MyShopApp.Repositories;
using MyShopApp.Services;
using System.Collections.ObjectModel;

namespace MyShopApp.ViewModels
{
    public class UserVM :VMBase
    {
        private User? currentUser;
        private readonly DbContextcs context = new DbContextcs();
        private readonly IMessenger messenger;
        private readonly ProductRepository productsRepository;
        private ObservableCollection<Product> products { get; set; } = new ObservableCollection<Product>();

        public User? CurrentUser
        {
            get { return currentUser; }
            set => base.PropertyChange(out currentUser, value);
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private MyCommand? AddToCartCommand { get; set; }
        private MyCommand? CheckoutCommand { get; set; }
        private MyCommand? loadCommand;

        public MyCommand LoadCommand
        {
            get => this.loadCommand ??= new MyCommand(
                action: () =>
                {
                    this.products.Clear();

                    foreach (var product in productsRepository.GetAll())
                    {
                        this.products.Add(product);
                    }
                },
                predicate: () => true);
            set => base.PropertyChange(out this.loadCommand, value);
        }

        public UserVM(IMessenger messenger)
        {
            this.messenger = messenger;
            this.productsRepository = new ProductRepository(context);
          
          
            this.messenger.Subscribe<SendLoginedUserMessage>(obj =>
            {
                if (obj is SendLoginedUserMessage message)
                {
                    this.CurrentUser = message.LoginedUser;
                }
            });
        }

       
        private void AddToCartExecute(object parameter)
        {
            // Логика добавления товара в корзину
        }

        private bool CanAddToCartExecute(object parameter)
        {
            // Проверка, может ли быть выполнена команда AddToCartCommand
            // Например, проверка выбранного товара или наличия товара в наличии
            return true;
        }

        private void CheckoutExecute(object parameter)
        {
            // Логика оформления заказа
        }

        private bool CanCheckoutExecute(object parameter)
        {
            // Проверка, может ли быть выполнена команда CheckoutCommand
            // Например, проверка, есть ли товары в корзине
            return true;
        }

    }
}
