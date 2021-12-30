using Microsoft.AspNetCore.Mvc;

namespace AssessoriaCartoesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssessoriaController : ControllerBase
    {
        //private readonly ILerCSVService _lerCSVService;
        //private readonly INexxeraClient _nexxeraClient;

        public AssessoriaController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "De pé";
            //_nexxeraClient.Execute();
            //_lerCSVService.Executar();
        }
    }
}