using ProjetPFE.Dto;
using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface ICertificationRepository
    {
        public Task<IEnumerable<certification>> GetCertifications();
        public Task<certification> GetCertification(int certif_id);
        public Task<certification> CreateCertification(CertificationForCreationDto certification);
        public Task UpdateCertification(int certif_id, CertificationForUpdateDto certification);
        public Task DeleteCertification(int certif_id);
    }
}
