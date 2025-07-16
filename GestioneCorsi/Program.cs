using GestioneCorsi.Classes;
using GestioneCorsi.Classes.Interfaces;
using GestioneCorsi.Classes.Services;
using SistemaGestioneCorsi.Services;

namespace GestioneCorsi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inizializzazione delle dipendenze
            IGestioneCorsi gestioneCorsi = new SistemaGestioneCorsi.Services.GestioneCorsi();
            IVisualizzazioni visualizzazioni = new Visualizzazioni(gestioneCorsi);
            IInizializzazioneDati inizializzazione = new InizializzazioneDati(gestioneCorsi);
            IMenuNavigazione menu = new MenuNavigazione(gestioneCorsi, visualizzazioni, inizializzazione);

            // Avvio dell'applicazione
            menu.MostraMenuPrincipale();
        }
    }
}