namespace AssessoriaCartoesApi.Data.Entities.EASSESSORIA
{
    public class FinanceiraSemVendaEASSESSORIA : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdquirente { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVAdquirente { get; set; }
        public string NumeroDoResumoRV { get; set; }
        public string DataDoResumoRV { get; set; }
        public string NumeroDaParcela { get; set; }
        public string DataDoCreditoDaParcela { get; set; }
        public string CodigoDoBanco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string ValorBrutoDaParcelaResumo { get; set; }
        public string ValorDescontoDaParcelaResumo { get; set; }
        public string ValorLiquidoDaParcelaResumo { get; set; }
        public string ValorDescontoDaAntecipacaoResumo { get; set; }
        public string ValorPagoParcelaResumo { get; set; }
        public string CodigoDeAdquirente { get; set; }
        public string CodigoAgrupadorBancarioResumo { get; set; }
        public string BandeiraDoComprovante { get; set; }
        public string TipoDeVenda { get; set; }
        public string CodigoDaBandeira { get; set; }
    }
}