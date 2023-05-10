using Dapper;
using ProjetPFE.Context;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;
using ProjetPFE.Entities;
using System.Data;

namespace ProjetPFE.Repository
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly DapperContext _context;

        public CertificationRepository(DapperContext context)
        {
            _context = context;
        }




        public async Task<IEnumerable<certification>> GetCertifications()
        {
            var query = "SELECT * FROM certification";

            using (var connection = _context.CreateConnection())
            {
                var certifications = await connection.QueryAsync<certification>(query);
                return certifications.ToList();
            }
        }




        public async Task<certification> GetCertification(int certif_id)
        {
            var query = "SELECT * FROM certification WHERE certif_id = @certif_id";

            using (var connection = _context.CreateConnection())
            {
                var certif = await connection.QuerySingleOrDefaultAsync<certification>(query, new { certif_id });

                return certif;
            }
        }







        public async Task<certification> CreateCertification(CertificationForCreationDto certification)
        {
            var query = "INSERT INTO certification (employe_id, nom_certif) " +
                "VALUES ( @employe_id, @nom_certif) SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("employe_id", certification.employe_id, DbType.Int32);
            parameters.Add("nom_certif", certification.nom_certif, DbType.String);
         


            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdcertif = new certification
                {
                    certif_id = id,
                    employe_id = certification.employe_id,
                    nom_certif = certification.nom_certif,
                   

                };
                return createdcertif;
            }
        }



        public async Task UpdateCertification(int certif_id, CertificationForUpdateDto certification)
        {
            var query = "UPDATE certification SET  nom_certif = @nom_certif, employe_id = @employe_id " +
                " WHERE certif_id = @certif_id";

            var parameters = new DynamicParameters();
            parameters.Add("certif_id", certif_id, DbType.Int32);
            parameters.Add("employe_id", certification.employe_id, DbType.Int32);
            parameters.Add("nom_certif", certification.nom_certif, DbType.String);
           ;


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }




        public async Task DeleteCertification(int certif_id)
        {
            var query = "DELETE FROM certification WHERE certif_id = @certif_id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { certif_id });
            }
        }













    }
}
