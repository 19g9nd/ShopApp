using ConsoleApp5.Classes;

namespace MyShopApp.Classes
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }

}