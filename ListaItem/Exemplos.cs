using System.Collections.Generic;
using System.Linq;

namespace Help_Listas_Linq.ListaItem
{
    public class Exemplos
    {
        private List<Item> Lista;
        public Exemplos()
        {
            Lista = new List<Item>();
            int qtd = 0;
            decimal price = 0;

            for (int i = 0; i < 20; i++)
            {
                price = i * 2;
                qtd += i;
                if (qtd == 10)
                {
                    qtd = 0;
                    price = 1;
                }

                Lista.Add(new Item($"Item {i}", qtd, price));
            }

            Lista.Add(new Item("Item 19", qtd, 1050));
        }


        // Retornar a lista inteira de items
        public List<Item> ListaItens() => Lista;


        // Retornar apenas o nome dos itens
        public List<string> NomesItens() => Lista
                                            .Select(x => x.Name)
                                            .ToList();



        // Retornar apenas o nome dos itens em IEnumerable
        public IEnumerable<string> NomesItensEnumerable() => Lista.Select(x => x.Name);


        // Retornar itens com quantidade zerada
        public List<Item> ItensZerados() => Lista
                                            .Where(x => x.Quantity < 1)
                                            .ToList();


        // Retornar apenas nome dos itens com quantidade zerada
        public List<string> NomeItensZerados() => Lista
                                                .Where(x => x.Quantity < 1)
                                                .Select(x => x.Name)
                                                .ToList();


        // Retornar o valor total de itens 
        public decimal ValorTotalItens() => Lista
                                        .Select(x => x.Price)
                                        .Aggregate((acc, x) => acc + x);


        // Retornar valor total de itens com estoque zerado
        public decimal SomaQtdTotalItens() => Lista
                                            .Where(x => x.Quantity < 1)
                                            .Select(x => x.Price)
                                            .Aggregate((acc, x) => acc + x);


        // Retornar verdadeiro ou falso se existe item sem preço
        public bool ExisteItemSemPreco() => Lista
                                            .Where(x => x.Price == 0)
                                            .Any();


        // Retornar verdadeiro ou falso se existe item com mesmo nome
        public bool ExisteItemMesmoNome() => Lista
                                                .GroupBy(x => x.Name)
                                                .Any(x => x.Count() > 1);


        // Retornar verdadeiro ou falso se existe item com preço superior a R$ 1.000,00 
        // com estoque zerado
        public bool ExisteItemPreco1000Zerado() => Lista.Any(x => x.Price > 1000 && x.Quantity < 1);




    }
}