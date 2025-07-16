using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Models
{
    public class Docente : IDocente
    {
        #region Fields
        private string _nome;
        private string _cognome;
        private string _titoloStudio;
        #endregion

        #region Constructor
        public Docente(string nome, string cognome, string titoloStudio)
        {
            _nome = nome;
            _cognome = cognome;
            _titoloStudio = titoloStudio;
        }
        #endregion

        #region Properties
        public string Nome
        {
            get => _nome;
            set => _nome = value;
        }

        public string Cognome
        {
            get => _cognome;
            set => _cognome = value;
        }

        public string TitoloStudio
        {
            get => _titoloStudio;
            set => _titoloStudio = value;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Nome} {Cognome} - {TitoloStudio}";
        }
        #endregion
    }
}