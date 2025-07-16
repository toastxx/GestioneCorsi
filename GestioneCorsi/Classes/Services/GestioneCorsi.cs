using GestioneCorsi.Classes.Interfaces;
using GestioneCorsi.Classes.Models;

namespace GestioneCorsi.Classes.Services
{
    public class GestioneCorsi : IGestioneCorsi
    {
        #region Fields
        private List<ICorso> _corsi;
        private List<IDocente> _docenti;
        private List<IAula> _aule;
        private Random _random;
        #endregion

        #region Constructor
        public GestioneCorsi()
        {
            _corsi = new List<ICorso>();
            _docenti = new List<IDocente>();
            _aule = new List<IAula>();
            _random = new Random();
        }
        #endregion

        #region Properties
        public IReadOnlyList<ICorso> GetCorsi() => _corsi.AsReadOnly();
        public IReadOnlyList<IDocente> GetDocenti() => _docenti.AsReadOnly();
        public IReadOnlyList<IAula> GetAule() => _aule.AsReadOnly();
        #endregion

        #region Methods
        public bool AggiungiCorso(string nome, int edizione)
        {
            if (string.IsNullOrWhiteSpace(nome) || edizione <= 0)
                return false;

            var corso = new Corso(nome, edizione);
            _corsi.Add(corso);
            return true;
        }

        public bool AggiungiLezione(int indiceCorso, string descrizione, DateTime data, TimeSpan orario,
                                   TimeSpan durata, int indiceDocente, int indiceAula)
        {
            if (indiceCorso < 0 || indiceCorso >= _corsi.Count)
                return false;

            if (indiceDocente < 0 || indiceDocente >= _docenti.Count)
                return false;

            if (indiceAula < 0 || indiceAula >= _aule.Count)
                return false;

            var corso = _corsi[indiceCorso];
            var docente = _docenti[indiceDocente];
            var aula = _aule[indiceAula];

            var lezione = new Lezione(descrizione, data, orario, durata, docente, aula);
            corso.AggiungiLezione(lezione);

            return true;
        }

        public bool AggiungiStudente(int indiceCorso, string nome, string cognome, string matricola)
        {
            if (indiceCorso < 0 || indiceCorso >= _corsi.Count)
                return false;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome) || string.IsNullOrWhiteSpace(matricola))
                return false;

            var corso = _corsi[indiceCorso];
            var studente = new Studente(nome, cognome, matricola);
            corso.AggiungiStudente(studente);

            return true;
        }

        public bool SegnaAssenti(int indiceCorso, int indiceLezione)
        {
            if (indiceCorso < 0 || indiceCorso >= _corsi.Count)
                return false;

            var corso = _corsi[indiceCorso];

            if (indiceLezione < 0 || indiceLezione >= corso.Lezioni.Count)
                return false;

            var lezione = corso.Lezioni[indiceLezione];

            if (lezione is Lezione lezioneImpl)
            {
                lezioneImpl.CancellaPresenze();

                foreach (var studente in corso.Studenti)
                {
                    if (_random.NextDouble() < 0.7)
                    {
                        lezioneImpl.AggiungiPresente(studente);
                    }
                }
            }

            return true;
        }

        public void AggiungiDocente(string nome, string cognome, string titoloStudio)
        {
            var docente = new Docente(nome, cognome, titoloStudio);
            _docenti.Add(docente);
        }

        public void AggiungiAula(string nome, int capienza, List<string>? risorse = null)
        {
            var aula = new Aula(nome, capienza, risorse);
            _aule.Add(aula);
        }
        #endregion
    }
}