﻿using System;
using Help_Listas_Linq.ListaItem;
using Help_Listas_Linq.StringArray;

namespace Help_Listas_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new Exemplos();
            bool exist = lista.ExisteItemMesmoNome();
            Console.WriteLine(exist);

            bool iguais = new VerificaCpf().TodosOsDigitosSaoIguais("11111111112");
            Console.WriteLine(iguais);

        }
    }
}