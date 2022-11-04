// See https://aka.ms/new-console-template for more information
public class Documento
{
    //props
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool Stato { get; set; }
    public int Scaffale { get; set; }
    public string Autore { get; set; }


    //costruttore
    public Documento(string titolo, int anno, string settore, bool stato, int scaffale, string autore)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
    }

}
