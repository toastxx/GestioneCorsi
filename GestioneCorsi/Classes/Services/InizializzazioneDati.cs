using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Services
{
    public class InizializzazioneDati : IInizializzazioneDati
    {
        #region Fields
        private readonly IGestioneCorsi _gestioneCorsi;
        #endregion

        #region Constructor
        public InizializzazioneDati(IGestioneCorsi gestioneCorsi)
        {
            _gestioneCorsi = gestioneCorsi;
        }
        #endregion

        #region Methods
        public void InizializzaDatiEsempio()
        {
            // Aggiungi docenti
            _gestioneCorsi.AggiungiDocente("Mario", "Rossi", "Laurea in Informatica");
            _gestioneCorsi.AggiungiDocente("Giulia", "Bianchi", "Master in Data Science");
            _gestioneCorsi.AggiungiDocente("Luca", "Verdi", "PhD in Ingegneria Software");

            // Aggiungi aule
            _gestioneCorsi.AggiungiAula("Aula 101", 30, new List<string> { "Proiettore", "PC", "Lavagna" });
            _gestioneCorsi.AggiungiAula("Aula 202", 25, new List<string> { "Proiettore", "LIM", "Tablet" });
            _gestioneCorsi.AggiungiAula("Lab Informatica", 20, new List<string> { "PC", "Notebook", "Proiettore" });

            // Aggiungi corsi
            _gestioneCorsi.AggiungiCorso("Programmazione C#", 1);
            _gestioneCorsi.AggiungiCorso("Database Avanzato", 2);

            // Aggiungi studenti al primo corso
            _gestioneCorsi.AggiungiStudente(0, "Alessandro", "Neri", "M001");
            _gestioneCorsi.AggiungiStudente(0, "Sara", "Gialli", "M002");
            _gestioneCorsi.AggiungiStudente(0, "Marco", "Blu", "M003");
            _gestioneCorsi.AggiungiStudente(0, "Elena", "Rosa", "M004");
            _gestioneCorsi.AggiungiStudente(0, "Davide", "Viola", "M005");

            // Aggiungi studenti al secondo corso
            _gestioneCorsi.AggiungiStudente(1, "Francesca", "Marrone", "M006");
            _gestioneCorsi.AggiungiStudente(1, "Antonio", "Grigio", "M007");
            _gestioneCorsi.AggiungiStudente(1, "Chiara", "Azzurro", "M008");

            // Aggiungi lezioni al primo corso
            _gestioneCorsi.AggiungiLezione(0, "Introduzione a C#", new DateTime(2025, 1, 15), new TimeSpan(9, 0, 0), new TimeSpan(2, 0, 0), 0, 0);
            _gestioneCorsi.AggiungiLezione(0, "Variabili e Tipi di Dati", new DateTime(2025, 1, 17), new TimeSpan(9, 0, 0), new TimeSpan(2, 0, 0), 0, 0);
            _gestioneCorsi.AggiungiLezione(0, "Controllo di Flusso", new DateTime(2025, 1, 20), new TimeSpan(9, 0, 0), new TimeSpan(2, 0, 0), 0, 2);

            // Aggiungi lezioni al secondo corso
            _gestioneCorsi.AggiungiLezione(1, "Normalizzazione Database", new DateTime(2025, 1, 16), new TimeSpan(14, 0, 0), new TimeSpan(3, 0, 0), 1, 1);
            _gestioneCorsi.AggiungiLezione(1, "Query Avanzate", new DateTime(2025, 1, 18), new TimeSpan(14, 0, 0), new TimeSpan(3, 0, 0), 1, 1);

            Console.WriteLine("Dati di esempio inizializzati con successo!");
        }
        #endregion
    }
}