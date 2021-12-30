using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Data.Services
{
    public interface ILerCSVService
    {
        Task Executar(List<string> dados, string filename, string caixaPostal);
    }
}