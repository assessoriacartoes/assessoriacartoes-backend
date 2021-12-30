using AssessoriaCartoesApi.Data.Entities;
using AssessoriaCartoesApi.Data.Repositorios.Base;
using AssessoriaCartoesApi.Data.Repositorios.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AssessoriaCartoesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteController(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<Cliente> SalvarCliente(Cliente cliente)
        {
            cliente.TipoDeUsuario = TipoDeUsuarioEnum.CLIENTE;
            var clienteSaved = await _clienteRepository.CreateAsync(cliente);
            await _unitOfWork.CommitAsync();

            return clienteSaved;
        }

        [HttpPost("UploadLogo/{id}")]
        public async Task<Cliente> Upload(IFormFile arquivo, int id)
        {
            try
            {
                if (arquivo == null || arquivo.Length == 0)
                    throw new Exception("Arquivo não foi selecionado.");

                FileInfo fi = new FileInfo(arquivo.FileName);

                ////MAIOR QUE 10MB
                if (arquivo.Length > 10485760)
                    throw new Exception("Arquivo não pode ser maior que 10MB");

                if (!".png.jpg.jpeg.pdf".Contains(fi.Extension))
                    throw new Exception("Extensão de arquivo não suportada");

                var entity = await _clienteRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new Exception("Informação Documentada não encontrada");
                
                if (arquivo != null)
                {
                    if (arquivo.Length > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = arquivo.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                     
                        entity.Img = p1;
                    }
                }

                await _clienteRepository.UpdateAsync(entity, id);
                await _unitOfWork.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}