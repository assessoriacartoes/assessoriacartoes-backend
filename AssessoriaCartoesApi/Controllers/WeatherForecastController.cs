using AssessoriaCartoesApi.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssessoriaCartoesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILerCSVService _lerCSVService;
        //private readonly INexxeraClient _nexxeraClient;

        public WeatherForecastController(ILerCSVService lerCSVService)
        {
            _lerCSVService = lerCSVService;
        }

        [HttpGet]
        public void Get()
        {
         //   _nexxeraClient.Execute();
            //_lerCSVService.Executar();
        }
    }
}