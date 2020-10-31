using System.Linq;

namespace Help_Listas_Linq.StringArray
{
    // Uma parte da validação de um CPF consiste em verificar se todos 
    // os dígitos são iguais. Isso que faremos abaixo.
    public class VerificaCpf
    {
        public bool TodosOsDigitosSaoIguais(string doc)
        {
            char[] array = doc.ToCharArray();
            return array.All(x => x.Equals(array.First()));
        }
    }
}