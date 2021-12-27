using AssessoriaCartoesApi.Data.Entities.G5SMART;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class AjusteG5SMARTMap : IEntityTypeConfiguration<AjusteG5SMART>
    {
        void IEntityTypeConfiguration<AjusteG5SMART>.Configure(EntityTypeBuilder<AjusteG5SMART> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.AgenciaDeDepositoDoCredito);
            builder.Property(t => t.CodigoAgrupadorBancarioDoComprovante);
            builder.Property(t => t.CodigoDeAjuste);
            builder.Property(t => t.CodigoDeAutorizacao);
            builder.Property(t => t.CodigoDeCompensacaoDoBanco);
            builder.Property(t => t.CodigoOriginalDeAjuste);
            builder.Property(t => t.ContaDeDepositoDoCredito);
            builder.Property(t => t.DataDaVenda);
            builder.Property(t => t.DataDeEnvioAoBanco);
            builder.Property(t => t.DataDeReferencia);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.DataDoResumoDeAjuste);
            builder.Property(t => t.DescricaoDoMotivoDoAjuste);
            builder.Property(t => t.IdDaOcorrencia);
            builder.Property(t => t.IdentificacaoDoValor);
            builder.Property(t => t.NomeDaAdministradora);
            builder.Property(t => t.NSUCV);
            builder.Property(t => t.NumeroDaNotaFiscal);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDeReferencia);
            builder.Property(t => t.NumeroDoCartao);
            builder.Property(t => t.NumeroDoProcesso);
            builder.Property(t => t.NumeroDoResumoAtual);
            builder.Property(t => t.NumeroDoResumoOriginal);
            builder.Property(t => t.PDVAjustado);
            builder.Property(t => t.PDVOriginal);
            builder.Property(t => t.StatusDePagamentos);
            builder.Property(t => t.TID);
            builder.Property(t => t.TipoDeCaptura);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.ValorBrutoDaParcelaAjuste);
            builder.Property(t => t.ValorDescontoDoResumo);
            builder.Property(t => t.ValorDoAjuste);
            builder.Property(t => t.ValorLiquidoDoResumo);
            builder.Property(t => t.ValorTaxaDeServico);
        }
    }
}