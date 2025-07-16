namespace GestioneCorsi.Classes.Interfaces
{
    public interface IGestioneCorsi
    {
        bool AggiungiCorso(string nome, int edizione);
        bool AggiungiLezione(int indiceCorso, string descrizione, DateTime data, TimeSpan orario, TimeSpan durata, int indiceDocente, int indiceAula);
        bool AggiungiStudente(int indiceCorso, string nome, string cognome, string matricola);
        bool SegnaAssenti(int indiceCorso, int indiceLezione);
        IReadOnlyList<ICorso> GetCorsi();
        IReadOnlyList<IDocente> GetDocenti();
        IReadOnlyList<IAula> GetAule();
    }
}