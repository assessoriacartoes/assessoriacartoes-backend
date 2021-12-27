using AssessoriaCartoesApi.Data.Entities.G5SMART;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class FinanceiraSemVendaG5SMARTMap : IEntityTypeConfiguration<FinanceiraSemVendaG5SMART>
    {
        void IEntityTypeConfiguration<FinanceiraSemVendaG5SMART>.Configure(EntityTypeBuilder<FinanceiraSemVendaG5SMART> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Coluna1);
            builder.Property(t => t.Coluna2);
            builder.Property(t => t.Coluna3);
            builder.Property(t => t.Coluna4);
            builder.Property(t => t.Coluna5);
            builder.Property(t => t.Coluna6);
            builder.Property(t => t.Coluna7);
            builder.Property(t => t.Coluna8);
            builder.Property(t => t.Coluna9);
            builder.Property(t => t.Coluna10);
            builder.Property(t => t.Coluna10);
            builder.Property(t => t.Coluna11);
            builder.Property(t => t.Coluna12);
            builder.Property(t => t.Coluna13);
            builder.Property(t => t.Coluna14);
            builder.Property(t => t.Coluna15);
            builder.Property(t => t.Coluna16);
            builder.Property(t => t.Coluna17);
            builder.Property(t => t.Coluna18);
            builder.Property(t => t.Coluna19);
            builder.Property(t => t.Coluna20);
            builder.Property(t => t.Coluna21);
        }
    }
}