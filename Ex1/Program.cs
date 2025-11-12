class Carro
{
    public string cor { get; set; }
    public string modelo { get; set; }

}
class Program
{
    static void AdicionarCarro(Queue<Carro> x) /* Código símples para adicionar os carros à fila, que informa se a fila já está completa com os 8 carros */
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
        Carro auxCarro = new Carro(); // Elemento que carrega as informações do carro a ser removido
        Queue<Carro> filaAux = new Queue<Carro>(); // fila auxiliar que guarda os carros que não devem ser removidos antes do carro ser removido
        Queue<Carro> filaAux2 = new Queue<Carro>();// fila auxiliar que guarda os carros que não devem ser removidos após do carro ser removido

        bool carroRemovido = false; /* Variável que confirma que o carro foi removido */

        if (x.Count > 0)
        {
            System.Console.WriteLine("Insira o modelo do carro que deseja remover");
            auxCarro.modelo = Console.ReadLine();
            System.Console.WriteLine("Insira a cor do carro que deseja remover");
            auxCarro.cor = Console.ReadLine();

            int fim = x.Count;
            for (int i = 0; i < fim; i++)
            {
                Carro carroAtual = x.Dequeue(); /* carroAtual recebe o carro que foi removido da fila */
                if (!carroRemovido && carroAtual.cor == auxCarro.cor && carroAtual.modelo == auxCarro.modelo)
                {
                    carroRemovido = true; /* aqui mostra que o carro foi removído */
                }
                else if (carroRemovido)
                {
                    filaAux2.Enqueue(carroAtual); /* Se o carro for removido, guardará nessa fila que montará a nova ordem, já que os carros da frente devem voltar para o início */
                }
                else
                {
                    filaAux.Enqueue(carroAtual); /* Se o carro não é o correto a ser removido e o carro correto não foi removído, é adicionado na fila auxiliar */
                }
            }
            /* Fila original vazia, e fila auxiliar com os carros sem o que deve ser removido */

            while (filaAux.Count > 0) /* Preenchimento da fila original com os carros corretos */
            {
                if (filaAux2.Count > 0)
                    x.Enqueue(filaAux2.Dequeue());
                else
                    x.Enqueue(filaAux.Dequeue());
            }
            if (carroRemovido == false)
                System.Console.WriteLine("\nCarro não foi encontrado para ser removido!\n");
        }
        else
        {
            System.Console.WriteLine("\nNão há carros para remover\n");
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