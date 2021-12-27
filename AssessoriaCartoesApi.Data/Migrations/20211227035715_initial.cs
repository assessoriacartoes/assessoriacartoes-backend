using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AssessoriaCartoesApi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjusteEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDVAjustado = table.Column<string>(type: "text", nullable: true),
                    PDVOriginal = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumoAtual = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumoOriginal = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    ValorDoAjuste = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    IdentificacaoDoValor = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcelaAjuste = table.Column<string>(type: "text", nullable: true),
                    DescricaoDoMotivoDoAjuste = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    CodigoOriginalDeAjuste = table.Column<string>(type: "text", nullable: true),
                    IdDaOcorrencia = table.Column<string>(type: "text", nullable: true),
                    StatusDePagamentos = table.Column<string>(type: "text", nullable: true),
                    DataDeEnvioAoBanco = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDoResumo = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoDoResumo = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    DataDoResumoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    NumeroDoCartao = table.Column<string>(type: "text", nullable: true),
                    ValorTaxaDeServico = table.Column<string>(type: "text", nullable: true),
                    NumeroDoProcesso = table.Column<string>(type: "text", nullable: true),
                    NumeroDeReferencia = table.Column<string>(type: "text", nullable: true),
                    DataDeReferencia = table.Column<string>(type: "text", nullable: true),
                    TipoDeCaptura = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AjusteG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDVAjustado = table.Column<string>(type: "text", nullable: true),
                    PDVOriginal = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumoAtual = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumoOriginal = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    ValorDoAjuste = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    IdentificacaoDoValor = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcelaAjuste = table.Column<string>(type: "text", nullable: true),
                    DescricaoDoMotivoDoAjuste = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    CodigoOriginalDeAjuste = table.Column<string>(type: "text", nullable: true),
                    IdDaOcorrencia = table.Column<string>(type: "text", nullable: true),
                    StatusDePagamentos = table.Column<string>(type: "text", nullable: true),
                    DataDeEnvioAoBanco = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDoResumo = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoDoResumo = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    DataDoResumoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    NumeroDoCartao = table.Column<string>(type: "text", nullable: true),
                    ValorTaxaDeServico = table.Column<string>(type: "text", nullable: true),
                    NumeroDoProcesso = table.Column<string>(type: "text", nullable: true),
                    NumeroDeReferencia = table.Column<string>(type: "text", nullable: true),
                    DataDeReferencia = table.Column<string>(type: "text", nullable: true),
                    TipoDeCaptura = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteG5SMART", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecipacaoEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDVOperadora = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    DataDoVencimento = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ValorInicialNegociadoParaAAntecipacao = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoAntecipacaoDeRecebiveis = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoCreditado = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    ValorCreditoLiquidoOriginal = table.Column<string>(type: "text", nullable: true),
                    DataDoResumoDeVenda = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcelaDeResumo = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoDaParcelaDeResumo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecipacaoEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntecipacaoG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDVOperadora = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    DataDoVencimento = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ValorInicialNegociadoParaAAntecipacao = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoAntecipacaoDeRecebiveis = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoCreditado = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAjuste = table.Column<string>(type: "text", nullable: true),
                    ValorCreditoLiquidoOriginal = table.Column<string>(type: "text", nullable: true),
                    DataDoResumoDeVenda = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcelaDeResumo = table.Column<string>(type: "text", nullable: true),
                    ValorDescontoDaParcelaDeResumo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecipacaoG5SMART", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceiraSemVendaEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Coluna1 = table.Column<string>(type: "text", nullable: true),
                    Coluna2 = table.Column<string>(type: "text", nullable: true),
                    Coluna3 = table.Column<string>(type: "text", nullable: true),
                    Coluna4 = table.Column<string>(type: "text", nullable: true),
                    Coluna5 = table.Column<string>(type: "text", nullable: true),
                    Coluna6 = table.Column<string>(type: "text", nullable: true),
                    Coluna7 = table.Column<string>(type: "text", nullable: true),
                    Coluna8 = table.Column<string>(type: "text", nullable: true),
                    Coluna9 = table.Column<string>(type: "text", nullable: true),
                    Coluna10 = table.Column<string>(type: "text", nullable: true),
                    Coluna11 = table.Column<string>(type: "text", nullable: true),
                    Coluna12 = table.Column<string>(type: "text", nullable: true),
                    Coluna13 = table.Column<string>(type: "text", nullable: true),
                    Coluna14 = table.Column<string>(type: "text", nullable: true),
                    Coluna15 = table.Column<string>(type: "text", nullable: true),
                    Coluna16 = table.Column<string>(type: "text", nullable: true),
                    Coluna17 = table.Column<string>(type: "text", nullable: true),
                    Coluna18 = table.Column<string>(type: "text", nullable: true),
                    Coluna19 = table.Column<string>(type: "text", nullable: true),
                    Coluna20 = table.Column<string>(type: "text", nullable: true),
                    Coluna21 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceiraSemVendaEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceiraSemVendaG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Coluna1 = table.Column<string>(type: "text", nullable: true),
                    Coluna2 = table.Column<string>(type: "text", nullable: true),
                    Coluna3 = table.Column<string>(type: "text", nullable: true),
                    Coluna4 = table.Column<string>(type: "text", nullable: true),
                    Coluna5 = table.Column<string>(type: "text", nullable: true),
                    Coluna6 = table.Column<string>(type: "text", nullable: true),
                    Coluna7 = table.Column<string>(type: "text", nullable: true),
                    Coluna8 = table.Column<string>(type: "text", nullable: true),
                    Coluna9 = table.Column<string>(type: "text", nullable: true),
                    Coluna10 = table.Column<string>(type: "text", nullable: true),
                    Coluna11 = table.Column<string>(type: "text", nullable: true),
                    Coluna12 = table.Column<string>(type: "text", nullable: true),
                    Coluna13 = table.Column<string>(type: "text", nullable: true),
                    Coluna14 = table.Column<string>(type: "text", nullable: true),
                    Coluna15 = table.Column<string>(type: "text", nullable: true),
                    Coluna16 = table.Column<string>(type: "text", nullable: true),
                    Coluna17 = table.Column<string>(type: "text", nullable: true),
                    Coluna18 = table.Column<string>(type: "text", nullable: true),
                    Coluna19 = table.Column<string>(type: "text", nullable: true),
                    Coluna20 = table.Column<string>(type: "text", nullable: true),
                    Coluna21 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceiraSemVendaG5SMART", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceiroEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDV = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    NumeroTotalDeParcelas = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    TipoDeRegistroTabelaII = table.Column<string>(type: "text", nullable: true),
                    Vazio = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcela = table.Column<string>(type: "text", nullable: true),
                    Vazio1 = table.Column<string>(type: "text", nullable: true),
                    IndicacaoDeFinanceiroConciliacaoBancariaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    BPAGID = table.Column<string>(type: "text", nullable: true),
                    Vazio2 = table.Column<string>(type: "text", nullable: true),
                    Vazio3 = table.Column<string>(type: "text", nullable: true),
                    NSUTEF = table.Column<string>(type: "text", nullable: true),
                    Vazio4 = table.Column<string>(type: "text", nullable: true),
                    Vazio5 = table.Column<string>(type: "text", nullable: true),
                    Vazio6 = table.Column<string>(type: "text", nullable: true),
                    NomeDaBandeira = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    CodigoDeControleInterno = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceiroEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceiroG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDV = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    NumeroTotalDeParcelas = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    TipoDeRegistroTabelaII = table.Column<string>(type: "text", nullable: true),
                    Vazio = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcela = table.Column<string>(type: "text", nullable: true),
                    Vazio1 = table.Column<string>(type: "text", nullable: true),
                    IndicacaoDeFinanceiroConciliacaoBancariaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    BPAGID = table.Column<string>(type: "text", nullable: true),
                    Vazio2 = table.Column<string>(type: "text", nullable: true),
                    Vazio3 = table.Column<string>(type: "text", nullable: true),
                    NSUTEF = table.Column<string>(type: "text", nullable: true),
                    Vazio4 = table.Column<string>(type: "text", nullable: true),
                    Vazio5 = table.Column<string>(type: "text", nullable: true),
                    Vazio6 = table.Column<string>(type: "text", nullable: true),
                    NomeDaBandeira = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    CodigoDeControleInterno = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceiroG5SMART", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoG5SMART", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendaEASSESSORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDV = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    NumeroTotalDeParcelas = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    TipoDeRegistroTabelaII = table.Column<string>(type: "text", nullable: true),
                    Vazio = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcela = table.Column<string>(type: "text", nullable: true),
                    Vazio1 = table.Column<string>(type: "text", nullable: true),
                    IndicacaoDeFinanceiroConciliacaoBancariaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    BPAGID = table.Column<string>(type: "text", nullable: true),
                    Vazio2 = table.Column<string>(type: "text", nullable: true),
                    Vazio3 = table.Column<string>(type: "text", nullable: true),
                    NSUTEF = table.Column<string>(type: "text", nullable: true),
                    Vazio4 = table.Column<string>(type: "text", nullable: true),
                    Vazio5 = table.Column<string>(type: "text", nullable: true),
                    Vazio6 = table.Column<string>(type: "text", nullable: true),
                    NomeDaBandeira = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    CodigoDeControleInterno = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaEASSESSORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendaG5SMART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDeRegistro = table.Column<string>(type: "text", nullable: true),
                    NomeDaAdministradora = table.Column<string>(type: "text", nullable: true),
                    CNPJDoEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    PDV = table.Column<string>(type: "text", nullable: true),
                    NumeroDoResumo = table.Column<string>(type: "text", nullable: true),
                    NSUCV = table.Column<string>(type: "text", nullable: true),
                    CodigoDeAutorizacao = table.Column<string>(type: "text", nullable: true),
                    CodigoDeCompensacaoDoBanco = table.Column<string>(type: "text", nullable: true),
                    AgenciaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    ContaDeDepositoDoCredito = table.Column<string>(type: "text", nullable: true),
                    DataDaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaParcela = table.Column<string>(type: "text", nullable: true),
                    NumeroTotalDeParcelas = table.Column<string>(type: "text", nullable: true),
                    ValorLiquidoDaParcela = table.Column<string>(type: "text", nullable: true),
                    DataDoCreditoDaParcela = table.Column<string>(type: "text", nullable: true),
                    TipoDeRegistroTabelaII = table.Column<string>(type: "text", nullable: true),
                    Vazio = table.Column<string>(type: "text", nullable: true),
                    ValorBrutoDaParcela = table.Column<string>(type: "text", nullable: true),
                    Vazio1 = table.Column<string>(type: "text", nullable: true),
                    IndicacaoDeFinanceiroConciliacaoBancariaVenda = table.Column<string>(type: "text", nullable: true),
                    NumeroDaNotaFiscal = table.Column<string>(type: "text", nullable: true),
                    TID = table.Column<string>(type: "text", nullable: true),
                    BPAGID = table.Column<string>(type: "text", nullable: true),
                    Vazio2 = table.Column<string>(type: "text", nullable: true),
                    Vazio3 = table.Column<string>(type: "text", nullable: true),
                    NSUTEF = table.Column<string>(type: "text", nullable: true),
                    Vazio4 = table.Column<string>(type: "text", nullable: true),
                    Vazio5 = table.Column<string>(type: "text", nullable: true),
                    Vazio6 = table.Column<string>(type: "text", nullable: true),
                    NomeDaBandeira = table.Column<string>(type: "text", nullable: true),
                    CodigoAgrupadorBancarioDoComprovante = table.Column<string>(type: "text", nullable: true),
                    CodigoDeControleInterno = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaG5SMART", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteEASSESSORIA");

            migrationBuilder.DropTable(
                name: "AjusteG5SMART");

            migrationBuilder.DropTable(
                name: "AntecipacaoEASSESSORIA");

            migrationBuilder.DropTable(
                name: "AntecipacaoG5SMART");

            migrationBuilder.DropTable(
                name: "FinanceiraSemVendaEASSESSORIA");

            migrationBuilder.DropTable(
                name: "FinanceiraSemVendaG5SMART");

            migrationBuilder.DropTable(
                name: "FinanceiroEASSESSORIA");

            migrationBuilder.DropTable(
                name: "FinanceiroG5SMART");

            migrationBuilder.DropTable(
                name: "TransacaoEASSESSORIA");

            migrationBuilder.DropTable(
                name: "TransacaoG5SMART");

            migrationBuilder.DropTable(
                name: "VendaEASSESSORIA");

            migrationBuilder.DropTable(
                name: "VendaG5SMART");
        }
    }
}
