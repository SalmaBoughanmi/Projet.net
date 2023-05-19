using ProjetPFE.Dto;
using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface IDemandeRepository
    {


        public Task<IEnumerable<demande>> Getdemandes();
        public Task<demande> GetDemande(int demande_id);
        Task<IEnumerable<demande>> Getdem(int employe_id);
        public Task<demande> CreateDemande(DemandeForCreationDto demande);
        // public Task<demande> CreateDemande(DemandeForCreationDto DemandeForCreationDto);
        public Task UpdateDemande(int demande_id, DemandeForUpdateDto demande);
        public Task DeleteDemande(int demande_id);
        Task<IEnumerable<demande>> GetDemandeByStatutChef(string statut_chef);
        Task<IEnumerable<demande>> GetDemandeByStatutRH(string statut_rh);

        Task<IEnumerable<demande>> SearchDemandeAsync(string search);
        List<demande> GetDemandesByResponsable(string matricule_resp);


        void ArchiverDemande(archive archive);

    }
}

