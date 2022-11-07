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
myBiblioteca.RicercaPrestiti();

public class Biblioteca
{
    public List<Utente> Utenti { get; set; }
    public List<Libro> Libri { get; set; }
    public List<DVD> DVDs { get; set; }
    public List<Prestito> Prestiti { get; }

    public Biblioteca()
    {
        //creazione utenti
        Utenti = new List<Utente>();
        Utente utente1 = new Utente("Ficini", "Sandro", "sandro@email.com", 323445454);
        Utenti.Add(utente1);
        Utenti.Add(new Utente("Chicco", "Oca", "oca@email.com", 323368454));
        Utenti.Add(new Utente("Rossi", "Paolo", "paolorossi@gmail.com", 334303045));
        Utenti.Add(new Utente("Arrigoni", "Luca", "lucaarrigoni@gmail.com", 334364045));
        Utenti.Add(new Utente("Elia", "Federica", "federicaelia@gmail.com", 331324045));

        //creazione libri
        Libri = new List<Libro>();
        Libri.Add(new Libro("Chicco", 2022, "natura", true, 20, "Sandro", "9788804577032", 100));
        Libri.Add(new Libro("Grisea", 2021, "natura", false, 15, "Sandra", "9788804577031", 150));
        Libri.Add(new Libro("Pepe", 2020, "natura", true, 15, "Sandra", "9788804577030", 160));
        Libri.Add(new Libro("La solitudine dei numeri primi", 2008, "Romanzo", true, new Random().Next(0, 101), "Paolo Giordano", "9788804577027", 304));
        Libri.Add(new Libro("L'isola della paura", 2013, "Thriller psicologico", false, new Random().Next(0, 101), "Dennis Lehane", "9788868366216", 436));
        Libri.Add(new Libro("Il silenzio degli innocenti", 1988, "Thriller psicologico", true, new Random().Next(0, 101), "Thomas Harris", "9788804333746", 388));

        //creazione DVDs
        DVDs = new List<DVD>();
        DVDs.Add(new DVD("abcd", 1988, "politica", true, 50, "Genoveffa", "159357", 60));
        DVDs.Add(new DVD("efgh", 1999, "documentario", false, 48, "Lorenzo", "3478519", 120));
        DVDs.Add(new DVD("ilmn", 1998, "documentario", true, 48, "Lorenzo", "3478519", 120));
        DVDs.Add(new DVD("Avatar", 2008, "Fantascienza", true, new Random().Next(0, 101), "Paolo Giordano", "9788804577027", 304));
        DVDs.Add(new DVD("Shutter Island", 2013, "Thriller psicologico", false, new Random().Next(0, 101), "Dennis Lehane", "9788868366216", 436));
        DVDs.Add(new DVD("Il miglio verde", 1988, "Thriller psicologico", true, new Random().Next(0, 101), "Thomas Harris", "9788804333746", 388));

        //creazione prestiti
        Prestiti = new List<Prestito>();
        Prestiti.Add(new Prestito("Il silenzio degli innocenti", "Federica", "Elia", "05/11/22", "07/11/22"));
        Prestiti.Add(new Prestito("Mannaggia buddha elettrico", "Federica", "Elia", "05/11/22", "07/11/22"));
        Prestiti.Add(new Prestito("Shutter Island", "Sandro", "Ficini", "05/11/22", "07/11/22"));
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
        //scelta del tipo documento
        Console.WriteLine("Vuoi cercare un libro o un dvd? [libro/dvd] ");
        string userInput = Console.ReadLine();

        //if libro
        if (userInput == "libro")
        {
            Console.WriteLine("Scrivi il codice o il titolo del libro da cercare: ");
            string userInputDoc = Console.ReadLine();

            foreach (Libro libro in Libri)
            {
                if (userInputDoc == libro.Titolo || userInputDoc == libro.ISBN)
                {
                    if (libro.Stato == true)
                    {

                        Console.WriteLine("il libro ricercato è disponibile");
                        EffettuaPrestito(userInputDoc);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("il libro non è disponibile");
                    }
                }
            }
        }
        //if dvd
        else if (userInput == "dvd")
        {
            Console.WriteLine("Scrivi il codice o il titolo del DVD da cercare: ");
            string userInputDoc = Console.ReadLine();

            foreach (DVD dvd in DVDs)
            {
                if (userInputDoc == dvd.Titolo || userInputDoc == dvd.NumSeriale)
                {
                    if(dvd.Stato == true)
                    {

                        Console.WriteLine("il DVD ricercato è disponibile");
                        EffettuaPrestito(userInputDoc);
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
    public void EffettuaPrestito(string userInputDoc)
    {
        Console.WriteLine("Vuoi prenderlo in prestito? [si/no]");
        string userDocPrestito = Console.ReadLine();
        if(userDocPrestito == "si")
        {
            Console.WriteLine("Inserisci il tuo nome");
            string userName = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome");
            string userSurname = Console.ReadLine();
            Console.WriteLine("Inserisci la data di inizio prestito");
            string startPrestito = Console.ReadLine();
            Console.WriteLine("Inserisci la data di fine prestito");
            string endPrestito = Console.ReadLine();
            Prestito prestitoUno = new Prestito(userInputDoc, userName, userSurname, startPrestito, endPrestito);
            Console.WriteLine("Hai effettuato il prestito di: " + prestitoUno.Nome + " dal: " + prestitoUno.DataPrestito + " al: " + prestitoUno.DataRestituzione);
            Console.WriteLine("Utente: " + prestitoUno.NomeUtente + ", "+ prestitoUno.CognomeUtente);
            Prestiti.Add(prestitoUno);
        }
        else
        {
            RicercaDocumento();
        }
    }

    public void RicercaPrestiti()
    {
        Console.WriteLine("Stai cercando i prestiti associati a quale utente? Inserire nome");
        string inputPrestito = Console.ReadLine();
        bool presente = false;
        foreach (Prestito prestito in Prestiti)
        {
            if (inputPrestito == prestito.NomeUtente)
            {
                presente = true;
            }

        }
        if (presente == true)
        {
            Console.WriteLine("I prestiti associati all'utente selezionato sono:");
            foreach (Prestito prestito in Prestiti)
            {
                if(inputPrestito == prestito.NomeUtente)
                {

                    Console.WriteLine(prestito.Nome + ", in prestito dal: " + prestito.DataPrestito + " al: " + prestito.DataRestituzione);
                }
            }
        }
        else
        {
            Console.WriteLine("Non sono presenti prestiti associati all'utente richiesto");
        }
    }
}
