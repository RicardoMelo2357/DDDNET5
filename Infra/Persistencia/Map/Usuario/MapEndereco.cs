using _Endereco = Dominio.Entidades.Endereco.Endereco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistencia.Map.Usuario
{
    public class MapEndereco : IEntityTypeConfiguration<_Endereco>
    {
        public void Configure(EntityTypeBuilder<_Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.Property(p => p.Id).HasColumnName("EnderecoId").IsRequired();
            builder.Property(p => p.Logradouro).HasColumnName("Logradouro").IsRequired();
            builder.Property(p => p.Municipio).HasColumnName("Municipio").IsRequired();
            builder.Property(p => p.Numero).HasColumnName("Numero").IsRequired();
            builder.Property(p => p.Estado).HasColumnName("Estado").IsRequired();
            builder.Property(p => p.Cep).HasColumnName("Cep").IsRequired();
        }
    }
}
