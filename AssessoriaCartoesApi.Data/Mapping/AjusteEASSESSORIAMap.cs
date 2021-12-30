using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class AjusteEASSESSORIAMap : IEntityTypeConfiguration<AjusteEASSESSORIA>
    {
        void IEntityTypeConfiguration<AjusteEASSESSORIA>.Configure(EntityTypeBuilder<AjusteEASSESSORIA> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.AgenciaDeDeposito);
            builder.Property(t => t.BPAGID);
            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.CodigoAgrupadorBancarioDoComprovante);
            builder.Property(t => t.CodigoDaAdquirente);
            builder.Property(t => t.CodigoDaBandeira);
            builder.Property(t => t.CodigoDeAjusteNexxera);
            builder.Property(t => t.CodigoDeAutorizacao);
            builder.Property(t => t.CodigoDeCompensacaoDoBanco);
            builder.Property(t => t.CodigoDoProduto);
            builder.Property(t => t.CodigoOriginalDeAjusteNexxera);
            builder.Property(t => t.ContaDeDeposito);
            builder.Property(t => t.ControleERP);
            builder.Property(t => t.DataDaVendaAjuste);
            builder.Property(t => t.DataDeEnvioAoBanco);
            builder.Property(t => t.DataDeReferencia);
            builder.Property(t => t.DataDoLancamentoDoAjuste);
            builder.Property(t => t.DataDoResumoDeAjuste);
            builder.Property(t => t.DescricaoDoMotivoDoAjuste);
            builder.Property(t => t.HashId);
            builder.Property(t => t.IdDaOcorrencia);
            builder.Property(t => t.NomeDaAdquirente);
            builder.Property(t => t.NSUCV);
            builder.Property(t => t.NumeroDaNotaFiscal);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDeReferencia);
            builder.Property(t => t.NumeroDoCartao);
            builder.Property(t => t.NumeroDoProcesso);
            builder.Property(t => t.NumeroDoResumoAtual);
            builder.Property(t => t.NumeroDoResumoOriginal);
            builder.Property(t => t.NumeroTotalDeParcelas);
            builder.Property(t => t.PDVAjustado);
            builder.Property(t => t.PDVOriginal);
            builder.Property(t => t.PDVTEF);
            builder.Property(t => t.StatusDeLancamento);
            builder.Property(t => t.TID);
            builder.Property(t => t.TipoDeCaptura);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.TipoDoLancamento);
            builder.Property(t => t.ValorBrutoDaParcelaAjuste);
            builder.Property(t => t.ValorDescontoDoResumo);
            builder.Property(t => t.ValorDoAjuste);
            builder.Property(t => t.ValorLiquidoDoResumo);
            builder.Property(t => t.ValorTaxaDeServico);
        }
    }
}