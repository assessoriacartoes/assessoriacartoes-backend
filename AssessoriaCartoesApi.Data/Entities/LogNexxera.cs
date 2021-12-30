using System;

namespace AssessoriaCartoesApi.Data.Entities
{
    public class LogNexxera : Entity
    {
        public string Filename { get; set; }
        public string Exception { get; set; }
        public string Method { get; set; }
        public string InnerException { get; set; }
        public int QuantidadeColunas { get; set; }
        public DateTime CreateDate { get; set; }
    }
}