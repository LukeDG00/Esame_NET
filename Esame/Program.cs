using Esame.Classes;
using System.ComponentModel.Design;

namespace Esame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestore gestione = new Gestore();

            bool uscita = false;

            while (!uscita)
            {
                Console.WriteLine("\n--- Benvenuto nel programma di gestione Voli ---");
                Console.WriteLine("1. Aggiungi un volo");
                Console.WriteLine("2. Cerca un volo per codice");
                Console.WriteLine("3. Cambia stato di un volo");
                Console.WriteLine("4. Conta voli in un terminal");
                Console.WriteLine("5. Esporta voli in stato specifico in CSV");
                Console.WriteLine("6. Elenco destinazioni ordinate per numero di voli");
                Console.WriteLine("7. Rimuovi un volo");
                Console.WriteLine("8. Esci dal programma");
                Console.Write("Seleziona un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": // Aggiungi volo
                        AggiungiVolo(gestione);
                        break;

                    case "2": // Cerca volo
                        CercaVolo(gestione);
                        break;

                    case "3": // Cambia stato volo
                        CambiaStatoVolo(gestione);
                        break;

                    case "4": // Conta voli in un terminal
                        ContaVoliInTerminal(gestione);
                        break;

                    case "5": // Esporta voli in CSV
                        EsportaCSV(gestione);
                        break;

                    case "6": // Elenco destinazioni per numero di voli
                        ElencoDestinazioni(gestione);
                        break;

                    case "7": // Rimuovi volo
                        RimuoviVolo(gestione);
                        break;

                    case "8": // Uscita
                        uscita = true;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }

        static void AggiungiVolo(Gestore gestione)
        {
            Console.WriteLine("\n--- Aggiungi un volo ---");
            Console.Write("Codice volo: ");
            string codice = Console.ReadLine();
            Console.Write("Aeroporto di partenza: ");
            string partenza = Console.ReadLine();
            Console.Write("Aeroporto di destinazione: ");
            string destinazione = Console.ReadLine();
            Console.Write("Data e ora (es. AAAA-MM-DD hh:mm): ");
            string dataOra = Console.ReadLine();
            Console.Write("Terminal: ");
            string terminal = Console.ReadLine();
            Console.Write("Gate: ");
            string gate = Console.ReadLine();
            Console.Write("Stato: ");
            string stato = Console.ReadLine();

            Volo nuovoVolo = new Volo(codice, partenza, destinazione, dataOra, terminal, gate, stato);
            gestione.AggiungiVolo(nuovoVolo);
            Console.WriteLine("Volo aggiunto con successo.");
        }

        static void CercaVolo(Gestore gestione)
        {
            Console.Write("\nInserisci il codice del volo da cercare: ");
            string codice = Console.ReadLine();
            var dettagli = gestione.CercaVolo(codice);

            if (dettagli.HasValue)
            {
                Console.WriteLine($"Terminal: {dettagli.Value.Terminal}, Gate: {dettagli.Value.Gate}, Stato: {dettagli.Value.Stato}");
            }
            else
            {
                Console.WriteLine("Volo non trovato.");
            }
        }

        static void CambiaStatoVolo(Gestore gestione)
        {
            Console.Write("\nInserisci il codice del volo da modificare: ");
            string codice = Console.ReadLine();
            Console.Write("Inserisci il nuovo stato: ");
            string nuovoStato = Console.ReadLine();

            if (gestione.CambiaStatoVolo(codice, nuovoStato))
            {
                Console.WriteLine("Stato modificato con successo.");
            }
            else
            {
                Console.WriteLine("Volo non trovato.");
            }
        }

        static void ContaVoliInTerminal(Gestore gestione)
        {
            Console.Write("\nInserisci il terminal: ");
            string terminal = Console.ReadLine();
            Console.WriteLine("Inserisci gli stati separati da virgola (es. Imbarco in corso, In partenza): ");
            string[] stati = Console.ReadLine().Split(',');

            int numeroVoli = gestione.ContaVoliInTerminal(terminal, stati);
            Console.WriteLine($"Numero di voli in {terminal} con gli stati specificati: {numeroVoli}");
        }

        static void EsportaCSV(Gestore gestione)
        {
            Console.Write("\nInserisci lo stato dei voli da esportare: ");
            string stato = Console.ReadLine();
          
            gestione.EsportaCSV(stato);
            Console.WriteLine($"Voli con stato '{stato}' esportati");
        }

        static void ElencoDestinazioni(Gestore gestione)
        {
            var destinazioni = gestione.ElencoDestinazioni();
            Console.WriteLine("\nElenco destinazioni per numero di voli:");
            foreach (var destinazione in destinazioni)
            {
                Console.WriteLine($"{destinazione.destinazione} - {destinazione.numeroVoli} voli");
            }
        }

        static void RimuoviVolo(Gestore gestione)
        {
            Console.Write("\nInserisci il codice del volo da rimuovere: ");
            string codice = Console.ReadLine();

            if (gestione.RimuoviVolo(codice))
            {
                Console.WriteLine("Volo rimosso con successo.");
            }
            else
            {
                Console.WriteLine("Volo non trovato.");
            }
        }
    }
}
