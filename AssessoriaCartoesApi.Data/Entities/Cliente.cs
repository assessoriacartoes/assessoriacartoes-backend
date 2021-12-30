namespace AssessoriaCartoesApi.Data.Entities
{
    public class Cliente : Entity
    {
        public TipoDeUsuarioEnum TipoDeUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PowerBi { get; set; }
        public string Conciliador { get; set; }
        public string ExtensaoLogo { get; set; }
        public string NomeArquivoLogo { get; set; }
        public byte[] Img { get; set; }
    }
}