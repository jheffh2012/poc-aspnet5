namespace poc.AspNet5.Ioc.EntityFramework.Migrations
{
    using poc.AspNet5.Ioc.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<poc.AspNet5.Ioc.EntityFramework.Context.SqlServerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(poc.AspNet5.Ioc.EntityFramework.Context.SqlServerDBContext context)
        {

            var equipe = context.Set<Equipe>().Add(new Equipe { Nome = "Equipe Default" });
            context.Set<Usuario>().Add(new Usuario
            {
                Nome = "Testando",
                Apelido = "Teste",
                IdEquipe = equipe.Id,
                DDD = "48",
                Telefone = "99999999",
                Setor = "Setor",
                Email = "teste@teste.com.br",
                Senha = "teste@teste.com.br"
            });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
