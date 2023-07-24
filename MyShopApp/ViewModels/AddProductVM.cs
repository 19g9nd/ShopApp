using ConsoleApp5.Classes;
using MyShopApp;
using MyShopApp.Commands;
using MyShopApp.Repositories;
using MyShopApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyShopApp.ViewModels
{
    public class AddProductVM : VMBase
    {
        private Product newProduct;
        private readonly ProductRepository productsRepository;

        public Product NewProduct
        {
            get { return newProduct; }
            set => base.PropertyChange(out newProduct, value);
        }

        public event Action OnExecuted;
        public ICommand SaveProductCommand { get; }

        public AddProductVM(ProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
            NewProduct = new Product { Status = new Status { Name = "In Stock" } };

            SaveProductCommand = new MyCommand(
                action: () =>
                {
                    // Сохранение нового товара в базу данных
                    productsRepository.Add(NewProduct);

                    // Закрытие окна после нажатия кнопки сохранить
                    CloseWindow();
                    // Trigger the OnExecuted event to notify the view (AddProductView) that the SaveProductCommand is executed
                    OnExecuted?.Invoke();
                },
                predicate: () => true
            );
        }

        private void CloseWindow()
        {
            // Find the parent window and close it
            foreach (var window in App.Current.Windows)
            {
                if (window is Views.AddProductView addProductView)
                {
                    addProductView.Close();
                    break;
                }
            }
            }
    }

}
