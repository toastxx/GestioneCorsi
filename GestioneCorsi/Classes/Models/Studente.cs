using GestioneCorsi.Classes.Interfaces;

namespace GestioneCorsi.Classes.Models
{
    public class Studente : IStudente
    {
        #region Fields
        private string _nome;
        private string _cognome;
        private string _matricola;
        #endregion

        #region Constructor
        public Studente(string nome, string cognome, string matricola)
        {
            _nome = nome;
            _cognome = cognome;
            _matricola = matricola;
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

        public string Matricola
        {
            get => _matricola;
            set => _matricola = value;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Nome} {Cognome} (Mat: {Matricola})";
        }
        #endregion
    }
}