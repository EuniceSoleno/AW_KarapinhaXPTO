using Karapinha.Data;
using Karapinha.Repositorios.Interface;
using Karapinha.Repositorios.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Karapinha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add database context
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<KarapinhaDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            // Register repositories
            builder.Services.AddScoped<IUtilizadorRepositorio, UtilizadorRepositorio>();
            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>(); 
            builder.Services.AddScoped<IMarcacaoRepositorio, MarcacaoRepositorio>();
            builder.Services.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();
            builder.Services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
            builder.Services.AddScoped<ITabelaDeHorarioRepositorio, TabelaDeHorarioRepositorio>(); // Adicionando o repositório para TabelaDeHorario

            // Register dependencies directly
            //  builder.Services.AddScoped<ProfissionalRepositorio>();
            builder.Services.AddScoped<CategoriaRepositorio>();
            builder.Services.AddScoped<ServicoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
