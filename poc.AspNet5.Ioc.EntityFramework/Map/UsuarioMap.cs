using poc.AspNet5.Ioc.Entities;
using System.Data.Entity.ModelConfiguration;

namespace poc.AspNet5.Ioc.EntityFramework.Map
{
    class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("usuario");
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Apelido)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Setor)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.DDD)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(c => c.Equipe)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(f => f.IdEquipe);
        }
    }
}

