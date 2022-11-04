// See https://aka.ms/new-console-template for more information
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

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
//myBiblioteca.StampaUtenti();
//myBiblioteca.StampaLibri();
//myBiblioteca.StampaDVDs();
myBiblioteca.RicercaDocumento();

public class Prestito
{

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
        Libri.Add(new Libro("Pepe", 2020, "natura", true, 15, "Sandra", "3477890", 160));


        //creazione DVDs
        DVDs = new List<DVD>();
        DVDs.Add(new DVD("abcd", 1988, "politica", true, 50, "Genoveffa", "159357", 60));
        DVDs.Add(new DVD("efgh", 1999, "documentario", false, 48, "Lorenzo", "3478519", 120));
        DVDs.Add(new DVD("ilmn", 1998, "documentario", true, 48, "Lorenzo", "3478519", 120));
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
    public void RicercaDocumento()
    {
        Console.WriteLine("Vuoi cercare un libro o un dvd? [libro/dvd] ");
        string userInput = Console.ReadLine();
        if (userInput == "libro")
        {
            Console.WriteLine("Scrivi il codice o il titolo del libro da cercare: ");
            string userInputLibro = Console.ReadLine();

            foreach (Libro libro in Libri)
            {
                if (userInputLibro == libro.Titolo || userInputLibro == libro.ISBN)
                {
                    if (libro.Stato == true)
                    {

                        Console.WriteLine("il libro ricercato è disponibile");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("il libro non è disponibile");
                    }
                }
            }
        }
        else if (userInput == "dvd")
        {
            Console.WriteLine("Scrivi il codice o il titolo del DVD da cercare: ");
            string userInputDVD = Console.ReadLine();

            foreach (DVD dvd in DVDs)
            {
                if (userInputDVD == dvd.Titolo || userInputDVD == dvd.NumSeriale)
                {
                    if(dvd.Stato == true)
                    {

                        Console.WriteLine("il DVD ricercato è disponibile");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("il DVD non è disponibile");
                    }
                }
            }

        }
        else
        {
            Console.WriteLine("inserisci un valore corretto");
            RicercaDocumento();
        }
    }

}
