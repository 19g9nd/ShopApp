using ConsoleApp5.Classes;
using System;
using System.Collections.Generic;

namespace MyShopApp.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Product> OrderItems { get; set; } = new List<Product>();

    }
}
