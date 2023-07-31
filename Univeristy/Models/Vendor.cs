using System.Collections.Generic;


namespace VendorApp.Models
{
    public class Vendor
    {
        private static List<Vendor> _instances = new() { };
        public string Name { get; set; }

        public int Id { get; }
        public List<Order> VendorOrderList { get; set; }

        public Vendor(string name)
        {
            Name = name;
            _instances.Add(this);
            Id = _instances.Count;
            VendorOrderList = new List<Order> { };
        }
        public static List<Vendor> GetAll()
        {
            return _instances;
        }

        public static Vendor Find(int id)
        {
            return _instances[id - 1];
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public void AddOrder(Order order)
        {
            VendorOrderList.Add(order);
        }
    }
}