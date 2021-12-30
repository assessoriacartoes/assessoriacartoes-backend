using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class AntecipacaoEASSESSORIAMap : IEntityTypeConfiguration<AntecipacaoEASSESSORIA>
    {
        void IEntityTypeConfiguration<AntecipacaoEASSESSORIA>.Configure(EntityTypeBuilder<AntecipacaoEASSESSORIA> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.AgenciaDeDepositoDoCredito);
            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.CodigoDaAdquirente);
            builder.Property(t => t.CodigoDaBandeira);
            builder.Property(t => t.CodigoDeCompensacaoDoBanco);
            builder.Property(t => t.ContaDeDepositoDoCredito);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.DataDoResumoDeVenda);
            builder.Property(t => t.DataDoVencimento);
            builder.Property(t => t.NomeDaAdquirente);
            builder.Property(t => t.NumeroDaParcelaDeResumo);
            builder.Property(t => t.NumeroDoResumoRV);
            builder.Property(t => t.PDVAdquirente);
            builder.Property(t => t.StatusDeConciliacao);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.TipoDeVenda);
            builder.Property(t => t.TotalDeParcelas);
            builder.Property(t => t.ValorBrutoOriginalDaParcelaDeResumo);
            builder.Property(t => t.ValorDescontoAntecipacaoDeRecebiveis);
            builder.Property(t => t.ValorDescontoOriginalDaParcelaDeResumo);
            builder.Property(t => t.ValorInicialNegociadoParaAAntecipacao);
            builder.Property(t => t.ValorLiquidoCreditado);
            builder.Property(t => t.ValorLiquidoOriginalDaParcelaDeResumo);
        }
    }
}