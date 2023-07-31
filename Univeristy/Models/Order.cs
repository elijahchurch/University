using System.Collections.Generic;

namespace VendorApp.Models
{
    public class Order
    {
        // Add fields below
        private static List<Order> _orders = new List<Order> { };
        public string Name { get; set; }
        public int Id  { get; } 
        // Add vendor constructor below
        public Order(string name)
        {
            Name = name;
            _orders.Add(this);
            Id = _orders.Count;
        }
        // Add methods below
    }
}