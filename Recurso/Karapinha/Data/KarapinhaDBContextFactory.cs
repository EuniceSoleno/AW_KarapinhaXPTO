using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Karapinha.Data
{
    public class KarapinhaDBContextFactory : IDesignTimeDbContextFactory<KarapinhaDBContext>
    {
        public KarapinhaDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KarapinhaDBContext>();
            optionsBuilder.UseSqlServer("Server=./;DataBase=DB_Karapinha;User Id=sa;Password=eunice;");

            return new KarapinhaDBContext(optionsBuilder.Options);
        }
    }
}
