namespace AssessoriaCartoesApi.Data.Entities.EASSESSORIA
{
    public class AntecipacaoEASSESSORIA : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdquirente { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVAdquirente { get; set; }
        public string NumeroDoResumoRV { get; set; }
        public string DataDoVencimento { get; set; }
        public string NumeroDaParcelaDeResumo { get; set; }
        public string DataDoCreditoDaParcela { get; set; }
        public string CodigoDeCompensacaoDoBanco { get; set; }
        public string AgenciaDeDepositoDoCredito { get; set; }
        public string ContaDeDepositoDoCredito { get; set; }
        public string ValorInicialNegociadoParaAAntecipacao { get; set; }
        public string ValorDescontoAntecipacaoDeRecebiveis { get; set; }
        public string ValorLiquidoCreditado { get; set; }
        public string ValorLiquidoOriginalDaParcelaDeResumo { get; set; }
        public string DataDoResumoDeVenda { get; set; }
        public string ValorBrutoOriginalDaParcelaDeResumo { get; set; }
        public string ValorDescontoOriginalDaParcelaDeResumo { get; set; }
        public string CodigoDaAdquirente { get; set; }
        public string StatusDeConciliacao { get; set; }
        public string CodigoDaBandeira { get; set; }
        public string TotalDeParcelas { get; set; }
        public string TipoDeVenda { get; set; }
    }
}