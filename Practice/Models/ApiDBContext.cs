using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options)
            : base(options)
        {

        }

       
        public DbSet<Country>  Country{ get; set; }

        public DbSet<CountryDetails>  CountryDetails{ get; set; }
     
    }
}
