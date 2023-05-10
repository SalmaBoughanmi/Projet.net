using Dapper;
using ProjetPFE.Context;
using ProjetPFE.Contracts;
using ProjetPFE.Dto;
using ProjetPFE.Entities;
using System.Data;

namespace ProjetPFE.Repository
{
   
        public class TechnologieRepository : ITechnologieRepository
    {
            private readonly DapperContext _context;

            public TechnologieRepository(DapperContext context)
            {
                _context = context;
            }




            public async Task<IEnumerable<technologie>> GetTechnologies()
            {
                var query = "SELECT * FROM technologie";

                using (var connection = _context.CreateConnection())
                {
                    var technologies = await connection.QueryAsync<technologie>(query);
                    return technologies.ToList();
                }
            }




            public async Task<technologie> GetTechnologie(int techno_id)
            {
                var query = "SELECT * FROM technologie WHERE techno_id = @techno_id";

                using (var connection = _context.CreateConnection())
                {
                    var techno = await connection.QuerySingleOrDefaultAsync<technologie>(query, new { techno_id });

                    return techno;
                }
            }







            public async Task<technologie> CreateTechnologie(TechnologieForCreationDto technologie)
            {
                var query = "INSERT INTO technologie (employe_id, nom_techno) " +
                    "VALUES ( @employe_id, @nom_techno) SELECT CAST(SCOPE_IDENTITY() as int)";

                var parameters = new DynamicParameters();
                parameters.Add("employe_id", technologie.employe_id, DbType.Int32);
                parameters.Add("nom_techno", technologie.nom_techno, DbType.String);



                using (var connection = _context.CreateConnection())
                {
                    var id = await connection.QuerySingleAsync<int>(query, parameters);

                    var createdtechno = new technologie
                    {
                        techno_id = id,
                        employe_id = technologie.employe_id,
                        nom_techno = technologie.nom_techno,


                    };
                    return createdtechno;
                }
            }



            public async Task UpdateTechnologie(int techno_id, TechnologieForUpdateDto technologie)
            {
                var query = "UPDATE technologie SET  nom_techno = @nom_techno, employe_id = @employe_id " +
                    " WHERE techno_id = @techno_id";

                var parameters = new DynamicParameters();
                parameters.Add("techno_id", techno_id, DbType.Int32);
                parameters.Add("employe_id", technologie.employe_id, DbType.Int32);
                parameters.Add("nom_techno", technologie.nom_techno, DbType.String);
                ;


                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }




            public async Task DeleteTechnologie(int techno_id)
            {
                var query = "DELETE FROM technologie WHERE techno_id = @techno_id";

                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, new { techno_id });
                }
            }
    }
    
}
