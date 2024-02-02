using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_settimanale_agenzia_entrate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string cognome;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");

            // Richiesta delle proprietà del contribuente



            do// QUI FACCIO UN CICLO DO WHILE PER VERIFICARE CHE I CARATTERI INSERITI SIANO QUELLI CORRETTI OVVERO NIENTE NUMERI E NIENTE SPAZI VUOTI.
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Inserisci il tuo nome:");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome) || int.TryParse(nome, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dati inseriti non corretti.");
                }
            } while (string.IsNullOrWhiteSpace(nome) || int.TryParse(nome, out _));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Il nome inserito è: {nome}");

            //SEIONE COGNOME

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Inserisci il tuo cognome:");
                cognome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cognome) || int.TryParse(cognome, out _))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dati inseriti non corretti.");
                }
            } while (string.IsNullOrWhiteSpace(cognome) || int.TryParse(cognome, out _));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Il cognome inserito è: {cognome}");

            //SEZIONE DATA DI NASCITA

            Console.ForegroundColor = ConsoleColor.White;
            bool continua = true; // variabile per controllare il ciclo
            while (continua) // ciclo while che si ripete finché continua è vero
            {
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Inserisci la data di nascita nel formato gg/mm/aa): ");
                DateTime dataNascita;

                try
                {
                    dataNascita = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato data non valido. Inserire la data nel formato gg/mm/aa.");
                    continue; // salta il resto del ciclo e riparte dall'inizio
                }
                // se il codice arriva qui, significa che la data di nascita è valida
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data di nascita inserita correttamente.");
               
                //SEZIONE CODICE FISCALE

                string codiceFiscale; // variabile per memorizzare il codice fiscale
                bool valido; // variabile per controllare la validità del codice fiscale
                do // inizia il ciclo
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Inserisci il tuo codice fiscale: ");
                    codiceFiscale = Console.ReadLine().ToUpper(); // converto l'input in maiuscolo
                    if (codiceFiscale.Length == 16) // se il codice fiscale ha 16 caratteri, è valido
                    {
                        valido = true; // imposta la variabile a vero
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Codice fiscale inserito correttamente");
                    }
                    else // altrimenti, il codice fiscale non è valido
                    {
                        valido = false; // imposta la variabile a falso
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Codice fiscale non valido.");
                    }
                } while (!valido); // continua il ciclo finché il codice fiscale non è valido

                char Sesso;
                bool cf;

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Inserisci il tuo genere (M/F):");
                    Sesso = Console.ReadLine().ToUpper()[0]; // Uso [0] per ottenere il primo carattere della stringa
                    if (Sesso == 'M' || Sesso == 'F') // Uso gli apici singoli per i caratteri
                    {
                        cf = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Genere inserito correttamente");
                    }
                    else
                    {
                        cf = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Genere non valido");
                    }
                } while (cf == false); // Aggiungo una condizione per il ciclo do-while



                /*do //ALTRO METODO TESTATO PER L'INSERIMENTO TRAMITE TASTO TASTIERA
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Inserisci il tuo genere (M/F):");
                    Sesso = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                } while (Sesso != 'M' && Sesso != 'F');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Il genere inserito è: {Sesso}");*/


                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Inserisci comune di residenza: ");
                string comuneResidenza = Console.ReadLine();

                Console.WriteLine("Inserisci il reddito annuale: ");
                double redditoAnnuale;
                try
                {
                    redditoAnnuale = double.Parse(Console.ReadLine()); // Prova a convertire l'input in un numero
                }
                catch (FormatException e) // Cattura l'eccezione se il formato dell'input è errato
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Errore: devi inserire un numero.");
                    Console.WriteLine(e.Message); // Stampa il messaggio dell'eccezione
                    redditoAnnuale = 0; // Assegna un valore di default a redditoAnnuale
                }

                    // Creazione dell'oggetto Contribuente
                    Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, Sesso, comuneResidenza, redditoAnnuale);

                // Calcolo dell'imposta
                double imposta = contribuente.CalcolaImposta();


                // Stampa del risultato riepilogativo
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================================================");
                Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome},");
                Console.WriteLine($"Nato il: {contribuente.DataNascita.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Genere: {Sesso}");
                Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
                Console.WriteLine($"codice fiscale: {contribuente.CodiceFiscale}");
                Console.WriteLine($"Reddito dichiarato: Euro {contribuente.RedditoAnnuale}");
                Console.WriteLine("==================================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"IMPOSTA DA VERSARE: Euro {imposta}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("...Premi il tasto ESC per chiudere la console");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}