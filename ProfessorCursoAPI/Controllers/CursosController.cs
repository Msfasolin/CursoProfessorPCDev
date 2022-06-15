using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessorCurso.Models;
using ProfessorCurso.Services;
using ProfessorCurso.ViewModel;

namespace ProfessorCurso.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private GestaoServices _servico = new GestaoServices();

        [HttpPost]
        public IActionResult CadastrarCurso(CursoViewModel cursoRecebido)
        {
            if (cursoRecebido == null)
            {
                return BadRequest("Por favor, informe o curso que deseja cadastrar.");
            }

            Curso cursoCadastrado = _servico.CadastrarCurso(cursoRecebido);

            return Created("cursos", cursoCadastrado); // 201
        }
    }
}
