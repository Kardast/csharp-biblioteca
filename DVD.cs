// See https://aka.ms/new-console-template for more information
public class DVD : Documento
{
    //props
    public string NumSeriale { get; set; }
    public int Durata { get; set; }

    //costruttore
    public DVD(string titolo, int anno, string settore, bool stato, int scaffale, string autore, string numSeriale, int durata) : base (titolo, anno, settore, stato, scaffale, autore)
    {
        NumSeriale = numSeriale;
        Durata = durata;
    }
}
