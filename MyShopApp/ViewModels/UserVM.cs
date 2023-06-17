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
            Product selectedProduct = parameter as Product;
            if (selectedProduct != null)
            {
                // Логика добавления товара в корзину
                // создание объекта OrderItem и добавление его в коллекцию корзины
                // OrderItem orderItem = new OrderItem(selectedProduct);
                // Order.Add(orderItem);
            }
        }

        private bool CanAddToCartExecute(object parameter)
        {

            Product selectedProduct = parameter as Product;
            if (selectedProduct != null)
            {
                // Проверка, может ли быть выполнена команда AddToCartCommand
                // Например, проверка наличия товара в наличии или другие условия
                // return selectedProduct.Availability > 0;
            }
            return false;
        }

        private void CheckoutExecute(object parameter)
        {
            // Логика оформления заказа
            // Например, создание объекта Order, передача данных о корзине и текущем пользователе
            // Order newOrder = new Order(Cart, CurrentUser);
            // OrderService.PlaceOrder(newOrder);

            // Очистка корзины после оформления заказа
            // Order.Clear();
        }

    }
}
