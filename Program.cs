// See https://aka.ms/new-console-template for more information
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");


//Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati
//cognome,
//nome,
//email,
//recapito telefonico,
//Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il sistema, sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//Il bibliotecario deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un cliente.
//Mi raccomando, prima di buttarvi sul codice fate qualche schema per capire le entità principali e le loro relazioni / eredità.
//Buon lavoro! (modificato) 

Biblioteca myBiblioteca = new Biblioteca();
myBiblioteca.StampaUtenti();
myBiblioteca.StampaLibri();
myBiblioteca.StampaDVDs();

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

public class Biblioteca
{
    public List<Utente> Utenti { get; set; }
    public List<Libro> Libri { get; set; }
    public List<DVD> DVDs { get; set; }

    public Biblioteca()
    {
        //creazione utenti
        Utenti = new List<Utente>();
        Utente utente1 = new Utente("Ficini", "Sandro", "sandro@email.com", 323445454);
        Utenti.Add(utente1);
        Utenti.Add(new Utente("Chicco", "Oca", "oca@email.com", 323368454));

        //creazione libri
        Libri = new List<Libro>();
        Libri.Add(new Libro("Chicco", 2022, "natura", true, 20, "Sandro", "4302890", 100));
        Libri.Add(new Libro("Grisea", 2021, "natura", false, 15, "Sandra", "3477890", 150));

        //creazione DVDs
        DVDs = new List<DVD>();
        DVDs.Add(new DVD("abcd", 1988, "politica", true, 50, "Genoveffa", "159357", 60));
        DVDs.Add(new DVD("efgh", 1999, "documentario", false, 48, "Lorenzo", "3478519", 120));
    }

    public void StampaUtenti()
    {
        Console.WriteLine("Gli utenti: ");
        foreach(Utente utente in Utenti)
        {
            Console.WriteLine(utente.Cognome);
            Console.WriteLine(utente.Nome);
            Console.WriteLine(utente.Email);
            Console.WriteLine(utente.Telefono);
            Console.WriteLine("--------------");
        }
    }
    public void StampaLibri()
    {
        Console.WriteLine("I libri in archivio sono: ");
        foreach (Libro libro in Libri)
        {
            Console.WriteLine(libro.Titolo);
            Console.WriteLine(libro.Anno);
            Console.WriteLine(libro.Settore);
            Console.WriteLine(libro.Stato);
            Console.WriteLine(libro.Scaffale);
            Console.WriteLine(libro.Autore);
            Console.WriteLine(libro.ISBN);
            Console.WriteLine(libro.Pagine);
            Console.WriteLine("--------------");
        }
    }
    public void StampaDVDs()
    {
        Console.WriteLine("I DVDs in archivio sono: ");
        foreach (DVD dvd in DVDs)
        {
            Console.WriteLine(dvd.Titolo);
            Console.WriteLine(dvd.Anno);
            Console.WriteLine(dvd.Settore);
            Console.WriteLine(dvd.Stato);
            Console.WriteLine(dvd.Scaffale);
            Console.WriteLine(dvd.Autore);
            Console.WriteLine(dvd.NumSeriale);
            Console.WriteLine(dvd.Durata);
            Console.WriteLine("--------------");
        }
    }

}