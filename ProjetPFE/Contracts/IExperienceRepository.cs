using ProjetPFE.Dto;
using ProjetPFE.Entities;

namespace ProjetPFE.Contracts
{
    public interface IExperienceRepository
    {
        public Task<IEnumerable<experience>> GetExperiences();
        public Task<experience> GetExperience(int experience_id);
        public Task<experience> CreateExperience(ExperienceForCreationDto experience);
        public Task UpdateExperience(int experience_id, ExperienceForUpdateDto experience);
        public Task DeleteExperience(int experience_id);
    }
}
