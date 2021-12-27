using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class FinanceiroEASSESSORIAMap : IEntityTypeConfiguration<FinanceiroEASSESSORIA>
    {
        void IEntityTypeConfiguration<FinanceiroEASSESSORIA>.Configure(EntityTypeBuilder<FinanceiroEASSESSORIA> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.AgenciaDeDepositoDoCredito);
            builder.Property(t => t.BPAGID);
            builder.Property(t => t.CodigoAgrupadorBancarioDoComprovante);
            builder.Property(t => t.CodigoDeAutorizacao);
            builder.Property(t => t.CodigoDeCompensacaoDoBanco);
            builder.Property(t => t.CodigoDeControleInterno);
            builder.Property(t => t.ContaDeDepositoDoCredito);
            builder.Property(t => t.DataDaVenda);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.IndicacaoDeFinanceiroConciliacaoBancariaVenda);
            builder.Property(t => t.NomeDaAdministradora);
            builder.Property(t => t.NomeDaBandeira);
            builder.Property(t => t.NSUCV);
            builder.Property(t => t.NSUTEF);
            builder.Property(t => t.NumeroDaNotaFiscal);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDoResumo);
            builder.Property(t => t.NumeroTotalDeParcelas);
            builder.Property(t => t.PDV);
            builder.Property(t => t.TID);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.TipoDeRegistroTabelaII);
            builder.Property(t => t.ValorBrutoDaParcela);
            builder.Property(t => t.ValorLiquidoDaParcela);
            builder.Property(t => t.Vazio);
            builder.Property(t => t.Vazio1);
            builder.Property(t => t.Vazio2);
            builder.Property(t => t.Vazio3);
            builder.Property(t => t.Vazio4);
            builder.Property(t => t.Vazio5);
            builder.Property(t => t.Vazio6);
        }
    }
}