using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ConsoleApp5.Classes;
using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using MyShopApp.Repositories;
using MyShopApp.Services;
using MyShopApp.Views;

namespace MyShopApp.ViewModels
{
    public class UserVM : VMBase
    {
        private readonly DbContextcs context = new DbContextcs();
        private readonly IMessenger messenger;
        private readonly ProductRepository productsRepository;
        private ObservableCollection<Product> cartProducts = new ObservableCollection<Product>();
        private decimal totalOrderPrice;

        public UserVM(IMessenger messenger)
        {
            this.messenger = messenger;
            this.productsRepository = new ProductRepository(context);

            this.messenger.Subscribe<SendLoginedUserMessage>(obj =>
            {
                if (obj is SendLoginedUserMessage message)
                {
                    this.CurrentUser = message.LoginedUser;
                    OnPropertyChanged(nameof(CurrentUser));
                    OnPropertyChanged(nameof(Balance));
                }
            });
        }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set => base.PropertyChange(out currentUser, value);
        }

        private decimal balance;
        public decimal Balance
        {
            get => balance;
            set
            {
                if (balance != value)
                {
                    balance = value;
                    OnPropertyChanged(nameof(Balance));
                    System.Console.WriteLine($"Balance is set to: {balance}");
                }
            }
        }

        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set => base.PropertyChange(out selectedProduct, value);
        }

        private ICommand addToCartCommand;
        public ICommand AddToCartCommand
        {
            get
            {
                return addToCartCommand ??= new MyCommand(
                    action: () =>
                    {
                        if (SelectedProduct != null)
                        {
                            CartProducts.Add(SelectedProduct);
                            TotalOrderPrice += SelectedProduct.Price;
                            Balance -= SelectedProduct.Price;
                            System.Console.WriteLine($"{selectedProduct.Name} added to card");
                        }
                    },
                    predicate: () => true
                );
            }
        }

        private ICommand deleteFromCartCommand;
        public ICommand DeleteFromCartCommand
        {
            get
            {
                return deleteFromCartCommand ??= new MyCommand(
                    action: () =>
                    {
                        if (SelectedProduct != null)
                        {
                            CartProducts.Remove(SelectedProduct);
                            TotalOrderPrice -= SelectedProduct.Price;
                            Balance += SelectedProduct.Price;
                        }
                    },
                    predicate: () => SelectedProduct != null
                );
            }
        }

        private ICommand checkoutCommand;
        public ICommand CheckoutCommand
        {
            get
            {
                return checkoutCommand ??= new MyCommand(
                    action: () =>
                    {
                        if (CartProducts.Count > 0)
                        {
                    // Создание нового экземпляра окна оформления заказа
                            var CheckOutWindow = new CheckoutView();
                    // Создание нового экземпляра класса представления для окна оформления заказа
                            var CheckOutViewModel = new OrderVM();
                    // Установка представления данных окна оформления заказа
                            CheckOutWindow.DataContext = CheckOutViewModel;
                    // Открытие окна оформления заказа
                            CheckOutWindow.ShowDialog();

                   
                            //CartProducts.Clear();
                            //TotalOrderPrice = 0; // Сброс суммы заказа
                        }
                    },
                    predicate: () => CartProducts.Count > 0
                );
            }
        }


        public ObservableCollection<Product> CartProducts
        {
            get { return cartProducts; }
            set
            {
                cartProducts = value;
                OnPropertyChanged(nameof(CartProducts));
            }
        }

        public decimal TotalOrderPrice
        {
            get => totalOrderPrice;
            set
            {
                totalOrderPrice = value;
                OnPropertyChanged(nameof(TotalOrderPrice));
            }
        }

        private MyCommand loadCommand;
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
    }
}
