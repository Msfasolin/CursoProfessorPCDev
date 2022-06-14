using ProfessorCurso.Models;
using Microsoft.AspNetCore.Mvc;
using ProfessorCurso.Services;
using System.Collections.Generic;

namespace ProfessorCurso.API.Controllers
{
    [ApiController]
    [Route("biblioteca")]
    public class BibliotecaController : ControllerBase
    {
        private GestaoServices _servico = new GestaoServices();

        [HttpGet]
        public IActionResult ObterBiblioteca()
        {
            List<object> itens = _servico.ListarItens();

            return Ok(itens);
        }
    }
}
