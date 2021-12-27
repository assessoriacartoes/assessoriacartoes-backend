namespace AssessoriaCartoesApi.Data.Entities.EASSESSORIA
{
    public class AjusteEASSESSORIA : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdministradora { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVAjustado { get; set; }
        public string PDVOriginal { get; set; }
        public string NumeroDoResumoAtual { get; set; }
        public string NumeroDoResumoOriginal { get; set; }
        public string NSUCV { get; set; }
        public string CodigoDeAutorizacao { get; set; }
        public string DataDaVenda { get; set; }
        public string NumeroDaParcela { get; set; }
        public string ValorDoAjuste { get; set; }
        public string DataDoCreditoDaParcela { get; set; }
        public string IdentificacaoDoValor { get; set; }
        public string ValorBrutoDaParcelaAjuste { get; set; }
        public string DescricaoDoMotivoDoAjuste { get; set; }
        public string CodigoDeAjuste { get; set; }
        public string NumeroDaNotaFiscal { get; set; }
        public string TID { get; set; }
        public string CodigoOriginalDeAjuste { get; set; }
        public string IdDaOcorrencia { get; set; }
        public string StatusDePagamentos { get; set; }
        public string DataDeEnvioAoBanco { get; set; }
        public string ValorLiquidoDoResumo { get; set; }
        public string ValorDescontoDoResumo { get; set; }
        public string CodigoDeCompensacaoDoBanco { get; set; }
        public string AgenciaDeDepositoDoCredito { get; set; }
        public string ContaDeDepositoDoCredito { get; set; }
        public string CodigoAgrupadorBancarioDoComprovante { get; set; }
        public string DataDoResumoDeAjuste { get; set; }
        public string NumeroDoCartao { get; set; }
        public string ValorTaxaDeServico { get; set; }
        public string NumeroDoProcesso { get; set; }
        public string NumeroDeReferencia { get; set; }
        public string DataDeReferencia { get; set; }
        public string TipoDeCaptura { get; set; }
    }
}