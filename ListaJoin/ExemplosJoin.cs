using System;
using System.Collections.Generic;
using System.Linq;

namespace Help_Listas_Linq.ListaJoin
{
    public class ExemplosJoin
    {
        public List<Item> Items;
        public List<ItemEstoque> Estoque;

        public ExemplosJoin()
        {
            Items = new List<Item>();
            Estoque = new List<ItemEstoque>();

            decimal price = 0;

            for (int i = 0; i < 20; i++)
            {
                price = i * 2;

                Items.Add(new Item($"Item {i}", price));
            }

            Items.Add(new Item("Item 19", 1050));

            int stockSelected = 0;
            int[] sto = new int[] { 0, 500, 7000, 9000 };
            foreach (var item in Items)
            {

                ItemEstoque itemEstoque = new ItemEstoque()
                {
                    ItemId = item.Id,
                    Quantidade = sto[stockSelected]
                };
                stockSelected++;
                if (stockSelected > 3)
                    stockSelected = 0;


                Estoque.Add(itemEstoque);
            }
        }

        // Retornar lista com nome dos itens com estoque zerado
        public IEnumerable<string> ItemsEstoqueZerado()
        {
            return from estoque in Estoque
                   join item in Items
                   on estoque.ItemId equals item.Id
                   where estoque.Quantidade < 1
                   select item.Name;
        }


        // Retornar lista com items e suas quantidades
        public IEnumerable<dynamic> EstoqueItems()
        {
            return from estoque in Estoque
                   join item in Items
                   on estoque.ItemId equals item.Id
                   select new { item.Name, item.Price, estoque.Quantidade };

        }


        // Retornar soma do valor total dos itens no estoque
        public decimal ValorTotalItemsEstoque()
        {
            return (from estoque in Estoque
                    join item in Items
                    on estoque.ItemId equals item.Id
                    where estoque.Quantidade > 0
                    select estoque.Quantidade * item.Price)
                    .Sum();
        }


        // Retornar a média de valores total dos itens no estoque
        public decimal MediaValoresItens()
        {
            int qtd = (from estoque in Estoque
                       join item in Items
                       on estoque.ItemId equals item.Id
                       select estoque.Quantidade).Sum();

            decimal totalPrice = (from estoque in Estoque
                                  join item in Items
                                  on estoque.ItemId equals item.Id
                                  select item.Price * estoque.Quantidade).Sum();

            return totalPrice / qtd;
        }

        public decimal MediaValoresItens2()
        {
            return (from estoque in Estoque
                    join item in Items
                    on estoque.ItemId equals item.Id
                    select item.Price * estoque.Quantidade).Sum()
                    /
                    (from estoque in Estoque
                     join item in Items
                     on estoque.ItemId equals item.Id
                     select estoque.Quantidade).Sum();


        }


    }
}