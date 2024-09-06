using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Esame.Classes
{
    internal class Volo
    {
        public string? Codice { get; set; }
        public string? AeroportoPartenza { get; set; }
        public string? AeroportoDestinazione { get; set; }
        public string? DataOra { get; set; } 
        public string? Terminal { get; set; }
        public string? Gate { get; set; }
        public string? Stato { get; set; } 
        public Volo(string codice, string  aeroportoPartenza, string aeroportoDestinazione,
                    string dataOra, string terminal, string gate, string stato)
        {
            Codice = codice;
            AeroportoPartenza = aeroportoPartenza;
            AeroportoDestinazione = aeroportoDestinazione;
            DataOra = dataOra;
            Terminal = terminal;
            Gate = gate;
            Stato = stato;
        }
    }
}



