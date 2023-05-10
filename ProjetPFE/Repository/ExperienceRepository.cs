using Dapper;
using ProjetPFE.Context;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;
using ProjetPFE.Entities;
using System.Data;

namespace ProjetPFE.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly DapperContext _context;

        public ExperienceRepository(DapperContext context)
        {
            _context = context;
        }




        public async Task<IEnumerable<experience>> GetExperiences()
        {
            var query = "SELECT * FROM experience";

            using (var connection = _context.CreateConnection())
            {
                var experiences = await connection.QueryAsync<experience>(query);
                return experiences.ToList();
            }
        }




        public async Task<experience> GetExperience(int experience_id)
        {
            var query = "SELECT * FROM experience WHERE experience_id = @experience_id";

            using (var connection = _context.CreateConnection())
            {
                var exp = await connection.QuerySingleOrDefaultAsync<experience>(query, new { experience_id });

                return exp;
            }
        }







        public async Task<experience> CreateExperience(ExperienceForCreationDto experience)
        {
            var query = "INSERT INTO certification (employe_id, poste, entreprise, date_debut, date_fin) " +
                "VALUES ( @employe_id, @poste, @entreprise, @date_debut, @date_fin) SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();

            parameters.Add("employe_id", experience.employe_id, DbType.Int32);
            parameters.Add("poste", experience.poste, DbType.String); 
            parameters.Add("entreprise", experience.entreprise, DbType.String);
            parameters.Add("date_debut", experience.date_debut, DbType.DateTime);
            parameters.Add("date_fin", experience.date_fin, DbType.DateTime);
           



            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdexp = new experience
                {
                    experience_id = id,
                    employe_id = experience.employe_id,
                    poste = experience.poste,
                    entreprise = experience.entreprise,
                    date_debut = experience.date_debut,
                    date_fin = experience.date_fin,


                };
                return createdexp;
            }
        }



        public async Task UpdateExperience(int experience_id, ExperienceForUpdateDto experience)
        {
            var query = "UPDATE experience SET  poste = @poste, entreprise = @entreprise, date_debut = @date_debut," +
                " date_fin = @date_fin, employe_id = @employe_id " +
                " WHERE experience_id = @experience_id";

            var parameters = new DynamicParameters();
            parameters.Add("experience_id", experience_id, DbType.Int32);
            parameters.Add("employe_id", experience.employe_id, DbType.Int32);
            parameters.Add("poste", experience.poste, DbType.String);
            parameters.Add("entreprise", experience.entreprise, DbType.String);
            parameters.Add("date_debut", experience.date_debut, DbType.DateTime);
            parameters.Add("date_fin", experience.date_fin, DbType.DateTime);
            ;


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }




        public async Task DeleteExperience(int experience_id)
        {
            var query = "DELETE FROM experience WHERE experience_id = @experience_id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { experience_id });
            }
        }













    }
}
