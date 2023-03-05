using base_api_aspNet.Data.Map;
using base_api_aspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace base_api_aspNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //declarar todos que devem possuir o contexto das funcoes do repository do banco de dados
        public DbSet<Base>? Bases { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
