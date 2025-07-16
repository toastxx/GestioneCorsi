namespace GestioneCorsi.Classes.Interfaces
{
    public interface ICorso
    {
        string Nome { get; set; }
        int Edizione { get; set; }
        IReadOnlyList<ILezione> Lezioni { get; }
        IReadOnlyList<IStudente> Studenti { get; }
        void AggiungiLezione(ILezione lezione);
        void AggiungiStudente(IStudente studente);
    }
}