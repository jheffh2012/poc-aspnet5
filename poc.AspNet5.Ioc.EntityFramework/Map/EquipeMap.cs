using poc.AspNet5.Ioc.Entities;
using System.Data.Entity.ModelConfiguration;

namespace poc.AspNet5.Ioc.EntityFramework.Map
{
    public class EquipeMap : EntityTypeConfiguration<Equipe>
    {
        public EquipeMap()
        {
            ToTable("equipe");
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
