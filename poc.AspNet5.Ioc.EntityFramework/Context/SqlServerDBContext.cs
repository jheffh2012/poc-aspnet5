using poc.AspNet5.Ioc.Entities;
using poc.AspNet5.Ioc.EntityFramework.Map;
using System.Data.Entity;

namespace poc.AspNet5.Ioc.EntityFramework.Context
{
    public class SqlServerDBContext : DbContext
    {
        public SqlServerDBContext() : base("ConexaoDB")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<EventoConfirmacao> EventoConfirmacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EquipeMap());
            modelBuilder.Configurations.Add(new CalendarioMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new EventoConfirmacaoMap());
        }
    }
}
