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

            builder.Property(t => t.Agencia);
            builder.Property(t => t.AgenciaLiquidada);
            builder.Property(t => t.BandeiraDoComprovante);
            builder.Property(t => t.BPAGID);
            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.CodigoAgrupadorBancarioDoComprovante);
            builder.Property(t => t.CodigoDaAdquirente);
            builder.Property(t => t.CodigoDaBandeira);
            builder.Property(t => t.CodigoDeAutorizacao);
            builder.Property(t => t.CodigoDoBancoDeposito);
            builder.Property(t => t.CodigoDoBancoLiquidada);
            builder.Property(t => t.ContaCorrente);
            builder.Property(t => t.ContaCorrenteLiquidada);
            builder.Property(t => t.ControleERP);
            builder.Property(t => t.DataDaVenda);
            builder.Property(t => t.DataDeEnvioAoBanco);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.DataDoDeposito);
            builder.Property(t => t.DataDoResumoDaVenda);
            builder.Property(t => t.DescricaoDaConciliacaoManualBancaria);
            builder.Property(t => t.HashId);
            builder.Property(t => t.HoraTransacao);
            builder.Property(t => t.IndentificacaoDeConciliacao);
            builder.Property(t => t.NomeDaAdquirente);
            builder.Property(t => t.NSUCV);
            builder.Property(t => t.NSUTEF);
            builder.Property(t => t.NumeroDaNotaFiscal);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDoCartao);
            builder.Property(t => t.NumeroDoResumoRV);
            builder.Property(t => t.NumeroTerminal);
            builder.Property(t => t.NumeroTotalDeParcelas);
            builder.Property(t => t.OrdemDaInformacao);
            builder.Property(t => t.PDVAdquirente);
            builder.Property(t => t.PDVTEF);
            builder.Property(t => t.StatusDaConciliacao);
            builder.Property(t => t.StatusDePagamento);
            builder.Property(t => t.TaxaDeDesconto);
            builder.Property(t => t.TID);
            builder.Property(t => t.TipoDeCaptura);
            builder.Property(t => t.TipoDeLancamento);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.TipoDeVenda);
            builder.Property(t => t.ValorBrutoDaParcela);
            builder.Property(t => t.ValorBrutoParcelaDeCreditoResumo);
            builder.Property(t => t.ValorDescontoDaParcelaDeCreditoResumo);
            builder.Property(t => t.ValorDoDescontoAntecipacaoParcelaVenda);
            builder.Property(t => t.ValorDoDescontoDaParcela);
            builder.Property(t => t.ValorLiquidoAntecipacaoParcelaVenda);
            builder.Property(t => t.ValorLiquidoDaParcela);
            builder.Property(t => t.ValorLiquidoDaParcelaDeCreditoResumo);
            builder.Property(t => t.ValorTotalBrutoDaVenda);
            builder.Property(t => t.ValorTotalDoDescontoDaVenda);
            builder.Property(t => t.ValorTotalLiquidoDaVenda);
        }
    }
}