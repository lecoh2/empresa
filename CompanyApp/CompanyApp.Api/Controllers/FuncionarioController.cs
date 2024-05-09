
using CompanyApp.Api.Models.Funcionario;
using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //atributos
        private readonly IFuncionarioDomainService _funcionarioDomainService;
        //construtor para injeção de dependencia                                
        public FuncionarioController(IFuncionarioDomainService funcionarioDomainService)
        {
            _funcionarioDomainService = funcionarioDomainService;
        }
        [HttpPost("criar")]
        public IActionResult Criar(CriarFuncionarioRequestModel model)
        {
            try
            {
        
                var funcionario = new Funcionario
                {
                        
                    IdFuncionario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Matricula = model.Matricula,
                    Cpf = model.Cpf,                  
                    DataAdmissao = model.DataAdmissao,
                    DataHoraCadastro = DateTime.Now,
                    IdEmpresa = model.IdEmpresa


            };
                _funcionarioDomainService.CadastrarFuncioario(funcionario);
                var response = new CriarFuncionarioResponseModel
                {
                    IdFuncionario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Matricula = model.Matricula,
                    Cpf = model.Cpf,
                    DataAdmissao = model.DataAdmissao,
                    DataHoraCadastro = DateTime.Now,
                    IdEmpresa = model.IdEmpresa
                };
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
      //  [ProducesResponseType(typeof(List<ConsultarFuncionarioResponseModel>), 200)]
        public IActionResult Consultar()
        {
            try
            {
                var funcionario = _funcionarioDomainService.ConsultarFuncionario();
                var response = new List<ConsultarFuncionarioResponseModel>();
               /// var cempresa = new ConsultarEmpresaResponseModel();
                foreach (var item in funcionario)
                {
                    response.Add(new ConsultarFuncionarioResponseModel
                    {
                        IdFuncionario = item.IdFuncionario,
                        Nome = item.Nome,
                        Cpf = item.Cpf,
                        DataAdmissao = item.DataAdmissao,
                        Matricula=item.Matricula,
                        DataHoraCadastro = item.DataHoraCadastro,                       
                        IdEmpresa = item.IdEmpresa,
                        NomeFantasia=item.Empresa.NomeFantasia,
                        RasaoSocial = item.Empresa.RasaoSocial,
                        Cnpj = item.Empresa.Cnpj
                    });
                }
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });

            }

        }

        [HttpPut("Editar")]
        public IActionResult Atualizar(AtualizarFuncionarioModel model)
        {
            try
            {
                // var empresaRepository = new EmpresaRepository();
                //  var empresa = empresaRepository.GetById(model.IdEmpresa)
                var funcionario = new Funcionario
                {

                    IdFuncionario = model.IdFuncionario,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Matricula = model.Matricula,
                    DataAdmissao = model.DataAdmissao,
                    DataHoraCadastro = DateTime.Now,
                    //IdEmpresa = model.IdEmpresa,

                };
                _funcionarioDomainService.AtualizarFuncionario(funcionario);
                return StatusCode(201, new { Mensagem = "Funcionario atualizado" });

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
                var funcionario = _funcionarioDomainService.ObterPorId(id);
                _funcionarioDomainService.ExcluirFuncionario(funcionario);
                return StatusCode(201, new { Messagem = "Funcionario excluido" });
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
                var funcionario = _funcionarioDomainService.ObterPorId(id);
                if (funcionario == null)
                    return NoContent();
          
       
                var response = new ConsultarFuncionarioResponseModel
                {

                    IdFuncionario = funcionario.IdFuncionario,
                    Nome=funcionario.Nome,
                    Cpf = funcionario.Cpf,
                    Matricula = funcionario.Matricula,
                    DTAdmissao = Convert.ToDateTime(funcionario.DataAdmissao).ToString("dd/MM/yyyy"),
                    DataAdmissao = funcionario.DataAdmissao,
                    DataHoraCadastro = funcionario.DataHoraCadastro,
                    IdEmpresa = funcionario.IdEmpresa,
                    NomeFantasia=funcionario.Empresa.NomeFantasia,
                    RasaoSocial=funcionario.Empresa.RasaoSocial,
                    Cnpj=funcionario.Empresa.Cnpj
                };

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });

            }

        }

    }
}
