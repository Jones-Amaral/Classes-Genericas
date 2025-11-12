using System.Reflection;

class Program
{
    static Stack<int> PreenchePilha()
    {
        Stack<int> pilha = new Stack<int>();
        System.Console.WriteLine($"----- Elementos da pilha -----");
        for (int i = 0; i < 5; i++)
        {
            Random aleatorio = new Random();
            int numero;
            numero = new int();
            numero = aleatorio.Next(0, 21);
            pilha.Push(numero);
            System.Console.Write($"{numero,5} ");
        }
        System.Console.WriteLine("");
        return pilha;
    }
    static Queue<int> ConfereRep(Stack<int> pilhaA, Stack<int> pilhaB)
    {
        Queue<int> filaElementos = new Queue<int>();

        foreach (int x in pilhaA)
        {
            if (pilhaB.Contains(x)) /* Compara com o Contains se o elemento está se repetindo */
            {
                filaElementos.Enqueue(x);
            }
        }
        return filaElementos;
    }
    static Queue<int> ConfereNRep(Stack<int> pilhaA, Stack<int> pilhaB)
    {
        Queue<int> filaElementos = new Queue<int>();
        foreach (int x in pilhaB)
        {
            if (pilhaA.Contains(x)) /* Compara se o elemento está se repetindo, senão, adiciona na fila */
            {
                continue;
            }
            else
            {
                filaElementos.Enqueue(x);
            }
        }
        foreach (int x in pilhaA)
        {
            if (pilhaB.Contains(x))/* Faz a mesma comparação anterior, porém com a outra pilha agora */
            {
                continue;
            }
            else
            {
                filaElementos.Enqueue(x);
            }
        }
        return filaElementos;
    }
    static void Main()
    {
        Stack<int> pilhaA = new Stack<int>();
        Stack<int> pilhaB = new Stack<int>();
        Queue<int> filaElementosRep = new Queue<int>();
        Queue<int> filaElementosNRep = new Queue<int>();

        /* Função que preenche as duas pilhas com números aleatórios */
        pilhaA = PreenchePilha();
        pilhaB = PreenchePilha();

        /* Funções que conferem se o número está repetindo */
        filaElementosRep = ConfereRep(pilhaA, pilhaB);
        filaElementosNRep = ConfereNRep(pilhaA, pilhaB);

        /* 
        ----------- Código feito sem uso de função -----------
        Compara se o elemento x da pilhaA está contido também na pilha B, se sim adiciona na fila de repetidos, senão, na de não repetidos. 
        O primeiro foreach adiciona nos repetidos e a primeira parte dos não repetidos, o segundo termina de preencher os não repetidos.

        foreach (int x in pilhaA)
                {
                    if (pilhaB.Contains(x))
                    {
                        filaElementosRep.Enqueue(x);
                    }
                    else
                    {
                        filaElementosNRep.Enqueue(x);
                    }
                }
                foreach (int x in pilhaB)
                {
                    if (pilhaA.Contains(x))
                    {
                        continue;
                    }
                    else
                    {
                        filaElementosNRep.Enqueue(x);
                    }
                }
         */

        /* Mostra a fila de repetidos */
        System.Console.WriteLine("\n----- Elementos da Fila Repetidos -----");
        if (filaElementosRep.Count > 0)
        {
            foreach (int x in filaElementosRep)
                System.Console.Write($"{x,5} ");
        }

        /* Mostra a fila de não repetidos */
        System.Console.WriteLine("\n----- Elementos da Fila Não Repetidos -----");
        if (filaElementosNRep.Count > 0)
        {
            foreach (int x in filaElementosNRep)
                System.Console.Write($"{x,5} ");
        }
    }
}