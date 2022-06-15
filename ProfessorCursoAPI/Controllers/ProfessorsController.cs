using ProfessorCurso.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessorCurso.Models;
using ProfessorCurso.Services;
using ProfessorCurso.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProfessorCurso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private ProfessorServices _professorServices =
            new ProfessorServices();

        [HttpPost]
        public ActionResult CadastrarProfessor(
            [FromBody] ProfessorViewModel professorRecebido)
        {
            if (professorRecebido == null)
            {
                return BadRequest("Não foi recebido nenhum professor.");
            }

            if (string.IsNullOrEmpty(professorRecebido.NomeProfessor))
            {
                return BadRequest("Nome do professor não foi informado. 🥲");
            }


            Professor objetoCriado = _professorServices
                .CadastrarProfessor(professorRecebido);

            return Created("professors", objetoCriado);
        }

        [HttpGet]
        public List<Professor> ListarClientes()
        {
            List<Professor> listaCliente =
                _professorServices.ListarProfessors();
            return listaCliente;
        }

        [HttpGet("{id}")] //CONTROLADORA
        public IActionResult ObterCliente(string id)
        {
            Professor cliente = _professorServices.ObterCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);

        }
    }
}
