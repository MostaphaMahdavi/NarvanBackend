using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narvan.Domains.Sliders.Entities;
using Narvan.Domains.Sliders.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narvan.DataAccessQueries.Sliders.Repositories
{
    public class SliderRepositoryQuery : ISliderRepositoryQuery
    {
        private readonly SqlConnection _sqlConnection;

        public SliderRepositoryQuery(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }
        public async Task<List<Slider>> GetActiveSlider()
        {
            return (await _sqlConnection.QueryAsync<Slider>("select * from slider where IsDelete=0")).ToList();
        }
    }
}