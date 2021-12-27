﻿using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssessoriaCartoesApi.Data.Mapping
{
    public class AntecipacaoEASSESSORIAMap : IEntityTypeConfiguration<AntecipacaoEASSESSORIA>
    {
        void IEntityTypeConfiguration<AntecipacaoEASSESSORIA>.Configure(EntityTypeBuilder<AntecipacaoEASSESSORIA> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CNPJDoEstabelecimento);
            builder.Property(t => t.AgenciaDeDepositoDoCredito);
            builder.Property(t => t.CodigoDeAjuste);
            builder.Property(t => t.CodigoDeCompensacaoDoBanco);
            builder.Property(t => t.ContaDeDepositoDoCredito);
            builder.Property(t => t.DataDoCreditoDaParcela);
            builder.Property(t => t.DataDoResumoDeVenda);
            builder.Property(t => t.DataDoVencimento);
            builder.Property(t => t.NomeDaAdministradora);
            builder.Property(t => t.NumeroDaParcela);
            builder.Property(t => t.NumeroDoResumo);
            builder.Property(t => t.PDVOperadora);
            builder.Property(t => t.TipoDeRegistro);
            builder.Property(t => t.ValorBrutoDaParcelaDeResumo);
            builder.Property(t => t.ValorCreditoLiquidoOriginal);
            builder.Property(t => t.ValorDescontoAntecipacaoDeRecebiveis);
            builder.Property(t => t.ValorDescontoDaParcelaDeResumo);
            builder.Property(t => t.ValorInicialNegociadoParaAAntecipacao);
            builder.Property(t => t.ValorLiquidoCreditado);
        }
    }
}