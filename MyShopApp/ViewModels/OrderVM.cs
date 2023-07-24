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
        public  List<Product> cartProducts;
        public decimal totalOrderPrice;
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

        public List<OrderItem> OrderItems => order.OrderItems;

        // Constructor
        public OrderVM()
        {
            order = new Order();
            cartProducts = new  List<Product>();
            totalOrderPrice = 0;
        }

        public void AddProductToOrder(Product product)
        {
            // Проверка добавлен ли продукт уже в заказ
            if (!OrderItems.Any(item => item.ProductId == product.Id))
            {
                // Создайте новый объект OrderItem и добавьте его в заказ
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Order = order
                };
                OrderItems.Add(orderItem);

                // Обновите общую стоимость заказа
                TotalPrice += product.Price; // Предполагается, что у класса Product есть свойство Price для расчета общей стоимости заказа
            }
        }


      
    }
}
