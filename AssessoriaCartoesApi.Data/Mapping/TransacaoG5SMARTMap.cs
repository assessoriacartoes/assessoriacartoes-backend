using AssessoriaCartoesApi.Data.Entities.G5SMART;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class TransacaoG5SMARTMap : IEntityTypeConfiguration<TransacaoG5SMART>
    {
        void IEntityTypeConfiguration<TransacaoG5SMART>.Configure(EntityTypeBuilder<TransacaoG5SMART> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}