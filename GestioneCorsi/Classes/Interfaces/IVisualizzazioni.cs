namespace GestioneCorsi.Classes.Interfaces
{
    public interface IVisualizzazioni
    {
        void MostraElencoCorsi();
        void MostraLezioniCorso(int indiceCorso);
        void MostraIscrittiCorso(int indiceCorso);
        void MostraSchedaLezione(int indiceCorso, int indiceLezione);
        void MostraPresentiLezione(int indiceCorso, int indiceLezione);
        void MostraMediaPresenti(int indiceCorso);
    }
}