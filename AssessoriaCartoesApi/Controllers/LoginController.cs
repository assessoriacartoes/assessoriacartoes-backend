using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public LoginController(IClienteRepository clienteRepository = null)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<Cliente> Login(string email, string senha)
        {
            var cliente = await _clienteRepository.GetByEmailSenha(email, senha);

            if (cliente == default)
                throw new Exception("Usuário ou Senha incorretos");

            return cliente;
        }
    }
}