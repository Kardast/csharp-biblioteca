// See https://aka.ms/new-console-template for more information
public class Prestito
{
    public string Nome { get; set; }
    public string NomeUtente { get; set; }
    public string CognomeUtente { get; set; }
    public string DataPrestito { get; set; }
    public string DataRestituzione { get; set; }

    public Prestito(string nome, string nomeUtente, string cognomeUtente, string dataPrestito, string dataRestituzione)
    {
        Nome = nome;
        NomeUtente = nomeUtente;
        CognomeUtente = cognomeUtente;
        DataPrestito = dataPrestito;
        DataRestituzione = dataRestituzione;
    }
}
