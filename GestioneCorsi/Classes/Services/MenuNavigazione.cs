using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes
{
    public class MenuNavigazione : IMenuNavigazione
    {
        #region Fields
        private readonly IGestioneCorsi _gestioneCorsi;
        private readonly IVisualizzazioni _visualizzazioni;
        private readonly IInizializzazioneDati _inizializzazione;
        #endregion

        #region Constructor
        public MenuNavigazione(IGestioneCorsi gestioneCorsi, IVisualizzazioni visualizzazioni, IInizializzazioneDati inizializzazione)
        {
            _gestioneCorsi = gestioneCorsi;
            _visualizzazioni = visualizzazioni;
            _inizializzazione = inizializzazione;
        }
        #endregion

        #region Methods
        public void MostraMenuPrincipale()
        {
            bool continua = true;

            while (continua)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA GESTIONE CORSI ===");
                Console.WriteLine("1. Gestione Dati");
                Console.WriteLine("2. Visualizzazioni");
                Console.WriteLine("3. Inizializza Dati Esempio");
                Console.WriteLine("0. Esci");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        MostraMenuGestione();
                        break;
                    case "2":
                        MostraMenuVisualizzazioni();
                        break;
                    case "3":
                        _inizializzazione.InizializzaDatiEsempio();
                        Console.WriteLine("\nPremi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                    case "0":
                        continua = false;
                        Console.WriteLine("Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Opzione non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void MostraMenuGestione()
        {
            bool continua = true;

            while (continua)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIONE DATI ===");
                Console.WriteLine("1. Aggiungi Corso");
                Console.WriteLine("2. Aggiungi Lezione");
                Console.WriteLine("3. Aggiungi Studente");
                Console.WriteLine("4. Segna Assenti");
                Console.WriteLine("5. Aggiungi Docente");
                Console.WriteLine("6. Aggiungi Aula");
                Console.WriteLine("0. Torna al Menu Principale");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        AggiungiCorso();
                        break;
                    case "2":
                        AggiungiLezione();
                        break;
                    case "3":
                        AggiungiStudente();
                        break;
                    case "4":
                        SegnaAssenti();
                        break;
                    case "5":
                        AggiungiDocente();
                        break;
                    case "6":
                        AggiungiAula();
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void MostraMenuVisualizzazioni()
        {
            bool continua = true;

            while (continua)
            {
                Console.Clear();
                Console.WriteLine("=== VISUALIZZAZIONI ===");
                Console.WriteLine("1. Elenco Corsi");
                Console.WriteLine("2. Lezioni di un Corso");
                Console.WriteLine("3. Iscritti a un Corso");
                Console.WriteLine("4. Scheda Lezione");
                Console.WriteLine("5. Presenti a una Lezione");
                Console.WriteLine("6. Media Presenti Corso");
                Console.WriteLine("0. Torna al Menu Principale");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        _visualizzazioni.MostraElencoCorsi();
                        Console.WriteLine("\nPremi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                    case "2":
                        MostraLezioniCorso();
                        break;
                    case "3":
                        MostraIscrittiCorso();
                        break;
                    case "4":
                        MostraSchedaLezione();
                        break;
                    case "5":
                        MostraPresentiLezione();
                        break;
                    case "6":
                        MostraMediaPresenti();
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AggiungiCorso()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI CORSO ===");
            Console.Write("Nome del corso: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Edizione: ");
            string edizioneInput = Console.ReadLine() ?? "";

            if (int.TryParse(edizioneInput, out int edizione))
            {
                if (_gestioneCorsi.AggiungiCorso(nome, edizione))
                {
                    Console.WriteLine("Corso aggiunto con successo!");
                }
                else
                {
                    Console.WriteLine("Errore nell'aggiunta del corso.");
                }
            }
            else
            {
                Console.WriteLine("Edizione non valida.");
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void AggiungiLezione()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI LEZIONE ===");

            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string corsoInput = Console.ReadLine() ?? "";

            if (!int.TryParse(corsoInput, out int indiceCorso) || indiceCorso < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceCorso--;

            Console.Write("Descrizione lezione: ");
            string descrizione = Console.ReadLine() ?? "";

            Console.Write("Data (dd/MM/yyyy): ");
            string dataInput = Console.ReadLine() ?? "";

            if (!DateTime.TryParseExact(dataInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                Console.WriteLine("Data non valida.");
                Console.ReadKey();
                return;
            }

            Console.Write("Orario inizio (HH:mm): ");
            string orarioInput = Console.ReadLine() ?? "";

            if (!TimeSpan.TryParse(orarioInput, out TimeSpan orario))
            {
                Console.WriteLine("Orario non valido.");
                Console.ReadKey();
                return;
            }

            Console.Write("Durata (HH:mm): ");
            string durataInput = Console.ReadLine() ?? "";

            if (!TimeSpan.TryParse(durataInput, out TimeSpan durata))
            {
                Console.WriteLine("Durata non valida.");
                Console.ReadKey();
                return;
            }

            var docenti = _gestioneCorsi.GetDocenti();
            Console.WriteLine("\nDocenti disponibili:");
            for (int i = 0; i < docenti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {docenti[i]}");
            }

            Console.Write("Seleziona docente: ");
            string docenteInput = Console.ReadLine() ?? "";

            if (!int.TryParse(docenteInput, out int indiceDocente) || indiceDocente < 1 || indiceDocente > docenti.Count)
            {
                Console.WriteLine("Docente non valido.");
                Console.ReadKey();
                return;
            }

            indiceDocente--;

            var aule = _gestioneCorsi.GetAule();
            Console.WriteLine("\nAule disponibili:");
            for (int i = 0; i < aule.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aule[i]}");
            }

            Console.Write("Seleziona aula: ");
            string aulaInput = Console.ReadLine() ?? "";

            if (!int.TryParse(aulaInput, out int indiceAula) || indiceAula < 1 || indiceAula > aule.Count)
            {
                Console.WriteLine("Aula non valida.");
                Console.ReadKey();
                return;
            }

            indiceAula--;

            if (_gestioneCorsi.AggiungiLezione(indiceCorso, descrizione, data, orario, durata, indiceDocente, indiceAula))
            {
                Console.WriteLine("Lezione aggiunta con successo!");
            }
            else
            {
                Console.WriteLine("Errore nell'aggiunta della lezione.");
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void AggiungiStudente()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI STUDENTE ===");

            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string corsoInput = Console.ReadLine() ?? "";

            if (!int.TryParse(corsoInput, out int indiceCorso) || indiceCorso < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceCorso--;

            Console.Write("Nome studente: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Cognome studente: ");
            string cognome = Console.ReadLine() ?? "";

            Console.Write("Matricola: ");
            string matricola = Console.ReadLine() ?? "";

            if (_gestioneCorsi.AggiungiStudente(indiceCorso, nome, cognome, matricola))
            {
                Console.WriteLine("Studente aggiunto con successo!");
            }
            else
            {
                Console.WriteLine("Errore nell'aggiunta dello studente.");
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void SegnaAssenti()
        {
            Console.Clear();
            Console.WriteLine("=== SEGNA ASSENTI ===");

            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string corsoInput = Console.ReadLine() ?? "";

            if (!int.TryParse(corsoInput, out int indiceCorso) || indiceCorso < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceCorso--;

            _visualizzazioni.MostraLezioniCorso(indiceCorso);
            Console.Write("\nSeleziona la lezione (numero): ");
            string lezioneInput = Console.ReadLine() ?? "";

            if (!int.TryParse(lezioneInput, out int indiceLezione) || indiceLezione < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceLezione--;

            if (_gestioneCorsi.SegnaAssenti(indiceCorso, indiceLezione))
            {
                Console.WriteLine("Presenze generate casualmente!");
            }
            else
            {
                Console.WriteLine("Errore nella generazione delle presenze.");
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void AggiungiDocente()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI DOCENTE ===");

            Console.Write("Nome docente: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Cognome docente: ");
            string cognome = Console.ReadLine() ?? "";

            Console.Write("Titolo di studio: ");
            string titolo = Console.ReadLine() ?? "";

            _gestioneCorsi.AggiungiDocente(nome, cognome, titolo);
            Console.WriteLine("Docente aggiunto con successo!");

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void AggiungiAula()
        {
            Console.Clear();
            Console.WriteLine("=== AGGIUNGI AULA ===");

            Console.Write("Nome aula: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Capienza: ");
            string capienzaInput = Console.ReadLine() ?? "";

            if (!int.TryParse(capienzaInput, out int capienza))
            {
                Console.WriteLine("Capienza non valida.");
                Console.ReadKey();
                return;
            }

            Console.Write("Risorse (separate da virgola, opzionale): ");
            string risorseInput = Console.ReadLine() ?? "";

            List<string>? risorse = null;
            if (!string.IsNullOrWhiteSpace(risorseInput))
            {
                risorse = risorseInput.Split(',').Select(r => r.Trim()).ToList();
            }

            _gestioneCorsi.AggiungiAula(nome, capienza, risorse);
            Console.WriteLine("Aula aggiunta con successo!");

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }

        private void MostraLezioniCorso()
        {
            Console.Clear();
            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int indice) && indice > 0)
            {
                _visualizzazioni.MostraLezioniCorso(indice - 1);
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private void MostraIscrittiCorso()
        {
            Console.Clear();
            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int indice) && indice > 0)
            {
                _visualizzazioni.MostraIscrittiCorso(indice - 1);
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private void MostraSchedaLezione()
        {
            Console.Clear();
            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string corsoInput = Console.ReadLine() ?? "";

            if (!int.TryParse(corsoInput, out int indiceCorso) || indiceCorso < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceCorso--;

            _visualizzazioni.MostraLezioniCorso(indiceCorso);
            Console.Write("\nSeleziona la lezione (numero): ");
            string lezioneInput = Console.ReadLine() ?? "";

            if (int.TryParse(lezioneInput, out int indiceLezione) && indiceLezione > 0)
            {
                _visualizzazioni.MostraSchedaLezione(indiceCorso, indiceLezione - 1);
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private void MostraPresentiLezione()
        {
            Console.Clear();
            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string corsoInput = Console.ReadLine() ?? "";

            if (!int.TryParse(corsoInput, out int indiceCorso) || indiceCorso < 1)
            {
                Console.WriteLine("Selezione non valida.");
                Console.ReadKey();
                return;
            }

            indiceCorso--;

            _visualizzazioni.MostraLezioniCorso(indiceCorso);
            Console.Write("\nSeleziona la lezione (numero): ");
            string lezioneInput = Console.ReadLine() ?? "";

            if (int.TryParse(lezioneInput, out int indiceLezione) && indiceLezione > 0)
            {
                _visualizzazioni.MostraPresentiLezione(indiceCorso, indiceLezione - 1);
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }

        private void MostraMediaPresenti()
        {
            Console.Clear();
            _visualizzazioni.MostraElencoCorsi();
            Console.Write("\nSeleziona il corso (numero): ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int indice) && indice > 0)
            {
                _visualizzazioni.MostraMediaPresenti(indice - 1);
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
        }
        #endregion
    }
}