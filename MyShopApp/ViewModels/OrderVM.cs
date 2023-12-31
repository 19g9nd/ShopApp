﻿using ConsoleApp5.Classes;
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
        public OrderVM(List<Product> cartProducts)
        {
            order = new Order();
            this.cartProducts = cartProducts;
            totalOrderPrice = cartProducts.Sum(product => product.Price);
        }
        public void AddProductToOrder(Product product)
        {
           
        }

        public void RemoveProductFromOrder(Product product)
        {
           
        }

        public void CalculateTotalOrderPrice()
        {
            TotalOrderPrice = CartProducts.Sum(product => product.Price);
        }

        public bool PlaceOrder()
        {
         
            return true;
        }
    }
}
