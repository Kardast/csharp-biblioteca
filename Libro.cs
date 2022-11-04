// See https://aka.ms/new-console-template for more information
public class Libro : Documento
{
    //props
    public string ISBN { get; set; }
    public int Pagine { get; set; }

    //costruttore
    public Libro(string titolo, int anno, string settore, bool stato, int scaffale, string autore, string isbn, int pagine) : base(titolo, anno, settore, stato, scaffale, autore)
    {
        ISBN = isbn;
        Pagine = pagine;
    }
}
