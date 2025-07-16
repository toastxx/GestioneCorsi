using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Models
{
    public class Lezione : ILezione
    {
        #region Fields
        private string _descrizione;
        private DateTime _data;
        private TimeSpan _orarioInizio;
        private TimeSpan _durata;
        private IDocente _docente;
        private IAula _aula;
        private List<IStudente> _presenti;
        #endregion

        #region Constructor
        public Lezione(string descrizione, DateTime data, TimeSpan orarioInizio, TimeSpan durata, IDocente docente, IAula aula)
        {
            _descrizione = descrizione;
            _data = data;
            _orarioInizio = orarioInizio;
            _durata = durata;
            _docente = docente;
            _aula = aula;
            _presenti = new List<IStudente>();
        }
        #endregion

        #region Properties
        public string Descrizione
        {
            get => _descrizione;
            set => _descrizione = value;
        }

        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        public TimeSpan OrarioInizio
        {
            get => _orarioInizio;
            set => _orarioInizio = value;
        }

        public TimeSpan Durata
        {
            get => _durata;
            set => _durata = value;
        }

        public IDocente Docente
        {
            get => _docente;
            set => _docente = value;
        }

        public IAula Aula
        {
            get => _aula;
            set => _aula = value;
        }

        public IReadOnlyList<IStudente> Presenti => _presenti.AsReadOnly();
        #endregion

        #region Methods
        public void AggiungiPresente(IStudente studente)
        {
            if (!_presenti.Contains(studente))
            {
                _presenti.Add(studente);
            }
        }

        public void RimuoviPresente(IStudente studente)
        {
            _presenti.Remove(studente);
        }

        public void CancellaPresenze()
        {
            _presenti.Clear();
        }

        public override string ToString()
        {
            return $"{Descrizione} - {Data:dd/MM/yyyy} {OrarioInizio:hh\\:mm} (Durata: {Durata:hh\\:mm})";
        }
        #endregion
    }
}