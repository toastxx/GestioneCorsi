using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Models
{
    public class Aula : IAula
    {
        #region Fields
        private string _nome;
        private int _capienza;
        private List<string> _risorse;
        #endregion

        #region Constructor
        public Aula(string nome, int capienza, List<string>? risorse = null)
        {
            _nome = nome;
            _capienza = capienza;
            _risorse = risorse ?? new List<string>();
        }
        #endregion

        #region Properties
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public int Capienza
        {
            get => _capienza;
            set => _capienza = value;
        }

        public IReadOnlyList<string> Risorse => _risorse.AsReadOnly();
        #endregion

        #region Methods
        public void AggiungiRisorsa(string risorsa)
        {
            if (!_risorse.Contains(risorsa))
            {
                _risorse.Add(risorsa);
            }
        }

        public void RimuoviRisorsa(string risorsa)
        {
            _risorse.Remove(risorsa);
        }

        public override string ToString()
        {
            return $"Aula: {Nome}, Capienza: {Capienza}, Risorse: {string.Join(", ", Risorse)}";
        }
        #endregion
    }
}