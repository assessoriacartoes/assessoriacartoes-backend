using AssessoriaCartoesApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        void IEntityTypeConfiguration<Cliente>.Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Conciliador);
            builder.Property(t => t.Email);
            builder.Property(t => t.ExtensaoLogo);
            builder.Property(t => t.NomeArquivoLogo);
            builder.Property(t => t.Password);
            builder.Property(t => t.PowerBi);
            builder.Property(t => t.Img);
            builder.Property(t => t.TipoDeUsuario);
        }
    }
}