// See https://aka.ms/new-console-template for more information
public class Utente
{
    //props
    public string Cognome {get; set;}
    public string Nome {get; set;}
    public string Email { get; set;}
    public int Telefono {get; set;}

    //costruttore
    public Utente(string cognome, string nome, string email, int telefono)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Telefono = telefono;
    }
}
