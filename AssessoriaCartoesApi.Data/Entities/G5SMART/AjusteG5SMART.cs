namespace AssessoriaCartoesApi.Data.Entities.G5SMART
{
    public class AjusteG5SMART : Entity
    {
        public string TipoDeRegistro { get; set; }
        public string NomeDaAdquirente { get; set; }
        public string CNPJDoEstabelecimento { get; set; }
        public string PDVAjustado { get; set; }
        public string PDVOriginal { get; set; }
        public string NumeroDoResumoAtual { get; set; }
        public string NumeroDoResumoOriginal { get; set; }
        public string NSUCV { get; set; }
        public string CodigoDeAutorizacao { get; set; }
        public string DataDaVendaAjuste { get; set; }
        public string NumeroDaParcela { get; set; }
        public string ValorDoAjuste { get; set; }
        public string DataDoLancamentoDoAjuste { get; set; }
        public string TipoDoLancamento { get; set; }
        public string ValorBrutoDaParcelaAjuste { get; set; }
        public string DescricaoDoMotivoDoAjuste { get; set; }
        public string CodigoDeAjusteNexxera { get; set; }
        public string NumeroDaNotaFiscal { get; set; }
        public string TID { get; set; }
        public string CodigoOriginalDeAjusteNexxera { get; set; }
        public string IdDaOcorrencia { get; set; }
        public string StatusDeLancamento { get; set; }
        public string DataDeEnvioAoBanco { get; set; }
        public string ValorLiquidoDoResumo { get; set; }
        public string ValorDescontoDoResumo { get; set; }
        public string CodigoDeCompensacaoDoBanco { get; set; }
        public string AgenciaDeDeposito { get; set; }
        public string ContaDeDeposito { get; set; }
        public string CodigoAgrupadorBancarioDoComprovante { get; set; }
        public string DataDoResumoDeAjuste { get; set; }
        public string NumeroDoCartao { get; set; }
        public string ValorTaxaDeServico { get; set; }
        public string NumeroDoProcesso { get; set; }
        public string NumeroDeReferencia { get; set; }
        public string DataDeReferencia { get; set; }
        public string TipoDeCaptura { get; set; }
        public string CodigoDaAdquirente { get; set; }
        public string NumeroTotalDeParcelas { get; set; }
        public string CodigoDaBandeira { get; set; }
        public string PDVTEF { get; set; }
        public string BPAGID { get; set; }
        public string ControleERP { get; set; }
        public string CodigoDoProduto { get; set; }
        public string HashId { get; set; }
    }
}