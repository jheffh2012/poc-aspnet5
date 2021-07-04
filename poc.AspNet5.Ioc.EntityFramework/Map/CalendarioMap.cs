using poc.AspNet5.Ioc.Entities;
using System.Data.Entity.ModelConfiguration;

namespace poc.AspNet5.Ioc.EntityFramework.Map
{
    public class CalendarioMap : EntityTypeConfiguration<Calendario>
    {
        public CalendarioMap()
        {
            ToTable("calendario");

            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(c => c.Equipe)
                .WithMany(f => f.Calendarios)
                .HasForeignKey(f => f.IdEquipe);
        }
    }
}
