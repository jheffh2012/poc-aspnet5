using poc.AspNet5.Ioc.Entities;
using System.Data.Entity.ModelConfiguration;

namespace poc.AspNet5.Ioc.EntityFramework.Map
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            ToTable("evento");
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.DataInicio)
                .IsRequired();

            Property(c => c.DataFinal)
                .IsRequired();

            HasRequired(c => c.Calendario)
                .WithMany(f => f.Eventos)
                .HasForeignKey(f => f.IdCalendario)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Organizador)
                .WithMany(f => f.EventosOrganizados)
                .HasForeignKey(f => f.IdOrganizador)
                .WillCascadeOnDelete(false);
        }
    }
}
