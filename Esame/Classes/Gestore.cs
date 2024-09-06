using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame.Classes
{
    internal class Gestore
    {
        private List<Volo> voli = new List<Volo>();

        
        public void AggiungiVolo(Volo volo)
        {
            voli.Add(volo);
        }

        
        public (string AeroportoPartenza,string AeroportoDestinazione, string Terminal, string Gate, string Stato)? CercaVolo(string codice)
        {
            var volo = voli.FirstOrDefault(v => v.Codice == codice);
            if (volo != null)
            {
                return (volo.AeroportoPartenza,volo.AeroportoDestinazione,volo.Terminal, volo.Gate, volo.Stato);
            }
            return null;
        }

        
        public bool CambiaStatoVolo(string codice, string nuovoStato)
        {
            var volo = voli.FirstOrDefault(v => v.Codice == codice);
            if (volo != null)
            {
                volo.Stato = nuovoStato;
                return true;
            }
            return false;
        }

        
        public int ContaVoliInTerminal(string terminal, string[] stati)
        {
            return voli.Count(v => v.Terminal == terminal && stati.Contains(v.Stato));
        }

        
        public void EsportaCSV(string stato)
        {
           
            var voliInStato = voli.Where(v => v.Stato == stato).ToList();
            using (StreamWriter sw = new StreamWriter("C:\\Users\\lucad\\OneDrive\\Desktop\\ElencoVoli.csv"))
            {
                sw.WriteLine("Codice | Partenza | Destinazione | Data e Ora  | Terminal | Gate | Stato");
                foreach (var volo in voliInStato)
                {
                    sw.WriteLine($"{volo.Codice},{volo.AeroportoPartenza},{volo.AeroportoDestinazione},{volo.DataOra},{volo.Terminal},{volo.Gate},{volo.Stato}");
                }
            }
        }

        
        public List<(string destinazione, int numeroVoli)> ElencoDestinazioni()
        {
            return voli.GroupBy(v => v.AeroportoDestinazione)
                       .Select(g => (g.Key, g.Count()))
                       .OrderBy(x => x.Item2)
                       .ToList();
        }

        
        public List<Volo> GetVoli()
        {
            return voli;
        }

        
        public bool RimuoviVolo(string codice)
        {
            var volo = voli.FirstOrDefault(v => v.Codice == codice);
            if (volo != null)
            {
                voli.Remove(volo);
                return true;
            }
            return false;
        }
    }
}
