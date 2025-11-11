using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        List<int> listaNumero = new List<int>(); /* Lista dos números aleatórios */
        List<int> listaRep = new List<int>(); /* Lista para auxiliar conferir */
        Stack<int> pilhaRep = new Stack<int>(); /* pilha repetidos */
        Stack<int> pilhaNRep = new Stack<int>(); /* pilha não repetidos */
        Random aleatorio = new Random();
        int num, count = 0;
        for (int i = 0; i < 10; i++)
        {
            num = aleatorio.Next(0, 20);
            listaNumero.Add(num);
        }

        foreach (int x in listaNumero)
        {
            count = 0;

            if (listaRep.Contains(x))
                continue;

            foreach (int y in listaNumero) /* Contador para conferir se repetiu */
            {
                if (x == y)
                    count++;
            }
            if (count > 1) /* Se houver mais de 1 repetição, adiciona ao repetido */
            {
                pilhaRep.Push(x);
            }
            else /* Se não houver repetição, adiciona ao não repetido */
            {
                pilhaNRep.Push(x);
            }

            listaRep.Add(x); /* Adiciona na lista de auxilio */
        }

        System.Console.WriteLine("----- Lista de Números -----");
        foreach (int x in listaNumero)
        {
            System.Console.Write($"{x}, ");
        }

        System.Console.WriteLine("\n----- Pilha de repetidos -----");
        foreach (int x in pilhaRep)
        {
            System.Console.Write($"{x}, ");
        }

        System.Console.WriteLine("\n----- Pilha de não repetidos -----");
        foreach (int x in pilhaNRep)
        {
            System.Console.Write($"{x}, ");
        }
    }
}