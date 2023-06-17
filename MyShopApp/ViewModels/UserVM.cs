using ConsoleApp5.Classes;
using MyShopApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyShopApp.ViewModels
{
    public class UserVM :VMBase
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ICommand AddToCartCommand { get; set; }
        public ICommand CheckoutCommand { get; set; }

        public UserVM()
        {
            // Инициализация команд
          
            // Загрузка товаров из базы данных или другого источника
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Здесь происходит загрузка товаров из базы данных или другого источника данных
            // Инициализировать свойство Products, чтобы отобразить список товаров в представлении
            // Например:
           // Products = new ObservableCollection<Product>(GetProductsFromDatabase());
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
