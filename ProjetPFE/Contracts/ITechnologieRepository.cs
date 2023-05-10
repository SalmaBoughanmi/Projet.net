using ProjetPFE.Dto;
using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface ITechnologieRepository
    {
        public Task<IEnumerable<technologie>> GetTechnologies();
        public Task<technologie> GetTechnologie(int techno_id);
        public Task<technologie> CreateTechnologie(TechnologieForCreationDto technologie);
        public Task UpdateTechnologie(int techno_id, TechnologieForUpdateDto technologie);
        public Task DeleteTechnologie(int techno_id);
    }
}
