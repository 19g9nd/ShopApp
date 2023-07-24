using ConsoleApp5.Classes;
using MyShopApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyShopApp.ViewModels
{
    public class OrderVM : VMBase
    {
        private readonly Order order;
        private List<Product> cartProducts;
        private decimal totalOrderPrice;

        public int UserId
        {
            get => order.UserId;
            set
            {
                order.UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public DateTime OrderDate
        {
            get => order.OrderDate;
            set
            {
                order.OrderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        public string? Status
        {
            get => order.Status;
            set
            {
                order.Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public decimal TotalPrice
        {
            get => order.TotalPrice;
            set
            {
                order.TotalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ObservableCollection<Product> CartProducts
        {
            get { return new ObservableCollection<Product>(cartProducts); }
            set
            {
                cartProducts = new List<Product>(value);
                CalculateTotalOrderPrice();
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

        // Constructor
        public OrderVM()
        {
            order = new Order();
            cartProducts = new List<Product>();
            totalOrderPrice = 0;
        }

        public void AddProductToOrder(Product product)
        {
            // logic to add a product to the order
        }

        public void RemoveProductFromOrder(Product product)
        {
            //logic to remove a product from the order
        }

        public void CalculateTotalOrderPrice()
        {
            TotalOrderPrice = CartProducts.Sum(product => product.Price);
        }

        public bool PlaceOrder()
        {
            // logic to place the order
            return true;
        }
    }
}
