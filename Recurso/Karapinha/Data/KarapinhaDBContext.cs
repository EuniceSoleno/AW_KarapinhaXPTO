using Karapinha.Data.Map;
using Karapinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Data
{
    public class KarapinhaDBContext : DbContext
    {
        public KarapinhaDBContext(DbContextOptions<KarapinhaDBContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marcacao> Marcacoes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TabelaDeHorario> TabelasDeHorarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UtilizadorMap());
            modelBuilder.ApplyConfiguration(new TabelaDeHorarioMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new MarcacaoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
