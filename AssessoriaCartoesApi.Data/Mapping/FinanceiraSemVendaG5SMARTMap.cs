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

            builder.Property(t => t.Agencia);
            builder.Property(t => t.BandeiraDoComprovante);
            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.CodigoAgrupadorBancarioResumo);
            builder.Property(t => t.CodigoDaBandeira);
            builder.Property(t => t.CodigoDeAdquirente);
            builder.Property(t => t.CodigoDoBanco);
            builder.Property(t => t.ContaCorrente);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.DataDoResumoRV);
            builder.Property(t => t.NomeDaAdquirente);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDoResumoRV);
            builder.Property(t => t.PDVAdquirente);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.TipoDeVenda);
            builder.Property(t => t.ValorBrutoDaParcelaResumo);
            builder.Property(t => t.ValorDescontoDaAntecipacaoResumo);
            builder.Property(t => t.ValorDescontoDaParcelaResumo);
            builder.Property(t => t.ValorLiquidoDaParcelaResumo);
            builder.Property(t => t.ValorPagoParcelaResumo);
        }
    }
}