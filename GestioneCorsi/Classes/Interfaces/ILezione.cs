namespace GestioneCorsi.Classes.Interfaces
{
    public interface ILezione
    {
        string Descrizione { get; set; }
        DateTime Data { get; set; }
        TimeSpan OrarioInizio { get; set; }
        TimeSpan Durata { get; set; }
        IDocente Docente { get; set; }
        IAula Aula { get; set; }
        IReadOnlyList<IStudente> Presenti { get; }
        void AggiungiPresente(IStudente studente);
        void RimuoviPresente(IStudente studente);
        void CancellaPresenze();
    }
}