using System.ComponentModel;

class Carro
{
    public string cor { get; set; }
    public string modelo { get; set; }
    public Carro prox;
    public Carro()
    {
        prox = null;
    }
}
class Fila
{
    private Carro inicio;
    private Carro fim;
    private Carro aux;
    private Carro ant;

    public Fila()
    {
        inicio = null;
        fim = null;
    }
    public void InserirCarro(ref int count)
    {
        Carro novo = new Carro();

        System.Console.WriteLine("Insira a cor do carro que deseja adicionar");
        novo.cor = Console.ReadLine();
        System.Console.WriteLine("Insira o modelo do carro que deseja adicionar");
        novo.modelo = Console.ReadLine();

        if (count < 8) // Verifica se a fila está cheia
        {
            if (inicio == null) /* Se não há nenhum carrro na fila, adiciona como o primeiro */
            {
                inicio = novo;
                fim = novo;
                fim.prox = inicio;
            }
            else /* Se houver algum carro na fila, adiciona no primeiro lugar à esquerda, ou seja, no fim da fila */
            {
                fim.prox = novo;
                fim = novo;
                fim.prox = inicio;
            }
            count++; /* Adiciona 1 para o contador de carros */
            Console.Clear();
        }
        else
        {
            System.Console.WriteLine("Não é possível inserir mais carros na fila.");
        }
    }
    public void MostraFila(ref int count)
    {
        int cont = 0;
        aux = inicio;
        Console.Clear();
        while (cont < count) /* Contador iniciado em 0 que conta até Count, que é o número de carros na fila */
        {
            System.Console.Write($"{aux.modelo,5} - {aux.cor,5}\t");
            aux = aux.prox; /* A fila anda com a variável aux, puxando para a próxima */
            cont++;
        }
        System.Console.WriteLine("");
    }

    public void RemoverCarro(string cor, string modelo, ref int count)
    {
        for (int i = 0; i < count; i++)  /* for que tem limite no número de carros da fila */
        {
            if (inicio.cor == cor && inicio.modelo == modelo)
            {
                if (inicio == fim) /* Se houver somente 1 carro, o inicio e fim recebem null */
                {
                    inicio = null;
                    fim = null;
                }
                else
                {
                    inicio = inicio.prox; /* O próximo carro vira o inicio */
                    fim.prox = inicio; /* O fim aponta para o início, fazendo a fila circular */
                }
                count--;
                return; /* Se achou o modelo específico que deve ser removido, sai do for */
            }
            else
            {
                Carro novo = inicio; /* Guarda o inicio */
                inicio = inicio.prox; /* Faz a fila andar */
                fim.prox = novo;  /* aponta para o último */
                fim = novo; /* atualiza o  ifm */
                fim.prox = inicio; /* mantém a fila circular */
            }
        }
    }


}
class Program
{
    static void Menu()
    {
        System.Console.WriteLine("1) Inserir\n2) Remover\n3) Listar carros\n4) Encerrar Programa");
    }
    static void Main()
    {
        Fila filaCarros = new Fila();
        int count = 0,resp;
        string cor, modelo;
        do
        {
            Menu();
            System.Console.WriteLine("Selecione uma opção");
            resp = int.Parse(Console.ReadLine());
            switch (resp)
            {
                case 1:
                    filaCarros.InserirCarro(ref count);
                    break;
                case 2:
                    System.Console.WriteLine("Insira o modelo de carro que deseja remover");
                    modelo = Console.ReadLine();
                    System.Console.WriteLine("Insira a cor do carro que deseja remover");
                    cor = Console.ReadLine();
                    filaCarros.RemoverCarro(cor, modelo, ref count);
                    break;
                case 3:
                    filaCarros.MostraFila(ref count);
                    break;
                case 4:
                    System.Console.WriteLine("Encerrando...");
                    break;
                default:
                    System.Console.WriteLine("Insira uma opção válida!");
                    break;
            }
        } while (resp != 4);
    }
}