using System;

namespace Help_Listas_Linq.ListaJoin
{
    public class Item
    {
        public Item(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}