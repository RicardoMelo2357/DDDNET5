using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _Usuario = Dominio.Entidades.Usuario.Usuario;

namespace Infra.Persistencia.Map.Endereco
{
    public class MapUsuario : IEntityTypeConfiguration<_Usuario>
    {
        public void Configure(EntityTypeBuilder<_Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(p => p.Id).HasColumnName("UsuarioId").IsRequired();            
            builder.Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(p => p.SobreNome).HasColumnName("SobreNome").IsRequired();
            builder.Property(p => p.CPF).HasColumnName("CPF").IsRequired();
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired();
            builder.Property(p => p.Senha).HasColumnName("Senha").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();
        }
    }
}
