using poc.AspNet5.Ioc.Entities;
using System.Data.Entity.ModelConfiguration;

namespace poc.AspNet5.Ioc.EntityFramework.Map
{
    public class EventoConfirmacaoMap : EntityTypeConfiguration<EventoConfirmacao>
    {
        public EventoConfirmacaoMap()
        {
            ToTable("confirmacao");
            HasKey(c => c.Id);

            HasRequired(c => c.Evento)
                .WithMany(f => f.Confirmacoes)
                .HasForeignKey(f => f.IdEvento);

            HasRequired(c => c.Usuario)
                .WithMany(f => f.Confirmacoes)
                .HasForeignKey(f => f.IdUsuario);
        }
    }
}
