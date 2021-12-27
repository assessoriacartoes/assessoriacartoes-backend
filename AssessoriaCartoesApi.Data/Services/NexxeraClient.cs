using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Services
{
    public class NexxeraClient : INexxeraClient
    {
        List<ConnectApi> CHAVES_APIS = new()
        { 
            new ConnectApi { CaixaPostal = "EASSESSORIA", ChaveApi = "RUFTU0VTU09SSUEuRUFTU0VTU09SSUE6ZWY4MGIxNmQtN2IyOC00MmUyLWE1MmEtNzlhOTMyZjc4NzJj==" },
            new ConnectApi { CaixaPostal = "G5SMART", ChaveApi =  "RzVTTUFSVC5HNVNNQVJUOjNkZGRlMGYyLTk1ZTgtNGQ4NS1iZWViLTE3OGQ1NmM1ZDNiNA==" }
        };

        List<string> teste = new();

        private readonly ILerCSVService _lerCSVService;

        public NexxeraClient(ILerCSVService lerCSVService)
        {
            _lerCSVService = lerCSVService;
        }

        public Task Execute()
        {
            foreach (var chave in CHAVES_APIS)
            {
                var arquivos = BuscarArquivosDisponiveis(DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy"), chave.ChaveApi);

                foreach (var arquivo in arquivos.Result)
                {
                    var arquivoToProccess = new List<string>();

                    var arquivoToDownload = ColocarArquivosParaDownload(arquivo, chave.ChaveApi);

                    if (arquivoToDownload != default)
                    {
                        arquivoToProccess = Download(arquivoToDownload);
                        if (arquivoToProccess != default && arquivoToProccess.Any())
                            _lerCSVService.Executar(arquivoToProccess, chave.CaixaPostal);
                    }
                }
            }

            return Task.CompletedTask;
        }

        public ResultRequest BuscarArquivosDisponiveis(string dataInicio, string dataFim, string chaveApi)
        {
            try
            {
                var url = "https://api.nexxera.com/skyline/api/v1/files?final_date=" + dataFim + "&initial_date=" + dataInicio;
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Headers["service-token"] = chaveApi;
                httpRequest.Accept = "application/json";


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ResultRequest>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ArquivoDownload ColocarArquivosParaDownload(Arquivos arquivo, string chaveApi)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create("https://api.nexxera.com/skyline/api/v1/requests/download");

                httpRequest.Method = "POST";

                httpRequest.Headers["service-token"] = chaveApi;
                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";

                var data = "{ \"filename\": \"" + arquivo.Filename + "\"}";

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<ArquivoDownload>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> Download(ArquivoDownload arquivo)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(arquivo.Url);

                teste.Add(arquivo.Method);

                httpRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var teste = streamReader.ReadToEnd();
                    var gg = teste.Split("\n");
                    return gg.Where(e => !string.IsNullOrEmpty(e)).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
                //throw ex;
            }
        }
    }

    public class ArquivoDownload
    {
        public int Expires { get; set; }
        public int Limit { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
    }

    public class Arquivos
    {
        [JsonProperty("date_time")]
        public string DateTime { get; set; }
        [JsonProperty("filename")]
        public string Filename { get; set; }
        [JsonProperty("in_mailbox")]
        public bool InMailbox { get; set; }
        [JsonProperty("sender")]
        public string Sender { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }

    public class ResultRequest
    {
        [JsonProperty("result")]
        public List<Arquivos> Result { get; set; }
    }

    public class ConnectApi
    {
        public string CaixaPostal { get; set; }
        public string ChaveApi { get; set; }
    }
}