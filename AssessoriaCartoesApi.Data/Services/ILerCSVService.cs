using System.Collections.Generic;

namespace AssessoriaCartoesApi.Data.Services
{
    public interface ILerCSVService
    {
        void Executar(List<string> dados, string caixaPostal);
    }
}