using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Entities.EASSESSORIA;
using AssessoriaCartoesApi.Data.Entities.G5SMART;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using AssessoriaCartoesApi.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Services
{
    public class LerCSVService : ILerCSVService
    {
        private readonly IUnitOfWork _unitOfWork;

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

        public LerCSVService(IUnitOfWork unitOfWork, IAjusteEASSESSORIARepository ajusteEASSESSORIARepository, IAntecipacaoEASSESSORIARepository antecipacaoEASSESSORIARepository, IFinanceiraSemVendaEASSESSORIARepository financeiraSemVendaEASSESSORIARepository, IFinanceiroEASSESSORIARepository financeiroEASSESSORIARepository, ITransacaoEASSESSORIARepository transacaoEASSESSORIARepository, IVendaEASSESSORIARepository vendaEASSESSORIARepository, IAjusteG5SMARTRepository ajusteG5SMARTRepository, IAntecipacaoG5SMARTRepository antecipacaoG5SMARTRepository, IFinanceiraSemVendaG5SMARTRepository financeiraSemVendaG5SMARTRepository, IFinanceiroG5SMARTRepository financeiroG5SMARTRepository, ITransacaoG5SMARTRepository transacaoG5SMARTRepository, IVendaG5SMARTRepository vendaG5SMARTRepository)
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
        }

        public void Executar(List<string> dados, string caixaPostal)
        {
            //var arquivos = LerArquivosNaPasta();

            if (caixaPostal.Equals("G5SMART"))
            {
                ProcessarG5SMART(dados.ToArray());
                SalvarListasNoBancoDeDadosG5SMART().Wait();
            }

            if (caixaPostal.Equals("EASSESSORIA"))
            {
                ProcessarEASSESSORIA(dados.ToArray());
                SalvarListasNoBancoDeDadosEASSESSORIA().Wait();
            }
            
            //LerCSV(arquivo);
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

            await _unitOfWork.CommitAsync();
        }

        #region G5SMART

        private void ProcessarG5SMART(string[] dados)
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
                        MapFinanceiroG5SMART(arquivoToMap);
                        break;
                    case "12":
                        MapAjusteG5SMART(arquivoToMap);
                        break;
                    //case "11 Venda":
                    //    MapFinanceiroG5SMART(arquivoToMap);
                    //break;
                    case "13":
                        MapFinanceiroSemVendaG5SMART(arquivoToMap);
                        break;
                }
            }
        }

        private void MapAjusteG5SMART(string[] arquivoToMap)
        {
            ajusteG5SMARTs.Add(new AjusteG5SMART
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDVAjustado = arquivoToMap[3],
                PDVOriginal = arquivoToMap[4],
                NumeroDoResumoAtual = arquivoToMap[5],
                NumeroDoResumoOriginal = arquivoToMap[6],
                NSUCV = arquivoToMap[7],
                CodigoDeAutorizacao = arquivoToMap[8],
                DataDaVenda = arquivoToMap[9],
                NumeroDaParcela = arquivoToMap[10],
                ValorDoAjuste = arquivoToMap[11],
                DataDoCreditoDaParcela = arquivoToMap[12],
                IdentificacaoDoValor = arquivoToMap[13],
                ValorBrutoDaParcelaAjuste = arquivoToMap[14],
                DescricaoDoMotivoDoAjuste = arquivoToMap[15],
                CodigoDeAjuste = arquivoToMap[16],
                NumeroDaNotaFiscal = arquivoToMap[17],
                TID = arquivoToMap[18],
                CodigoOriginalDeAjuste = arquivoToMap[19],
                IdDaOcorrencia = arquivoToMap[20],
                StatusDePagamentos = arquivoToMap[21],
                DataDeEnvioAoBanco = arquivoToMap[22],
                ValorLiquidoDoResumo = arquivoToMap[23],
                ValorDescontoDoResumo = arquivoToMap[24],
                CodigoDeCompensacaoDoBanco = arquivoToMap[25],
                AgenciaDeDepositoDoCredito = arquivoToMap[26],
                ContaDeDepositoDoCredito = arquivoToMap[27],
                CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
                DataDoResumoDeAjuste = arquivoToMap[29],
                NumeroDoCartao = arquivoToMap[30],
                ValorTaxaDeServico = arquivoToMap[31],
                NumeroDoProcesso = arquivoToMap[32],
                NumeroDeReferencia = arquivoToMap[33],
                DataDeReferencia = arquivoToMap[34],
                TipoDeCaptura = arquivoToMap[35],
            });
        }

        private void MapFinanceiroSemVendaG5SMART(string[] arquivoToMap)
        {
            financeiraSemVendaG5SMARTs.Add(new FinanceiraSemVendaG5SMART
            {
                Coluna1 = arquivoToMap[0],
                Coluna2 = arquivoToMap[1],
                Coluna3 = arquivoToMap[2],
                Coluna4 = arquivoToMap[3],
                Coluna5 = arquivoToMap[4],
                Coluna6 = arquivoToMap[5],
                Coluna7 = arquivoToMap[6],
                Coluna8 = arquivoToMap[7],
                Coluna9 = arquivoToMap[8],
                Coluna10 = arquivoToMap[9],
                Coluna11 = arquivoToMap[10],
                Coluna12 = arquivoToMap[11],
                Coluna13 = arquivoToMap[12],
                Coluna14 = arquivoToMap[13],
                Coluna15 = arquivoToMap[14],
                Coluna16 = arquivoToMap[15],
                Coluna17 = arquivoToMap[16],
                Coluna18 = arquivoToMap[17],
                Coluna19 = arquivoToMap[18],
                Coluna20 = arquivoToMap[19],
                Coluna21 = arquivoToMap[20],
            });
        }

        private void MapFinanceiroG5SMART(string[] arquivoToMap)
        {
            financeiroG5SMARTs.Add(new FinanceiroG5SMART
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDV = arquivoToMap[3],
                NumeroDoResumo = arquivoToMap[4],
                NSUCV = arquivoToMap[5],
                CodigoDeAutorizacao = arquivoToMap[6],
                CodigoDeCompensacaoDoBanco = arquivoToMap[7],
                AgenciaDeDepositoDoCredito = arquivoToMap[8],
                ContaDeDepositoDoCredito = arquivoToMap[9],
                DataDaVenda = arquivoToMap[10],
                NumeroDaParcela = arquivoToMap[11],
                NumeroTotalDeParcelas = arquivoToMap[12],
                ValorLiquidoDaParcela = arquivoToMap[13],
                DataDoCreditoDaParcela = arquivoToMap[14],
                TipoDeRegistroTabelaII = arquivoToMap[15],
                Vazio = arquivoToMap[16],
                ValorBrutoDaParcela = arquivoToMap[17],
                Vazio1 = arquivoToMap[18],
                IndicacaoDeFinanceiroConciliacaoBancariaVenda = arquivoToMap[19],
                NumeroDaNotaFiscal = arquivoToMap[20],
                TID = arquivoToMap[21],
                BPAGID = arquivoToMap[22],
                Vazio2 = arquivoToMap[23],
                Vazio3 = arquivoToMap[24],
                NSUTEF = arquivoToMap[25],
                Vazio4 = arquivoToMap[26],
                Vazio5 = arquivoToMap[27],
                Vazio6 = arquivoToMap[28],
                NomeDaBandeira = arquivoToMap[29],
                CodigoAgrupadorBancarioDoComprovante = arquivoToMap[30],
                CodigoDeControleInterno = arquivoToMap[31],
            });
        }

        private void MapAntecipacaoG5SMART(string[] arquivoToMap)
        {
            antecipacaoG5SMARTs.Add(new AntecipacaoG5SMART
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDVOperadora = arquivoToMap[3],
                NumeroDoResumo = arquivoToMap[4],
                DataDoVencimento = arquivoToMap[5],
                NumeroDaParcela = arquivoToMap[6],
                DataDoCreditoDaParcela = arquivoToMap[7],
                CodigoDeCompensacaoDoBanco = arquivoToMap[8],
                AgenciaDeDepositoDoCredito = arquivoToMap[9],
                ContaDeDepositoDoCredito = arquivoToMap[10],
                ValorInicialNegociadoParaAAntecipacao = arquivoToMap[11],
                ValorDescontoAntecipacaoDeRecebiveis = arquivoToMap[12],
                ValorLiquidoCreditado = arquivoToMap[13],
                CodigoDeAjuste = arquivoToMap[14],
                ValorCreditoLiquidoOriginal = arquivoToMap[15],
                DataDoResumoDeVenda = arquivoToMap[16],
                ValorBrutoDaParcelaDeResumo = arquivoToMap[17],
                ValorDescontoDaParcelaDeResumo = arquivoToMap[18]
            });
        }

        #endregion

        #region EASSESSORIA

        private void ProcessarEASSESSORIA(string[] dados)
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
                        MapFinanceiroEASSESSORIA(arquivoToMap);
                        break;
                    case "12":
                        MapAjusteEASSESSORIA(arquivoToMap);
                        break;
                    //case "11 Venda":
                    //    MapFinanceiroG5SMART(arquivoToMap);
                    //break;
                    case "13":
                        MapFinanceiroSemVendaEASSESSORIA(arquivoToMap);
                        break;
                }
            }
        }

        private void MapAjusteEASSESSORIA(string[] arquivoToMap)
        {
            ajusteEASSESSORIAs.Add(new AjusteEASSESSORIA
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDVAjustado = arquivoToMap[3],
                PDVOriginal = arquivoToMap[4],
                NumeroDoResumoAtual = arquivoToMap[5],
                NumeroDoResumoOriginal = arquivoToMap[6],
                NSUCV = arquivoToMap[7],
                CodigoDeAutorizacao = arquivoToMap[8],
                DataDaVenda = arquivoToMap[9],
                NumeroDaParcela = arquivoToMap[10],
                ValorDoAjuste = arquivoToMap[11],
                DataDoCreditoDaParcela = arquivoToMap[12],
                IdentificacaoDoValor = arquivoToMap[13],
                ValorBrutoDaParcelaAjuste = arquivoToMap[14],
                DescricaoDoMotivoDoAjuste = arquivoToMap[15],
                CodigoDeAjuste = arquivoToMap[16],
                NumeroDaNotaFiscal = arquivoToMap[17],
                TID = arquivoToMap[18],
                CodigoOriginalDeAjuste = arquivoToMap[19],
                IdDaOcorrencia = arquivoToMap[20],
                StatusDePagamentos = arquivoToMap[21],
                DataDeEnvioAoBanco = arquivoToMap[22],
                ValorLiquidoDoResumo = arquivoToMap[23],
                ValorDescontoDoResumo = arquivoToMap[24],
                CodigoDeCompensacaoDoBanco = arquivoToMap[25],
                AgenciaDeDepositoDoCredito = arquivoToMap[26],
                ContaDeDepositoDoCredito = arquivoToMap[27],
                CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
                DataDoResumoDeAjuste = arquivoToMap[29],
                NumeroDoCartao = arquivoToMap[30],
                ValorTaxaDeServico = arquivoToMap[31],
                NumeroDoProcesso = arquivoToMap[32],
                NumeroDeReferencia = arquivoToMap[33],
                DataDeReferencia = arquivoToMap[34],
                TipoDeCaptura = arquivoToMap[35],
            });
        }

        private void MapFinanceiroSemVendaEASSESSORIA(string[] arquivoToMap)
        {
            financeiraSemVendaG5SMARTs.Add(new FinanceiraSemVendaG5SMART
            {
                Coluna1 = arquivoToMap[0],
                Coluna2 = arquivoToMap[1],
                Coluna3 = arquivoToMap[2],
                Coluna4 = arquivoToMap[3],
                Coluna5 = arquivoToMap[4],
                Coluna6 = arquivoToMap[5],
                Coluna7 = arquivoToMap[6],
                Coluna8 = arquivoToMap[7],
                Coluna9 = arquivoToMap[8],
                Coluna10 = arquivoToMap[9],
                Coluna11 = arquivoToMap[10],
                Coluna12 = arquivoToMap[11],
                Coluna13 = arquivoToMap[12],
                Coluna14 = arquivoToMap[13],
                Coluna15 = arquivoToMap[14],
                Coluna16 = arquivoToMap[15],
                Coluna17 = arquivoToMap[16],
                Coluna18 = arquivoToMap[17],
                Coluna19 = arquivoToMap[18],
                Coluna20 = arquivoToMap[19],
                Coluna21 = arquivoToMap[20],
            });
        }

        private void MapFinanceiroEASSESSORIA(string[] arquivoToMap)
        {
            financeiroG5SMARTs.Add(new FinanceiroG5SMART
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDV = arquivoToMap[3],
                NumeroDoResumo = arquivoToMap[4],
                NSUCV = arquivoToMap[5],
                CodigoDeAutorizacao = arquivoToMap[6],
                CodigoDeCompensacaoDoBanco = arquivoToMap[7],
                AgenciaDeDepositoDoCredito = arquivoToMap[8],
                ContaDeDepositoDoCredito = arquivoToMap[9],
                DataDaVenda = arquivoToMap[10],
                NumeroDaParcela = arquivoToMap[11],
                NumeroTotalDeParcelas = arquivoToMap[12],
                ValorLiquidoDaParcela = arquivoToMap[13],
                DataDoCreditoDaParcela = arquivoToMap[14],
                TipoDeRegistroTabelaII = arquivoToMap[15],
                Vazio = arquivoToMap[16],
                ValorBrutoDaParcela = arquivoToMap[17],
                Vazio1 = arquivoToMap[18],
                IndicacaoDeFinanceiroConciliacaoBancariaVenda = arquivoToMap[19],
                NumeroDaNotaFiscal = arquivoToMap[20],
                TID = arquivoToMap[21],
                BPAGID = arquivoToMap[22],
                Vazio2 = arquivoToMap[23],
                Vazio3 = arquivoToMap[24],
                NSUTEF = arquivoToMap[25],
                Vazio4 = arquivoToMap[26],
                Vazio5 = arquivoToMap[27],
                Vazio6 = arquivoToMap[28],
                NomeDaBandeira = arquivoToMap[29],
                CodigoAgrupadorBancarioDoComprovante = arquivoToMap[30],
                CodigoDeControleInterno = arquivoToMap[31],
            });
        }

        private void MapAntecipacaoEASSESSORIA(string[] arquivoToMap)
        {
            antecipacaoEASSESSORIAs.Add(new AntecipacaoEASSESSORIA
            {
                TipoDeRegistro = arquivoToMap[0],
                NomeDaAdministradora = arquivoToMap[1],
                CNPJDoEstabelecimento = arquivoToMap[2],
                PDVOperadora = arquivoToMap[3],
                NumeroDoResumo = arquivoToMap[4],
                DataDoVencimento = arquivoToMap[5],
                NumeroDaParcela = arquivoToMap[6],
                DataDoCreditoDaParcela = arquivoToMap[7],
                CodigoDeCompensacaoDoBanco = arquivoToMap[8],
                AgenciaDeDepositoDoCredito = arquivoToMap[9],
                ContaDeDepositoDoCredito = arquivoToMap[10],
                ValorInicialNegociadoParaAAntecipacao = arquivoToMap[11],
                ValorDescontoAntecipacaoDeRecebiveis = arquivoToMap[12],
                ValorLiquidoCreditado = arquivoToMap[13],
                CodigoDeAjuste = arquivoToMap[14],
                ValorCreditoLiquidoOriginal = arquivoToMap[15],
                DataDoResumoDeVenda = arquivoToMap[16],
                ValorBrutoDaParcelaDeResumo = arquivoToMap[17],
                ValorDescontoDaParcelaDeResumo = arquivoToMap[18]
            });
        }

        #endregion

        //private async Task SalvarVenda()
        //{
        //    //foreach (var item in listType12)
        //    //    await _ajusteRepository.CreateAsync(item);

        //    //await _unitOfWork.CommitAsync();
        //    await Task.CompletedTask;
        //}

        //private async Task SalvarTransacao()
        //{
        //    //foreach (var item in listType)
        //    //    await _transacaoRepository.CreateAsync(item);

        //    //await _unitOfWork.CommitAsync();
        //    await Task.CompletedTask;
        //}

        //private async Task SalvarFinanceiro()
        //{
        //    foreach (var item in listType11Financeiro)
        //        await _financeiroRepository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarFinanceiroSemVenda()
        //{
        //    foreach (var item in listType13)
        //        await _financeiraSemVendaRepository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarAntecipacao()
        //{
        //    foreach (var item in listType10)
        //        await _antecipacaoRepository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarAjuste()
        //{
        //    foreach (var item in listType12)
        //        await _ajusteRepository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private FileInfo[] LerArquivosNaPasta()
        //{
        //    DirectoryInfo diretorio = new DirectoryInfo(@"C:\Users\Alesandro\Desktop\Clientes\assessoria cartoes\exemplosCsv\");
        //    return diretorio.GetFiles("*.*");
        //}

        //public void LerCSV(string arquivo)
        //{
        //    var arquivoToMap = arquivo.Split(",");

        //    switch (arquivoToMap[0])
        //    {
        //        case "10":
        //            MapType10(arquivoToMap);
        //            break;
        //        case "11":
        //            MapType11(arquivoToMap);
        //            break;
        //        case "12":
        //            MapType12(arquivoToMap);
        //            break;
        //        case "13":
        //            MapType13(arquivoToMap);
        //            break;
        //    }
        //}

        //private void MapType13(string[] arquivoToMap)
        //{
        //    listType13.Add(new FinanceiraSemVendaEASSESSORIA
        //    {
        //        Coluna1 = arquivoToMap[0],
        //        Coluna2 = arquivoToMap[1],
        //        Coluna3 = arquivoToMap[2],
        //        Coluna4 = arquivoToMap[3],
        //        Coluna5 = arquivoToMap[4],
        //        Coluna6 = arquivoToMap[5],
        //        Coluna7 = arquivoToMap[6],
        //        Coluna8 = arquivoToMap[7],
        //        Coluna9 = arquivoToMap[8],
        //        Coluna10 = arquivoToMap[9],
        //        Coluna11 = arquivoToMap[10],
        //        Coluna12 = arquivoToMap[11],
        //        Coluna13 = arquivoToMap[12],
        //        Coluna14 = arquivoToMap[13],
        //        Coluna15 = arquivoToMap[14],
        //        Coluna16 = arquivoToMap[15],
        //        Coluna17 = arquivoToMap[16],
        //        Coluna18 = arquivoToMap[17],
        //        Coluna19 = arquivoToMap[18],
        //        Coluna20 = arquivoToMap[19],
        //        Coluna21 = arquivoToMap[20],
        //    });
        //}

        //private void MapAjusteG5SMART(string[] arquivoToMap)
        //{
        //    listType12.Add(new AjusteG5SMART
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDaAdministradora = arquivoToMap[1],
        //        CNPJDoEstabelecimento = arquivoToMap[2],
        //        PDVAjustado = arquivoToMap[3],
        //        PDVOriginal = arquivoToMap[4],
        //        NumeroDoResumoAtual = arquivoToMap[5],
        //        NumeroDoResumoOriginal = arquivoToMap[6],
        //        NSUCV = arquivoToMap[7],
        //        CodigoDeAutorizacao = arquivoToMap[8],
        //        DataDaVenda = arquivoToMap[9],
        //        NumeroDaParcela = arquivoToMap[10],
        //        ValorDoAjuste = arquivoToMap[11],
        //        DataDoCreditoDaParcela = arquivoToMap[12],
        //        IdentificacaoDoValor = arquivoToMap[13],
        //        ValorBrutoDaParcelaAjuste = arquivoToMap[14],
        //        DescricaoDoMotivoDoAjuste = arquivoToMap[15],
        //        CodigoDeAjuste = arquivoToMap[16],
        //        NumeroDaNotaFiscal = arquivoToMap[17],
        //        TID = arquivoToMap[18],
        //        CodigoOriginalDeAjuste = arquivoToMap[19],
        //        IdDaOcorrencia = arquivoToMap[20],
        //        StatusDePagamentos = arquivoToMap[21],
        //        DataDeEnvioAoBanco = arquivoToMap[22],
        //        ValorLiquidoDoResumo = arquivoToMap[23],
        //        ValorDescontoDoResumo = arquivoToMap[24],
        //        CodigoDeCompensacaoDoBanco = arquivoToMap[25],
        //        AgenciaDeDepositoDoCredito = arquivoToMap[26],
        //        ContaDeDepositoDoCredito = arquivoToMap[27],
        //        CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
        //        DataDoResumoDeAjuste = arquivoToMap[29],
        //        NumeroDoCartao = arquivoToMap[30],
        //        ValorTaxaDeServico = arquivoToMap[31],
        //        NumeroDoProcesso = arquivoToMap[32],
        //        NumeroDeReferencia = arquivoToMap[33],
        //        DataDeReferencia = arquivoToMap[34],
        //        TipoDeCaptura = arquivoToMap[35],
        //    });
        //}

        //private void MapType11(string[] arquivoToMap)
        //{
        //    listType11Financeiro.Add(new FinanceiroEASSESSORIA
        //    {
        //        Coluna1 = arquivoToMap[0],
        //        Coluna2 = arquivoToMap[1],
        //        Coluna3 = arquivoToMap[2],
        //        Coluna4 = arquivoToMap[3],
        //        Coluna5 = arquivoToMap[4],
        //        Coluna6 = arquivoToMap[5],
        //        Coluna7 = arquivoToMap[6],
        //        Coluna8 = arquivoToMap[7],
        //        Coluna9 = arquivoToMap[8],
        //        Coluna10 = arquivoToMap[9],
        //        Coluna11 = arquivoToMap[10],
        //        Coluna12 = arquivoToMap[11],
        //        Coluna13 = arquivoToMap[12],
        //        Coluna14 = arquivoToMap[13],
        //        Coluna15 = arquivoToMap[14],
        //        Coluna16 = arquivoToMap[15],
        //        Coluna17 = arquivoToMap[16],
        //        Coluna18 = arquivoToMap[17],
        //        Coluna19 = arquivoToMap[18],
        //        Coluna20 = arquivoToMap[19],
        //        Coluna21 = arquivoToMap[20],
        //        Coluna22 = arquivoToMap[21],
        //        Coluna23 = arquivoToMap[22],
        //        Coluna24 = arquivoToMap[23],
        //        Coluna25 = arquivoToMap[24],
        //        Coluna26 = arquivoToMap[25],
        //        Coluna27 = arquivoToMap[26],
        //        Coluna28 = arquivoToMap[27],
        //        Coluna29 = arquivoToMap[28],
        //        Coluna30 = arquivoToMap[29],
        //        Coluna31 = arquivoToMap[30],
        //        Coluna32 = arquivoToMap[31],
        //    });
        //}

        //private void MapType10(string[] arquivoToMap)
        //{
        //    listType10.Add(new AntecipacaoEASSESSORIA
        //    {
        //        Coluna1 = arquivoToMap[0],
        //        Coluna2 = arquivoToMap[1],
        //        Coluna3 = arquivoToMap[2],
        //        Coluna4 = arquivoToMap[3],
        //        Coluna5 = arquivoToMap[4],
        //        Coluna6 = arquivoToMap[5],
        //        Coluna7 = arquivoToMap[6],
        //        Coluna8 = arquivoToMap[7],
        //        Coluna9 = arquivoToMap[8],
        //        Coluna10 = arquivoToMap[9],
        //        Coluna11 = arquivoToMap[10],
        //        Coluna12 = arquivoToMap[11],
        //        Coluna13 = arquivoToMap[12],
        //        Coluna14 = arquivoToMap[13],
        //        Coluna15 = arquivoToMap[14],
        //        Coluna16 = arquivoToMap[15],
        //        Coluna17 = arquivoToMap[16],
        //        Coluna18 = arquivoToMap[17],
        //        Coluna19 = arquivoToMap[18],
        //    });
        //}

        //private void MapType96(string[] arquivoToMap)
        //{
        //    listType96.Add(new Type96
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        DescricaoDoEstabelecimento = arquivoToMap[1],
        //        CNPJDoEstabelecimento = arquivoToMap[2],
        //        NomeDaAdministradora = arquivoToMap[3],
        //        NomeDoGrupo = arquivoToMap[4],
        //        NumeroDoEstabelecimento = arquivoToMap[5],
        //        Filler = arquivoToMap[6],
        //        ValorTotalCreditado = arquivoToMap[7],
        //        NumeroDeParcelasCreditadas = arquivoToMap[8],
        //        NumeroDeComprovantesCreditados = arquivoToMap[9],
        //        NumeroDeResumosCreditados = arquivoToMap[10],
        //        ValorBrutoTotal = arquivoToMap[11],
        //    });
        //}

        //private void MapType98(string[] arquivoToMap)
        //{
        //    listType98.Add(new Type98
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDoGrupo = arquivoToMap[1],
        //        CNPJDoGrupo = arquivoToMap[2],
        //        NomeDaAdministradora = arquivoToMap[3],
        //        Filler = arquivoToMap[4],
        //        ValorTotalCreditado = arquivoToMap[5],
        //        NumeroTotalDeParcelas = arquivoToMap[6],
        //        NumeroTotalDeComprovantes = arquivoToMap[7],
        //        NumeroTotalDeResumos = arquivoToMap[8],
        //    });
        //}

        //private void MapType99(string[] arquivoToMap)
        //{
        //    listType99.Add(new Type99
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDoGrupo = arquivoToMap[1],
        //        CNPJDaMatrizDoGrupo = arquivoToMap[2],
        //        NumeroDeAdministradorasCreditadas = arquivoToMap[3],
        //        NumeroTotalDeRegistrosArquivo = arquivoToMap[4],
        //        ValorTotalCreditosArquivo = arquivoToMap[5],
        //    });
        //}

        //private void MapType12(string[] arquivoToMap)
        //{
        //    listType12.Add(new Type12 {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDaAdministradora = arquivoToMap[1],
        //        CNPJDoEstabelecimento = arquivoToMap[2],
        //        PDVAjustado = arquivoToMap[3],
        //        PDVOriginal = arquivoToMap[4],
        //        NumeroDoResumoAtual = arquivoToMap[5],
        //        NumeroDoResumoOriginal = arquivoToMap[6],
        //        NSUCV = arquivoToMap[7],
        //        CodigoDeAutorizacao = arquivoToMap[8],
        //        DataDaVenda = arquivoToMap[9],
        //        NumeroDaParcela = arquivoToMap[10],
        //        ValorDoAjuste = arquivoToMap[11],
        //        DataDoCreditoDaParcela = arquivoToMap[12],
        //        IdentificacaoDoValor = arquivoToMap[13],
        //        ValorBrutoDaParcelaAjuste = arquivoToMap[14],
        //        DescricaoDoMotivoDoAjuste = arquivoToMap[15],
        //        CodigoDeAjuste = arquivoToMap[16],
        //        NumeroDaNotaFiscal = arquivoToMap[17],
        //        TID = arquivoToMap[18],
        //        CodigoOriginalDeAjuste = arquivoToMap[19],
        //        IdDaOcorrencia = arquivoToMap[20],
        //        StatusDePagamentos = arquivoToMap[21],
        //        DataDeEnvioAoBanco = arquivoToMap[22],
        //        ValorLiquidoDoResumo = arquivoToMap[23],
        //        ValorDescontoDoResumo = arquivoToMap[24],
        //        CodigoDeCompensacaoDoBanco = arquivoToMap[25],
        //        AgenciaDeDepositoDoCredito = arquivoToMap[26],
        //        ContaDeDepositoDoCredito = arquivoToMap[27],
        //        CodigoAgrupadorBancarioDoComprovante = arquivoToMap[28],
        //        DataDoResumoDeAjuste = arquivoToMap[29],
        //        NumeroDoCartao = arquivoToMap[30],
        //        ValorTaxaDeServico = arquivoToMap[31],
        //        NumeroDoProcesso = arquivoToMap[32],
        //        NumeroDeReferencia = arquivoToMap[33],
        //        DataDeReferencia = arquivoToMap[34],
        //        TipoDeCaptura = arquivoToMap[35],
        //    });
        //}

        //private void MapType11(string[] arquivoToMap)
        //{
        //    listType11.Add(new Type11 {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDaAdministradora = arquivoToMap[1],
        //        CNPJDoEstabelecimento = arquivoToMap[2],
        //        PDV = arquivoToMap[3],
        //        NumeroDoResumo = arquivoToMap[4],
        //        NSUCV = arquivoToMap[5],
        //        CodigoDeAutorizacao = arquivoToMap[6],
        //        CodigoDeCompensacaoDoBanco = arquivoToMap[7],
        //        AgenciaDeDepositoDoCredito = arquivoToMap[8],
        //        ContaDeDepositoDoCredito = arquivoToMap[9],
        //        DataDaVenda = arquivoToMap[10],
        //        NumeroDaParcela = arquivoToMap[11],
        //        NumeroTotalDeParcelas = arquivoToMap[12],
        //        ValorLiquidoDaParcela = arquivoToMap[13],
        //        DataDoCreditoDaParcela = arquivoToMap[14],
        //        TipoDeRegistroTabelaII = arquivoToMap[15],
        //        Vazio = arquivoToMap[16],
        //        ValorBrutoDaParcela = arquivoToMap[17],
        //        Vazio1 = arquivoToMap[18],
        //        IndicacaoDeFinanceiroConciliacaoBancariaVenda = arquivoToMap[19],
        //        NumeroDaNotaFiscal = arquivoToMap[20],
        //        TID = arquivoToMap[21],
        //        BPAGID = arquivoToMap[22],
        //        Vazio2 = arquivoToMap[23],
        //        Vazio3 = arquivoToMap[24],
        //        NSUTEF = arquivoToMap[25],
        //        Vazio4 = arquivoToMap[26],
        //        Vazio5 = arquivoToMap[27],
        //        Vazio6 = arquivoToMap[28],
        //        NomeDaBandeira = arquivoToMap[29],
        //        CodigoAgrupadorBancarioDoComprovante = arquivoToMap[30],
        //        CodigoDeControleInterno = arquivoToMap[31],
        //    });
        //}

        //private void MapType10(string[] arquivoToMap)
        //{
        //    listType10.Add(new Type10
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDaAdministradora = arquivoToMap[1],
        //        CNPJDoEstabelecimento = arquivoToMap[2],
        //        PDVOperadora = arquivoToMap[3],
        //        NumeroDoResumo = arquivoToMap[4],
        //        DataDoVencimento = arquivoToMap[5],
        //        NumeroDaParcela = arquivoToMap[6],
        //        DataDoCreditoDaParcela = arquivoToMap[7],
        //        CodigoDeCompensacaoDoBanco = arquivoToMap[8],
        //        AgenciaDeDepositoDoCredito = arquivoToMap[9],
        //        ContaDeDepositoDoCredito = arquivoToMap[10],
        //        ValorInicialNegociadoParaAAntecipacao = arquivoToMap[11],
        //        ValorDescontoAntecipacaoDeRecebiveis = arquivoToMap[12],
        //        ValorLiquidoCreditado = arquivoToMap[13],
        //        CodigoDeAjuste = arquivoToMap[14],
        //        ValorCreditoLiquidoOriginal = arquivoToMap[15],
        //        DataDoResumoDeVenda = arquivoToMap[16],
        //        ValorBrutoDaParcelaDeResumo = arquivoToMap[17],
        //        ValorDescontoDaParcelaDeResumo = arquivoToMap[18]
        //    });
        //}

        //private void MapType04(string[] arquivoToMap)
        //{
        //    listType04.Add(new Type04
        //    {
        //        DescriçãoDoEstabelecimento = arquivoToMap[0],
        //        CNPJDoEstabelecimento = arquivoToMap[1],
        //        NomeDaAdministradora = arquivoToMap[2],
        //        NomeDoGrupo = arquivoToMap[3],
        //        NúmeroDoEstabelecimento = arquivoToMap[4],
        //    });
        //}

        //private void MapType02(string[] arquivoToMap)
        //{
        //    listType02.Add(new Type02
        //    {
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDoGrupo = arquivoToMap[1],
        //        CNPJDoGrupo = arquivoToMap[2],
        //        NomeDaAdministradora = arquivoToMap[3],
        //        CodigoDaAdministradora = arquivoToMap[4],
        //    });
        //}

        //private void MapType00(string[] arquivoToMap)
        //{
        //    listType00.Add(new Type00 { 
        //        TipoDeRegistro = arquivoToMap[0],
        //        NomeDoGrupo = arquivoToMap[1],
        //        CNPJDoGrupo = arquivoToMap[2],
        //        DataDeCredito = arquivoToMap[3],
        //        DataDeGeracao = arquivoToMap[4],
        //        HoraDeGeracao = arquivoToMap[5],
        //        NomeDaVan = arquivoToMap[6]
        //    });
        //}



        //private async Task SalvarListasNoBancoDeDados()
        //{
        //    await SalvarType00();
        //    await SalvarType02();
        //    await SalvarType04();
        //    await SalvarType10();
        //    await SalvarType11();
        //    await SalvarType12();
        //    await SalvarType96();
        //    await SalvarType98();
        //    await SalvarType99();
        //}

        //private async Task SalvarType99()
        //{
        //    foreach (var item in listType99)
        //        await _type99Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType98()
        //{
        //    foreach (var item in listType98)
        //        await _type98Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType96()
        //{
        //    foreach (var item in listType96)
        //        await _type96Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType12()
        //{
        //    foreach (var item in listType12)
        //        await _type12Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType11()
        //{
        //    foreach (var item in listType11)
        //        await _type11Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType10()
        //{
        //    foreach (var item in listType10)
        //        await _type10Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType04()
        //{
        //    foreach (var item in listType04)
        //        await _type04Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType02()
        //{
        //    foreach (var item in listType02)
        //        await _type02Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}

        //private async Task SalvarType00()
        //{
        //    foreach (var item in listType00)
        //        await _type00Repository.CreateAsync(item);

        //    await _unitOfWork.CommitAsync();
        //}
    }
}