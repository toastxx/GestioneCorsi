namespace GestioneCorsi.Classes.Interfaces
{
    public interface IAula
    {
        string Nome { get; set; }
        int Capienza { get; set; }
        IReadOnlyList<string> Risorse { get; }
        void AggiungiRisorsa(string risorsa);
        void RimuoviRisorsa(string risorsa);
    }
}