namespace AssessoriaCartoesApi.Data.Entities.EASSESSORIA
{
    public class AntecipacaoEASSESSORIA : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdministradora { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVOperadora { get; set; }
        public string NumeroDoResumo { get; set; }
        public string DataDoVencimento { get; set; }
        public string NumeroDaParcela { get; set; }
        public string DataDoCreditoDaParcela { get; set; }
        public string CodigoDeCompensacaoDoBanco { get; set; }
        public string AgenciaDeDepositoDoCredito { get; set; }
        public string ContaDeDepositoDoCredito { get; set; }
        public string ValorInicialNegociadoParaAAntecipacao { get; set; }
        public string ValorDescontoAntecipacaoDeRecebiveis { get; set; }
        public string ValorLiquidoCreditado { get; set; }
        public string CodigoDeAjuste { get; set; }
        public string ValorCreditoLiquidoOriginal { get; set; }
        public string DataDoResumoDeVenda { get; set; }
        public string ValorBrutoDaParcelaDeResumo { get; set; }
        public string ValorDescontoDaParcelaDeResumo { get; set; }
    }
}