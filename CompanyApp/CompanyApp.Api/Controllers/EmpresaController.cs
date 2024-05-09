
using CompanyApp.Api.Models;
using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        //atributos
        private readonly IEmpresaDomainService _empresaDomainService;
        //construtor para injeção de dependencia                                
        public EmpresaController(IEmpresaDomainService empresaDomainService)
        {
            _empresaDomainService = empresaDomainService;
        }
        [HttpGet]
        public IActionResult Consultar()
        {
            try
            {
                var empresa = _empresaDomainService.ConsultarEmpresas();
                var response = new List<ConsultarEmpresaResponseModel>();
                foreach(var item in empresa)
                {
                    response.Add(new ConsultarEmpresaResponseModel
                    {
                        IdEmpresa=item.IdEmpresa,
                        NomeFantasia=item.NomeFantasia,
                        RasaoSocial=item.RasaoSocial,
                        Cnpj=item.Cnpj,
                        DataHoraCadastro=item.DataHoraCadastro
                    });
                }
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });

            }

        }
        [HttpGet("consultar/{id}")]
        public IActionResult Consultar(Guid id)
        {
            try
            {
                var empresa = _empresaDomainService.ObterPorId(id);
                if (empresa == null)
                    return NoContent();
              
                    var response = new ConsultarEmpresaResponseModel
                    {
                        IdEmpresa = empresa.IdEmpresa,
                        NomeFantasia = empresa.NomeFantasia,
                        RasaoSocial = empresa.RasaoSocial,
                        Cnpj = empresa.Cnpj,
                        DataHoraCadastro = empresa.DataHoraCadastro
                    };
                
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });

            }

        }

        [HttpPost("criar")]
        public IActionResult Criar(CriarEmpresaRequestModel model)
        {
            try
            {
                var empresa = new Empresa
                {
                    IdEmpresa = Guid.NewGuid(),
                    NomeFantasia = model.NomeFantasia,
                    RasaoSocial = model.RasaoSocial,
                    Cnpj = model.Cnpj,
                    DataHoraCadastro = DateTime.Now
                };
                _empresaDomainService.CadastrarEmpresa(empresa);
                var response = new CriarEmpresaResponseModel
                {
                    IdEmpresa = Guid.NewGuid(),
                    NomeFantasia = model.NomeFantasia,
                    RasaoSocial = model.RasaoSocial,
                    Cnpj = model.Cnpj,
                    DataHoraCadastro = DateTime.Now
                };
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }

        }

        [HttpPut("Editar")]
        public IActionResult Atualizar(AtualizarEmpresaModel model)
        {
            try
            {
               // var empresaRepository = new EmpresaRepository();
              //  var empresa = empresaRepository.GetById(model.IdEmpresa)
                var empresa = new Empresa
                {

                    IdEmpresa = model.IdEmpresa,
                    NomeFantasia = model.NomeFantasia,
                    RasaoSocial = model.NomeFantasia,
                    Cnpj = model.Cnpj
                };
                    _empresaDomainService.AtualizarEmpresa(empresa);
                    return StatusCode(201, new { Mensagem = "Contato atualizado" });
                
            }
                
            
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });

            }
           
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(Guid id)
        {
            try
            {
                var empresa = _empresaDomainService.ObterPorId(id);
                _empresaDomainService.ExcluirEmpresa(empresa);
                return StatusCode(201, new { Messagem = "Contato excluido" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
