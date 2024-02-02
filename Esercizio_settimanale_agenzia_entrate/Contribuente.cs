using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_settimanale_agenzia_entrate
{
    internal class Contribuente
    {

            // Proprietà della classe Contribuente
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }
            public string CodiceFiscale { get; set; }
            public char Genere { get; set; }
            public string ComuneResidenza { get; set; }
            public double RedditoAnnuale { get; set; }

            // Costruttore della classe Contribuente
            public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
            {
                Nome = nome;
                Cognome = cognome;
                DataNascita = dataNascita;
                CodiceFiscale = codiceFiscale;
                Genere = sesso;
                ComuneResidenza = comuneResidenza;
                RedditoAnnuale = redditoAnnuale;
            }

            // Metodo della classe Contribuente per il calcolo dell'imposta
            public double CalcolaImposta()
            {
                double imposta = 0;

                if (RedditoAnnuale <= 15000)
                {
                    imposta = RedditoAnnuale * 0.23; // aliquota 23%
                }
                else if (RedditoAnnuale <= 28000)
                {
                    imposta = 3450 + (RedditoAnnuale - 15000) * 0.27; // 3.450 + aliquota 27% sulla parte eccedente i 15.000
                }
                else if (RedditoAnnuale <= 55000)
                {
                    imposta = 6960 + (RedditoAnnuale - 28000) * 0.38; // 6.960 + 38% sulla parte eccedente i 28.000
                }
                else if (RedditoAnnuale <= 75000)
                {
                    imposta = 17220 + (RedditoAnnuale - 55000) * 0.41; // 17.220 + 41% sulla parte eccedente i 55.000
                }
                else
                {
                    imposta = 25420 + (RedditoAnnuale - 75000) * 0.43; // 25.420 + 43% sulla parte eccedente i 75.000
                }

                return imposta;
            }
    }
}
