class Carro
{
    public string cor { get; set; }
    public string modelo { get; set; }

}
class Program
{
    static void AdicionarCarro(Queue<Carro> x)
    {
        if (x.Count < 8)
        {
            Carro xCarro = new Carro();
            System.Console.WriteLine("Insira a cor do carro");
            xCarro.cor = Console.ReadLine();
            System.Console.WriteLine("Insira o modelo do carro");
            xCarro.modelo = Console.ReadLine();
            x.Enqueue(xCarro);
        }
        else
        {
            System.Console.WriteLine("Não é possível adicionar mais carros, retire algum");
        }
    }
    static void RemoverCarro(Queue<Carro> x)
    {
        Carro auxCarro = new Carro(); // carro a ser removido
        Queue<Carro> filaAux = new Queue<Carro>(); // fila auxiliar usada para preencher a fila original
        bool carroRemovido = false;

        if (x.Count > 0)
        {
            Carro xCarro = new Carro();

            System.Console.WriteLine("Insira o modelo do carro que deseja remover");
            auxCarro.modelo = Console.ReadLine();
            System.Console.WriteLine("Insira a cor do carro que deseja remover");
            auxCarro.cor = Console.ReadLine();

            int fim = x.Count;
            for (int i = 0; i < fim; i++)
            {
                Carro carroAtual = x.Dequeue();
                if (!carroRemovido && carroAtual.cor == auxCarro.cor && carroAtual.modelo == auxCarro.modelo)
                {
                    carroRemovido = true;
                }
                else
                {
                    filaAux.Enqueue(carroAtual);
                }
            }

            while (filaAux.Count > 0)
            {
                x.Enqueue(filaAux.Dequeue());
            }
            if(carroRemovido==false)
            System.Console.WriteLine("\nCarro não foi encontrado para ser removido!\n");
        }
        else
        {
            System.Console.WriteLine("\nNão é possível adicionar nenhum carro, remova algum\n");
            return;
        }
    }
    static void ListarCarros(Queue<Carro> x)
    {
        if (x.Count == 0)
        {
            System.Console.WriteLine("Não há carros para listar\n");
        }
        else
        {
            int i = 1;
                System.Console.WriteLine("\n----------- Lista de carros no estacionamento -----------");
            foreach (Carro c in x)
            {
                System.Console.WriteLine($"Carro do modelo {c.modelo}, cor {c.cor}, posição:{i}");
                i++;
            }
            System.Console.WriteLine("");
        }
    }
    static void Main()
    {
        Queue<Carro> filaCarro = new Queue<Carro>();
        int resp;
        do
        {
            System.Console.WriteLine("1) Inserir carro\n2) Remover carro\n3) Listar carros\n4) Sair\n");
            resp = int.Parse(Console.ReadLine());

            switch (resp)
            {
                case 1:
                    AdicionarCarro(filaCarro);
                    break;

                case 2:
                    RemoverCarro(filaCarro);
                    break;

                case 3:
                    ListarCarros(filaCarro);
                    break;

                case 4:
                    System.Console.WriteLine("Saindo...");
                    break;

                default:
                    System.Console.WriteLine("Insira uma opção válida");
                    break;

            }
        } while (resp != 4);
    }
}