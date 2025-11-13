
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
    public Fila()
    {
        inicio = null;
        fim = null;
    }
    public void InserirCarro(string cor, string modelo)
    {
        Carro novoCarro = new Carro();
        novoCarro.cor = cor;
        novoCarro.modelo = modelo;
        inicio = novoCarro;
        fim = novoCarro;
    }
    public void MostraFila()
    {
        aux = inicio;
        while (aux != null)
        {
            System.Console.Write($"aux.num,5");
            aux = aux.prox;
        }
    }
}
class Program
{
    static void Main()
    {
        int resp = 0;
        do
        {
            switch (resp)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    System.Console.WriteLine("Encerrando");
                    break;
                default:
                    System.Console.WriteLine("Insira uma opção válida");
                    break;
            }
        } while (resp != 4);
    }
}