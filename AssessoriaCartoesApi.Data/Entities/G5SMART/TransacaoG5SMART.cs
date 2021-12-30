namespace AssessoriaCartoesApi.Data.Entities.G5SMART
{
    public class TransacaoG5SMART : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdquirente { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVAdquirente { get; set; }
        public string NumeroDoResumoRV { get; set; }
        public string NSUCV { get; set; }
        public string CodigoDeAutorizacao { get; set; }
        public string CodigoDoBancoDeposito { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string DataDaVenda { get; set; }
        public string NumeroDaParcela { get; set; }
        public string NumeroTotalDeParcelas { get; set; }
        public string ValorLiquidoDaParcela { get; set; }
        public string DataDoCreditoDaParcela { get; set; }
        public string TipoDeVenda { get; set; }
        public string ValorBrutoDaParcela { get; set; }
        public string IndentificacaoDeConciliacao { get; set; }
        public string NumeroDaNotaFiscal { get; set; }
        public string TID { get; set; }
        public string BPAGID { get; set; }
        public string NSUTEF { get; set; }
        public string StatusDePagamento { get; set; }
        public string DataDeEnvioAoBanco { get; set; }
        public string BandeiraDoComprovante { get; set; }
        public string CodigoAgrupadorBancarioDoComprovante { get; set; }
        public string ControleERP { get; set; }
        public string NumeroDoCartao { get; set; }
        public string ValorDoDescontoDaParcela { get; set; }
        public string NumeroTerminal { get; set; }
        public string TipoDeCaptura { get; set; }
        public string ValorTotalBrutoDaVenda { get; set; }
        public string ValorTotalDoDescontoDaVenda { get; set; }
        public string ValorTotalLiquidoDaVenda { get; set; }
        public string DataDoResumoDaVenda { get; set; }
        public string HoraTransacao { get; set; }
        public string TaxaDeDesconto { get; set; }
        public string CodigoDoBancoLiquidada { get; set; }
        public string AgenciaLiquidada { get; set; }
        public string ContaCorrenteLiquidada { get; set; }
        public string ValorBrutoParcelaDeCreditoResumo { get; set; }
        public string ValorDescontoDaParcelaDeCreditoResumo { get; set; }
        public string ValorLiquidoDaParcelaDeCreditoResumo { get; set; }
        public string StatusDaConciliacao { get; set; }
        public string OrdemDaInformacao { get; set; }
        public string CodigoDaAdquirente { get; set; }
        public string CodigoDaBandeira { get; set; }
        public string PDVTEF { get; set; }
        public string TipoDeLancamento { get; set; }
        public string ValorDoDescontoAntecipacaoParcelaVenda { get; set; }
        public string ValorLiquidoAntecipacaoParcelaVenda { get; set; }
        public string HashId { get; set; }
        public string DataDoDeposito { get; set; }
        public string DescricaoDaConciliacaoManualBancaria { get; set; }
    }
}