using GestioneCorsi.Classes.Interfaces;

namespace SistemaGestioneCorsi.Services
{
    public class Visualizzazioni : IVisualizzazioni
    {
        #region Fields
        private readonly IGestioneCorsi _gestioneCorsi;
        #endregion

        #region Constructor
        public Visualizzazioni(IGestioneCorsi gestioneCorsi)
        {
            _gestioneCorsi = gestioneCorsi;
        }
        #endregion

        #region Methods
        public void MostraElencoCorsi()
        {
            Console.WriteLine("\n=== ELENCO CORSI ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (corsi.Count == 0)
            {
                Console.WriteLine("Nessun corso disponibile.");
                return;
            }

            foreach (var corso in corsi)
            {
                Console.WriteLine($"- {corso} (Studenti: {corso.Studenti.Count}, Lezioni: {corso.Lezioni.Count})");
            }
        }

        public void MostraLezioniCorso(int indiceCorso)
        {
            Console.WriteLine("\n=== LEZIONI CORSO ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (indiceCorso < 0 || indiceCorso >= corsi.Count)
            {
                Console.WriteLine("Corso non valido.");
                return;
            }

            var corso = corsi[indiceCorso];
            Console.WriteLine($"\nLezioni del corso: {corso}");

            if (corso.Lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna lezione disponibile.");
                return;
            }

            for (int i = 0; i < corso.Lezioni.Count; i++)
            {
                var lezione = corso.Lezioni[i];
                Console.WriteLine($"{i + 1}. {lezione}");
                Console.WriteLine($"   Docente: {lezione.Docente}");
                Console.WriteLine($"   Aula: {lezione.Aula.Nome}");
                Console.WriteLine($"   Presenti: {lezione.Presenti.Count}");
            }
        }

        public void MostraIscrittiCorso(int indiceCorso)
        {
            Console.WriteLine("\n=== ISCRITTI CORSO ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (indiceCorso < 0 || indiceCorso >= corsi.Count)
            {
                Console.WriteLine("Corso non valido.");
                return;
            }

            var corso = corsi[indiceCorso];
            Console.WriteLine($"\nIscritti al corso: {corso}");

            if (corso.Studenti.Count == 0)
            {
                Console.WriteLine("Nessuno studente iscritto.");
                return;
            }

            for (int i = 0; i < corso.Studenti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {corso.Studenti[i]}");
            }
        }

        public void MostraSchedaLezione(int indiceCorso, int indiceLezione)
        {
            Console.WriteLine("\n=== SCHEDA LEZIONE ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (indiceCorso < 0 || indiceCorso >= corsi.Count)
            {
                Console.WriteLine("Corso non valido.");
                return;
            }

            var corso = corsi[indiceCorso];

            if (indiceLezione < 0 || indiceLezione >= corso.Lezioni.Count)
            {
                Console.WriteLine("Lezione non valida.");
                return;
            }

            var lezione = corso.Lezioni[indiceLezione];

            Console.WriteLine($"\n--- SCHEDA LEZIONE ---");
            Console.WriteLine($"Corso: {corso}");
            Console.WriteLine($"Descrizione: {lezione.Descrizione}");
            Console.WriteLine($"Data: {lezione.Data:dd/MM/yyyy}");
            Console.WriteLine($"Orario: {lezione.OrarioInizio:hh\\:mm}");
            Console.WriteLine($"Durata: {lezione.Durata:hh\\:mm}");
            Console.WriteLine($"Docente: {lezione.Docente}");
            Console.WriteLine($"Aula: {lezione.Aula}");
            Console.WriteLine($"Presenti: {lezione.Presenti.Count}/{corso.Studenti.Count}");
        }

        public void MostraPresentiLezione(int indiceCorso, int indiceLezione)
        {
            Console.WriteLine("\n=== PRESENTI LEZIONE ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (indiceCorso < 0 || indiceCorso >= corsi.Count)
            {
                Console.WriteLine("Corso non valido.");
                return;
            }

            var corso = corsi[indiceCorso];

            if (indiceLezione < 0 || indiceLezione >= corso.Lezioni.Count)
            {
                Console.WriteLine("Lezione non valida.");
                return;
            }

            var lezione = corso.Lezioni[indiceLezione];

            Console.WriteLine($"\nPresenti alla lezione: {lezione.Descrizione}");

            if (lezione.Presenti.Count == 0)
            {
                Console.WriteLine("Nessuno studente presente.");
                return;
            }

            for (int i = 0; i < lezione.Presenti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lezione.Presenti[i]}");
            }
        }

        public void MostraMediaPresenti(int indiceCorso)
        {
            Console.WriteLine("\n=== MEDIA PRESENTI ===");

            var corsi = _gestioneCorsi.GetCorsi();

            if (indiceCorso < 0 || indiceCorso >= corsi.Count)
            {
                Console.WriteLine("Corso non valido.");
                return;
            }

            var corso = corsi[indiceCorso];

            if (corso.Lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna lezione disponibile per questo corso.");
                return;
            }

            int totalePresenti = 0;
            int lezioniConPresenze = 0;

            foreach (var lezione in corso.Lezioni)
            {
                if (lezione.Presenti.Count > 0 || corso.Studenti.Count > 0)
                {
                    totalePresenti += lezione.Presenti.Count;
                    lezioniConPresenze++;
                }
            }

            if (lezioniConPresenze > 0)
            {
                double mediaPresenti = (double)totalePresenti / lezioniConPresenze;
                Console.WriteLine($"\nStatistiche presenza per il corso: {corso}");
                Console.WriteLine($"Totale studenti iscritti: {corso.Studenti.Count}");
                Console.WriteLine($"Totale lezioni: {corso.Lezioni.Count}");
                Console.WriteLine($"Media presenti per lezione: {mediaPresenti:F2}");

                if (corso.Studenti.Count > 0)
                {
                    double percentualePresenza = (mediaPresenti / corso.Studenti.Count) * 100;
                    Console.WriteLine($"Percentuale media di presenza: {percentualePresenza:F1}%");
                }
            }
            else
            {
                Console.WriteLine("Nessuna presenza registrata per questo corso.");
            }
        }
        #endregion
    }
}