using ConsoleApp5.Classes;
using MyShopApp.Classes;
using MyShopApp.Commands;
using MyShopApp.Messager.Messages;
using MyShopApp.Messager.Services;
using MyShopApp.Repositories;
using MyShopApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyShopApp.ViewModels
{
    public class AdminVM:VMBase
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

        private Product? selectedProduct;

        public Product? SelectedProduct
        {
            get { return selectedProduct; }
            set => base.PropertyChange(out selectedProduct, value);
        }
        private MyCommand? addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                return addProductCommand ??= new MyCommand(
                    action: () =>
                    {
                        // Создание нового продукта и добавление его в коллекцию
                        var newProduct = new Product();
                        products.Add(newProduct);
                        SelectedProduct = newProduct;
                    },
                    predicate: () => true);
            }
        }

        private MyCommand? deleteProductCommand;
        public ICommand DeleteProductCommand
        {
            get
            {
                return deleteProductCommand ??= new MyCommand(
                    action: () =>
                    {
                        if (SelectedProduct != null)
                        {
                            // Удаление выбранного продукта из коллекции
                            products.Remove(SelectedProduct);
                        }
                    },
                    predicate: () => SelectedProduct != null);
            }
        }
        public AdminVM(IMessenger messenger)
        {
            this.messenger = messenger;
            this.productsRepository = new ProductRepository(context);

            this.LoadCommand.Execute(null);

            this.messenger.Subscribe<SendLoginedUserMessage>(obj =>
            {
                if (obj is SendLoginedUserMessage message)
                {
                    this.CurrentUser = message.LoginedUser;
                }
            });
        }


    }

}
