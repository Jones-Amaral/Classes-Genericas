using System.Net.WebSockets;
using System.Runtime.InteropServices;

class Cidade
{
    public string nome { get; set; }
    public int lat { get; set; }
    public int lon { get; set; }
    public void AddCidade(Queue<Cidade> cidades) /* Adiciona cidades dentro da fila */
    {
        Cidade exCid;
        string resp;
        do
        {
            exCid = new Cidade();
            System.Console.WriteLine("Insira o nome da cidade que deseja visitar");
            exCid.nome = Console.ReadLine();
            System.Console.WriteLine("A latitude");
            exCid.lat = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Insira a longitude");
            exCid.lon = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Deseja inserir outra cidade? (n para sair)");
            resp = Console.ReadLine();
            cidades.Enqueue(exCid);
        } while (resp != "n");

    }
    public double DistanciaPercorrida(Queue<Cidade> cidades) /* Calcula a distância percorrida entre cidades */
    {
        double dist = 0, totaldist = 0;/* distancia entre cidade A e B, e soma total das distâncias */
        Cidade ant = null; /* Elemento aux que grava a cidade anterior */
        Cidade penultima = null; /* Grava a cidade anterior no foreach, para caso B<->C, ou seja ímpar */
        Cidade ultima = null; /* Grava a cidade mais recente do foreach */
        foreach (Cidade x in cidades) /* Calcula a distância entre as cidades em pares */
        {
            if (ant == null) /* Confere se é a primeira cidade */
            {
                ant = x; /* Grava a primeira cidade como a anterior */
            }
            else
            {
                dist = Math.Sqrt(Math.Pow(x.lat - ant.lat, 2) + Math.Pow(x.lon - ant.lon, 2));
                ant = x; /* Para o próximo par */
             /*  */   totaldist += dist;
            }
            penultima = x;
        }
        if (cidades.Count > 1 && cidades.Count % 2 != 0) /* Caso haja um número ímpar de cidades */
        {

            foreach (Cidade c in cidades)
            {
                ultima = c;
            }
            dist = Math.Sqrt(Math.Pow(ultima.lat - penultima.lat, 2) + Math.Pow(ultima.lon - penultima.lon, 2));
            totaldist += dist;

        }
        return totaldist;
    }
}
class Program
{
    static void Main()
    {
        Queue<Cidade> cidades = new Queue<Cidade>();
        Cidade cid = new Cidade();
        cid.AddCidade(cidades);
        System.Console.WriteLine($"A distância total percorrida foi de {cid.DistanciaPercorrida(cidades)}");

    }
}