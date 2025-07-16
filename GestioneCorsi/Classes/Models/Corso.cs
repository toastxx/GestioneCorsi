using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Models
{
    public class Corso : ICorso
    {
        #region Fields
        private string _nome;
        private int _edizione;
        private List<ILezione> _lezioni;
        private List<IStudente> _studenti;
        #endregion

        #region Constructor
        public Corso(string nome, int edizione)
        {
            _nome = nome;
            _edizione = edizione;
            _lezioni = new List<ILezione>();
            _studenti = new List<IStudente>();
        }
        #endregion

        #region Properties
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int Edizione
        {
            get => _edizione;
            set => _edizione = value;
        }

        public IReadOnlyList<ILezione> Lezioni => _lezioni.AsReadOnly();
        public IReadOnlyList<IStudente> Studenti => _studenti.AsReadOnly();
        #endregion

        #region Methods
        public void AggiungiLezione(ILezione lezione)
        {
            _lezioni.Add(lezione);
        }

        public void AggiungiStudente(IStudente studente)
        {
            if (!_studenti.Any(s => s.Matricola == studente.Matricola))
            {
                _studenti.Add(studente);
            }
        }

        public override string ToString()
        {
            return $"{Nome} - Edizione {Edizione}";
        }
        #endregion
    }
}