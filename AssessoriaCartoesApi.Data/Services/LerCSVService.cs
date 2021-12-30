using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using AssessoriaCartoesApi.Data.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Services
{
    public class LerCSVService : ILerCSVService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogRepository _logRepository;

        private readonly IAjusteEASSESSORIARepository _ajusteEASSESSORIARepository;
        private readonly IAntecipacaoEASSESSORIARepository _antecipacaoEASSESSORIARepository;
        private readonly IFinanceiraSemVendaEASSESSORIARepository _financeiraSemVendaEASSESSORIARepository;
        private readonly IFinanceiroEASSESSORIARepository _financeiroEASSESSORIARepository;
        private readonly ITransacaoEASSESSORIARepository _transacaoEASSESSORIARepository;
        private readonly IVendaEASSESSORIARepository _vendaEASSESSORIARepository;

        private readonly IAjusteG5SMARTRepository _ajusteG5SMARTRepository;
        private readonly IAntecipacaoG5SMARTRepository _antecipacaoG5SMARTRepository;
        private readonly IFinanceiraSemVendaG5SMARTRepository _financeiraSemVendaG5SMARTRepository;
        private readonly IFinanceiroG5SMARTRepository _financeiroG5SMARTRepository;
        private readonly ITransacaoG5SMARTRepository _transacaoG5SMARTRepository;
        private readonly IVendaG5SMARTRepository _vendaG5SMARTRepository;

        List<LogNexxera> _logsNexxera = new();

        List<AjusteEASSESSORIA> ajusteEASSESSORIAs = new();
        List<AntecipacaoEASSESSORIA> antecipacaoEASSESSORIAs = new();
        List<FinanceiraSemVendaEASSESSORIA> financeiraSemVendaEASSESSORIAs = new();
        List<FinanceiroEASSESSORIA> financeiroEASSESSORIAs = new();
        List<TransacaoEASSESSORIA> transacaoEASSESSORIAs = new(); // tipo não identificado ainda
        List<VendaEASSESSORIA> vendaEASSESSORIAs = new();

        List<AjusteG5SMART> ajusteG5SMARTs = new();
        List<AntecipacaoG5SMART> antecipacaoG5SMARTs = new();
        List<FinanceiraSemVendaG5SMART> financeiraSemVendaG5SMARTs = new();
        List<FinanceiroG5SMART> financeiroG5SMARTs = new();
        List<TransacaoG5SMART> transacaoG5SMARTs = new(); // tipo não identificado ainda
        List<VendaG5SMART> vendaG5SMARTs = new();

        public LerCSVService(IUnitOfWork unitOfWork, IAjusteEASSESSORIARepository ajusteEASSESSORIARepository, IAntecipacaoEASSESSORIARepository antecipacaoEASSESSORIARepository, IFinanceiraSemVendaEASSESSORIARepository financeiraSemVendaEASSESSORIARepository, IFinanceiroEASSESSORIARepository financeiroEASSESSORIARepository, ITransacaoEASSESSORIARepository transacaoEASSESSORIARepository, IVendaEASSESSORIARepository vendaEASSESSORIARepository, IAjusteG5SMARTRepository ajusteG5SMARTRepository, IAntecipacaoG5SMARTRepository antecipacaoG5SMARTRepository, IFinanceiraSemVendaG5SMARTRepository financeiraSemVendaG5SMARTRepository, IFinanceiroG5SMARTRepository financeiroG5SMARTRepository, ITransacaoG5SMARTRepository transacaoG5SMARTRepository, IVendaG5SMARTRepository vendaG5SMARTRepository, ILogRepository logRepository)
        {
            _unitOfWork = unitOfWork;
            _ajusteEASSESSORIARepository = ajusteEASSESSORIARepository;
            _antecipacaoEASSESSORIARepository = antecipacaoEASSESSORIARepository;
            _financeiraSemVendaEASSESSORIARepository = financeiraSemVendaEASSESSORIARepository;
            _financeiroEASSESSORIARepository = financeiroEASSESSORIARepository;
            _transacaoEASSESSORIARepository = transacaoEASSESSORIARepository;
            _vendaEASSESSORIARepository = vendaEASSESSORIARepository;
            _ajusteG5SMARTRepository = ajusteG5SMARTRepository;
            _antecipacaoG5SMARTRepository = antecipacaoG5SMARTRepository;
            _financeiraSemVendaG5SMARTRepository = financeiraSemVendaG5SMARTRepository;
            _financeiroG5SMARTRepository = financeiroG5SMARTRepository;
            _transacaoG5SMARTRepository = transacaoG5SMARTRepository;
            _vendaG5SMARTRepository = vendaG5SMARTRepository;
            _logRepository = logRepository;
        }

        public async Task Executar(List<string> dados, string filename, string caixaPostal)
        {
            await LimparListas();

            if (caixaPostal.Equals("G5SMART"))
            {
                await ProcessarG5SMART(dados.ToArray(), filename);
                await SalvarListasNoBancoDeDadosG5SMART();
            }

            if (caixaPostal.Equals("EASSESSORIA"))
            {
                await ProcessarEASSESSORIA(dados.ToArray(), filename);
                await SalvarListasNoBancoDeDadosEASSESSORIA();
            }

            await SalvarLogs();
        }

        private Task LimparListas()
        {
            ajusteEASSESSORIAs.Clear();
            antecipacaoEASSESSORIAs.Clear();
            financeiraSemVendaEASSESSORIAs.Clear();
            financeiroEASSESSORIAs.Clear();
            transacaoEASSESSORIAs.Clear(); // tipo não identificado ainda
            vendaEASSESSORIAs.Clear();

            ajusteG5SMARTs.Clear();
            antecipacaoG5SMARTs.Clear();
            financeiraSemVendaG5SMARTs.Clear();
            financeiroG5SMARTs.Clear();
            transacaoG5SMARTs.Clear(); // tipo não identificado ainda
            vendaG5SMARTs.Clear();

            _logsNexxera.Clear();

            return Task.CompletedTask;
        }

        private async Task SalvarLogs()
        {
            foreach (var item in _logsNexxera)
            {
                await _logRepository.CreateAsync(item);
            }

            await _unitOfWork.CommitAsync();
        }

        private async Task SalvarListasNoBancoDeDadosEASSESSORIA()
        {
            foreach (var item in ajusteEASSESSORIAs)
                await _ajusteEASSESSORIARepository.CreateAsync(item);

            foreach (var item in antecipacaoEASSESSORIAs)
                await _antecipacaoEASSESSORIARepository.CreateAsync(item);

            foreach (var item in financeiroEASSESSORIAs)
                await _financeiroEASSESSORIARepository.CreateAsync(item);

            foreach (var item in financeiraSemVendaEASSESSORIAs)
                await _financeiraSemVendaEASSESSORIARepository.CreateAsync(item);

            foreach (var item in vendaEASSESSORIAs)
                await _vendaEASSESSORIARepository.CreateAsync(item);

            foreach (var item in transacaoEASSESSORIAs)
                await _transacaoEASSESSORIARepository.CreateAsync(item);

            await _unitOfWork.CommitAsync();
        }

        private async Task SalvarListasNoBancoDeDadosG5SMART()
        {
            foreach (var item in ajusteG5SMARTs)
                await _ajusteG5SMARTRepository.CreateAsync(item);

            foreach (var item in antecipacaoG5SMARTs)
                await _antecipacaoG5SMARTRepository.CreateAsync(item);

            foreach (var item in financeiroG5SMARTs)
                await _financeiroG5SMARTRepository.CreateAsync(item);

            foreach (var item in financeiraSemVendaG5SMARTs)
                await _financeiraSemVendaG5SMARTRepository.CreateAsync(item);

            foreach (var item in vendaG5SMARTs)
                await _vendaG5SMARTRepository.CreateAsync(item);

            foreach (var item in transacaoG5SMARTs)
                await _transacaoG5SMARTRepository.CreateAsync(item);

            await _unitOfWork.CommitAsync();
        }

        #region G5SMART

        private Task ProcessarG5SMART(string[] dados, string filename)
        {
            foreach (var item in dados)
            {
                var arquivoToMap = item.Split(",");

                switch (arquivoToMap[0])
                {
                    case "10":
                        MapAntecipacaoG5SMART(arquivoToMap);
                        break;
                    case "11":
                        MapType11FinanceiroOuVendaG5SMART(arquivoToMap, filename);
                        break;
                    case "12":
                        MapAjusteG5SMART(arquivoToMap);
                        break;
                    case "13":
                        MapFinanceiroSemVendaG5SMART(arquivoToMap);
                        break;
                }
            }

            return Task.CompletedTask;
        }

        private void MapType11FinanceiroOuVendaG5SMART(string[] arquivoToMap, string filename)
        {
            if (filename.Contains("RELATORIO_LPN_VENDA"))
                MapVendaG5SMART(arquivoToMap);
            else if (filename.Contains("RELATORIO_LPN_TRANSACAO"))
                MapTransacaoG5SMART(arquivoToMap);
            else
                MapFinanceiroG5SMART(arquivoToMap);
        }

        private void MapTransacaoG5SMART(string[] arquivoToMap)
        {
            try
            {
                transacaoG5SMARTs.Add(new TransacaoG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapAjusteG5SMART(string[] arquivoToMap)
        {
            try
            {
                ajusteG5SMARTs.Add(new AjusteG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAjustado = arquivoToMap[3],
                    PDVOriginal = arquivoToMap[4],
                    NumeroDoResumoAtual = arquivoToMap[5],
                    NumeroDoResumoOriginal = arquivoToMap[6],
                    NSUCV = arquivoToMap[7],
                    CodigoDeAutorizacao = arquivoToMap[8],
                    DataDaVendaAjuste = arquivoToMap[9],
                    NumeroDaParcela = arquivoToMap[10],
                    ValorDoAjuste = arquivoToMap[11],
                    DataDoLancamentoDoAjuste = arquivoToMap[12],
                    TipoDoLancamento = arquivoToMap[13],
                    ValorBrutoDaParcelaAjuste = arquivoToMap[14],
                    DescricaoDoMotivoDoAjuste = arquivoToMap[15],
                    CodigoDeAjusteNexxera = arquivoToMap[16],
                    NumeroDaNotaFiscal = arquivoToMap[17],
                    TID = arquivoToMap[18],
                    CodigoOriginalDeAjusteNexxera = arquivoToMap[19],
                    IdDaOcorrencia = arquivoToMap[20],
                    StatusDeLancamento = arquivoToMap[21],
                    DataDeEnvioAoBanco = arquivoToMap[22],
                    ValorLiquidoDoResumo = arquivoToMap[23],
                    ValorDescontoDoResumo = arquivoToMap[24],
                    CodigoDeCompensacaoDoBanco = arquivoToMap[25],
                    AgenciaDeDeposito = arquivoToMap[26],
                    ContaDeDeposito = arquivoToMap[27],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
                    DataDoResumoDeAjuste = arquivoToMap[29],
                    NumeroDoCartao = arquivoToMap[30],
                    ValorTaxaDeServico = arquivoToMap[31],
                    NumeroDoProcesso = arquivoToMap[32],
                    NumeroDeReferencia = arquivoToMap[33],
                    DataDeReferencia = arquivoToMap[34],
                    TipoDeCaptura = arquivoToMap[35],
                    CodigoDaAdquirente = arquivoToMap[36],
                    NumeroTotalDeParcelas = arquivoToMap[37],
                    CodigoDaBandeira = arquivoToMap[38],
                    PDVTEF = arquivoToMap[39],
                    BPAGID = arquivoToMap[40],
                    ControleERP = arquivoToMap[41],
                    CodigoDoProduto = arquivoToMap[42],
                    HashId = arquivoToMap[43],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapAjusteG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapFinanceiroSemVendaG5SMART(string[] arquivoToMap)
        {
            try
            {
                financeiraSemVendaG5SMARTs.Add(new FinanceiraSemVendaG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    DataDoResumoRV = arquivoToMap[5],
                    NumeroDaParcela = arquivoToMap[6],
                    DataDoCreditoDaParcela = arquivoToMap[7],
                    CodigoDoBanco = arquivoToMap[8],
                    Agencia = arquivoToMap[9],
                    ContaCorrente = arquivoToMap[10],
                    ValorBrutoDaParcelaResumo = arquivoToMap[11],
                    ValorDescontoDaParcelaResumo = arquivoToMap[12],
                    ValorLiquidoDaParcelaResumo = arquivoToMap[13],
                    ValorDescontoDaAntecipacaoResumo = arquivoToMap[14],
                    ValorPagoParcelaResumo = arquivoToMap[15],
                    CodigoDeAdquirente = arquivoToMap[16],
                    CodigoAgrupadorBancarioResumo = arquivoToMap[17],
                    BandeiraDoComprovante = arquivoToMap[18],
                    TipoDeVenda = arquivoToMap[19],
                    CodigoDaBandeira = arquivoToMap[20],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroSemVendaG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapFinanceiroG5SMART(string[] arquivoToMap)
        {
            try
            {
                financeiroG5SMARTs.Add(new FinanceiroG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapVendaG5SMART(string[] arquivoToMap)
        {
            try
            {
                vendaG5SMARTs.Add(new VendaG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapVendaG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapAntecipacaoG5SMART(string[] arquivoToMap)
        {
            try
            {
                antecipacaoG5SMARTs.Add(new AntecipacaoG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    DataDoVencimento = arquivoToMap[5],
                    NumeroDaParcelaDeResumo = arquivoToMap[6],
                    DataDoCreditoDaParcela = arquivoToMap[7],
                    CodigoDeCompensacaoDoBanco = arquivoToMap[8],
                    AgenciaDeDepositoDoCredito = arquivoToMap[9],
                    ContaDeDepositoDoCredito = arquivoToMap[10],
                    ValorInicialNegociadoParaAAntecipacao = arquivoToMap[11],
                    ValorDescontoAntecipacaoDeRecebiveis = arquivoToMap[12],
                    ValorLiquidoCreditado = arquivoToMap[13],
                    ValorLiquidoOriginalDaParcelaDeResumo = arquivoToMap[14],
                    DataDoResumoDeVenda = arquivoToMap[15],
                    ValorBrutoOriginalDaParcelaDeResumo = arquivoToMap[16],
                    ValorDescontoOriginalDaParcelaDeResumo = arquivoToMap[17],
                    CodigoDaAdquirente = arquivoToMap[18],
                    StatusDeConciliacao = arquivoToMap[19],
                    CodigoDaBandeira = arquivoToMap[20],
                    TotalDeParcelas = arquivoToMap[21],
                    TipoDeVenda = arquivoToMap[22],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapAntecipacaoG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        #endregion

        #region EASSESSORIA

        private Task ProcessarEASSESSORIA(string[] dados, string filename)
        {
            foreach (var item in dados)
            {
                var arquivoToMap = item.Split(",");

                switch (arquivoToMap[0])
                {
                    case "10":
                        MapAntecipacaoEASSESSORIA(arquivoToMap);
                        break;
                    case "11":
                        MapType11FinanceiroOuVendaEASSESSORIA(arquivoToMap, filename);
                        break;
                    case "12":
                        MapAjusteEASSESSORIA(arquivoToMap);
                        break;
                    case "13":
                        MapFinanceiroSemVendaEASSESSORIA(arquivoToMap);
                        break;
                }
            }

            return Task.CompletedTask;
        }

        private void MapType11FinanceiroOuVendaEASSESSORIA(string[] arquivoToMap, string filename)
        {
            if (filename.Contains("RELATORIO_LPN_VENDA"))
                MapVendaEASSESSORIA(arquivoToMap);
            else if (filename.Contains("RELATORIO_LPN_TRANSACAO"))
                MapTransacaoEASSESSORIA(arquivoToMap);
            else
                MapFinanceiroEASSESSORIA(arquivoToMap);
        }

        private void MapTransacaoEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                transacaoEASSESSORIAs.Add(new TransacaoEASSESSORIA
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroG5SMART",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapAjusteEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                ajusteEASSESSORIAs.Add(new AjusteEASSESSORIA
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAjustado = arquivoToMap[3],
                    PDVOriginal = arquivoToMap[4],
                    NumeroDoResumoAtual = arquivoToMap[5],
                    NumeroDoResumoOriginal = arquivoToMap[6],
                    NSUCV = arquivoToMap[7],
                    CodigoDeAutorizacao = arquivoToMap[8],
                    DataDaVendaAjuste = arquivoToMap[9],
                    NumeroDaParcela = arquivoToMap[10],
                    ValorDoAjuste = arquivoToMap[11],
                    DataDoLancamentoDoAjuste = arquivoToMap[12],
                    TipoDoLancamento = arquivoToMap[13],
                    ValorBrutoDaParcelaAjuste = arquivoToMap[14],
                    DescricaoDoMotivoDoAjuste = arquivoToMap[15],
                    CodigoDeAjusteNexxera = arquivoToMap[16],
                    NumeroDaNotaFiscal = arquivoToMap[17],
                    TID = arquivoToMap[18],
                    CodigoOriginalDeAjusteNexxera = arquivoToMap[19],
                    IdDaOcorrencia = arquivoToMap[20],
                    StatusDeLancamento = arquivoToMap[21],
                    DataDeEnvioAoBanco = arquivoToMap[22],
                    ValorLiquidoDoResumo = arquivoToMap[23],
                    ValorDescontoDoResumo = arquivoToMap[24],
                    CodigoDeCompensacaoDoBanco = arquivoToMap[25],
                    AgenciaDeDeposito = arquivoToMap[26],
                    ContaDeDeposito = arquivoToMap[27],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
                    DataDoResumoDeAjuste = arquivoToMap[29],
                    NumeroDoCartao = arquivoToMap[30],
                    ValorTaxaDeServico = arquivoToMap[31],
                    NumeroDoProcesso = arquivoToMap[32],
                    NumeroDeReferencia = arquivoToMap[33],
                    DataDeReferencia = arquivoToMap[34],
                    TipoDeCaptura = arquivoToMap[35],
                    CodigoDaAdquirente = arquivoToMap[36],
                    NumeroTotalDeParcelas = arquivoToMap[37],
                    CodigoDaBandeira = arquivoToMap[38],
                    PDVTEF = arquivoToMap[39],
                    BPAGID = arquivoToMap[40],
                    ControleERP = arquivoToMap[41],
                    CodigoDoProduto = arquivoToMap[42],
                    HashId = arquivoToMap[43],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapAjusteEASSESSORIA",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapFinanceiroSemVendaEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                financeiraSemVendaG5SMARTs.Add(new FinanceiraSemVendaG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    DataDoResumoRV = arquivoToMap[5],
                    NumeroDaParcela = arquivoToMap[6],
                    DataDoCreditoDaParcela = arquivoToMap[7],
                    CodigoDoBanco = arquivoToMap[8],
                    Agencia = arquivoToMap[9],
                    ContaCorrente = arquivoToMap[10],
                    ValorBrutoDaParcelaResumo = arquivoToMap[11],
                    ValorDescontoDaParcelaResumo = arquivoToMap[12],
                    ValorLiquidoDaParcelaResumo = arquivoToMap[13],
                    ValorDescontoDaAntecipacaoResumo = arquivoToMap[14],
                    ValorPagoParcelaResumo = arquivoToMap[15],
                    CodigoDeAdquirente = arquivoToMap[16],
                    CodigoAgrupadorBancarioResumo = arquivoToMap[17],
                    BandeiraDoComprovante = arquivoToMap[18],
                    TipoDeVenda = arquivoToMap[19],
                    CodigoDaBandeira = arquivoToMap[20],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroSemVendaEASSESSORIA",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapFinanceiroEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                financeiroG5SMARTs.Add(new FinanceiroG5SMART
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapFinanceiroEASSESSORIA",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapAntecipacaoEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                antecipacaoEASSESSORIAs.Add(new AntecipacaoEASSESSORIA
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    DataDoVencimento = arquivoToMap[5],
                    NumeroDaParcelaDeResumo = arquivoToMap[6],
                    DataDoCreditoDaParcela = arquivoToMap[7],
                    CodigoDeCompensacaoDoBanco = arquivoToMap[8],
                    AgenciaDeDepositoDoCredito = arquivoToMap[9],
                    ContaDeDepositoDoCredito = arquivoToMap[10],
                    ValorInicialNegociadoParaAAntecipacao = arquivoToMap[11],
                    ValorDescontoAntecipacaoDeRecebiveis = arquivoToMap[12],
                    ValorLiquidoCreditado = arquivoToMap[13],
                    ValorLiquidoOriginalDaParcelaDeResumo = arquivoToMap[14],
                    DataDoResumoDeVenda = arquivoToMap[15],
                    ValorBrutoOriginalDaParcelaDeResumo = arquivoToMap[16],
                    ValorDescontoOriginalDaParcelaDeResumo = arquivoToMap[17],
                    CodigoDaAdquirente = arquivoToMap[18],
                    StatusDeConciliacao = arquivoToMap[19],
                    CodigoDaBandeira = arquivoToMap[20],
                    TotalDeParcelas = arquivoToMap[21],
                    TipoDeVenda = arquivoToMap[22],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapAntecipacaoEASSESSORIA",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        private void MapVendaEASSESSORIA(string[] arquivoToMap)
        {
            try
            {
                vendaEASSESSORIAs.Add(new VendaEASSESSORIA
                {
                    TipoDeRegistro = arquivoToMap[0],
                    NomeDaAdquirente = arquivoToMap[1],
                    CNPJDoEstabelecimento = arquivoToMap[2],
                    PDVAdquirente = arquivoToMap[3],
                    NumeroDoResumoRV = arquivoToMap[4],
                    NSUCV = arquivoToMap[5],
                    CodigoDeAutorizacao = arquivoToMap[6],
                    CodigoDoBancoDeposito = arquivoToMap[7],
                    Agencia = arquivoToMap[8],
                    ContaCorrente = arquivoToMap[9],
                    DataDaVenda = arquivoToMap[10],
                    NumeroDaParcela = arquivoToMap[11],
                    NumeroTotalDeParcelas = arquivoToMap[12],
                    ValorLiquidoDaParcela = arquivoToMap[13],
                    DataDoCreditoDaParcela = arquivoToMap[14],
                    TipoDeVenda = arquivoToMap[15],
                    ValorBrutoDaParcela = arquivoToMap[16],
                    IndentificacaoDeConciliacao = arquivoToMap[17],
                    NumeroDaNotaFiscal = arquivoToMap[18],
                    TID = arquivoToMap[19],
                    BPAGID = arquivoToMap[20],
                    NSUTEF = arquivoToMap[21],
                    StatusDePagamento = arquivoToMap[22],
                    DataDeEnvioAoBanco = arquivoToMap[23],
                    BandeiraDoComprovante = arquivoToMap[24],
                    CodigoAgrupadorBancarioDoComprovante = arquivoToMap[25],
                    ControleERP = arquivoToMap[26],
                    NumeroDoCartao = arquivoToMap[27],
                    ValorDoDescontoDaParcela = arquivoToMap[28],
                    NumeroTerminal = arquivoToMap[29],
                    TipoDeCaptura = arquivoToMap[30],
                    ValorTotalBrutoDaVenda = arquivoToMap[31],
                    ValorTotalDoDescontoDaVenda = arquivoToMap[32],
                    ValorTotalLiquidoDaVenda = arquivoToMap[33],
                    DataDoResumoDaVenda = arquivoToMap[34],
                    HoraTransacao = arquivoToMap[35],
                    TaxaDeDesconto = arquivoToMap[36],
                    CodigoDoBancoLiquidada = arquivoToMap[37],
                    AgenciaLiquidada = arquivoToMap[38],
                    ContaCorrenteLiquidada = arquivoToMap[39],
                    ValorBrutoParcelaDeCreditoResumo = arquivoToMap[40],
                    ValorDescontoDaParcelaDeCreditoResumo = arquivoToMap[41],
                    ValorLiquidoDaParcelaDeCreditoResumo = arquivoToMap[42],
                    StatusDaConciliacao = arquivoToMap[43],
                    OrdemDaInformacao = arquivoToMap[44],
                    CodigoDaAdquirente = arquivoToMap[45],
                    CodigoDaBandeira = arquivoToMap[46],
                    PDVTEF = arquivoToMap[47],
                    TipoDeLancamento = arquivoToMap[48],
                    ValorDoDescontoAntecipacaoParcelaVenda = arquivoToMap[49],
                    ValorLiquidoAntecipacaoParcelaVenda = arquivoToMap[50],
                    HashId = arquivoToMap[51],
                    DataDoDeposito = arquivoToMap[52],
                    DescricaoDaConciliacaoManualBancaria = arquivoToMap[53],
                });
            }
            catch (Exception ex)
            {
                _logsNexxera.Add(new LogNexxera
                {
                    Exception = ex.Message,
                    Filename = string.Empty,
                    Method = "MapVendaEASSESSORIA",
                    InnerException = ex?.InnerException?.Message,
                    QuantidadeColunas = arquivoToMap.Length,
                    CreateDate = DateTime.Now
                });
            }
        }

        #endregion
    }
}