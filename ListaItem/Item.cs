using System;

namespace Help_Listas_Linq.ListaItem
{
    public class Item
    {
        public Item(string name, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}