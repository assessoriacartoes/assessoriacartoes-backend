using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class TransacaoEASSESSORIAMap : IEntityTypeConfiguration<TransacaoEASSESSORIA>
    {
        void IEntityTypeConfiguration<TransacaoEASSESSORIA>.Configure(EntityTypeBuilder<TransacaoEASSESSORIA> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}