using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_Navita_DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex_Navita_2.Controllers
{

    [Route("api/patrimonio")]
    public class PatrimonioController : Controller
    {

        Context context = new Context();
        private string msgErPat = "Patrimonio não encontrado";

        [HttpPost("NewPatrimonio")]
        [Authorize]
        public IActionResult NewPatrimonio(Patrimonio patrimonio)
        {
            Patrimonio p;
            if (!verificaPatrimonio(patrimonio, out p))
            {
                p = new Patrimonio();
                p.Nome = patrimonio.Nome;
                p.Descricao = patrimonio.Descricao;
                p.Id_Marcald = patrimonio.Id_Marcald;
                p.ativo = true;
                context.Add(p);
                context.SaveChanges();

            }
            else
            {
                return NotFound("Esse patrimonio já existe");
            }

            return Ok(p);
        }

        [HttpGet("GetPatrimonio")]
        [Authorize]
        public IActionResult GetPatrimonio(int Tombo)
        {
            Patrimonio p;

            p = context.Patrimonio.FirstOrDefault(a => a.Tombo == Tombo);

            if (p == null)
                return NotFound("Esse patrimonio não existe");


            return Ok(p);
        }

        [HttpGet("GetPatrimonios")]
        [Authorize]
        public IActionResult GetPatrimonios(bool ativo)
        {
            List<Patrimonio> p = new List<Patrimonio>() ;

            p = context.Patrimonio.Where(a => a.ativo == ativo).ToList();

            if (p.Count == 0)
                return NotFound("Não existem patrimonios para serem listados");


            return Ok(p);
        }

        [HttpPost("UpdatePatrimonio")]
        [Authorize]
        public IActionResult UpdatePatrimonio(Patrimonio patrimonio)
        {
            Patrimonio p;

            if (!verificaPatrimonio(patrimonio, out p))
                return NotFound(msgErPat);

            p.Descricao = patrimonio.Descricao;
            p.Id_Marcald = patrimonio.Id_Marcald;
            p.Nome = patrimonio.Nome;
            p.ativo = patrimonio.ativo;

            context.SaveChanges();

            return Ok();
        }

        [HttpPost("DesativaPatrimonio")]
        [Authorize]
        public IActionResult DesativaPatrimonio(Patrimonio patrimonio)
        {
            Patrimonio p;

            if (!verificaPatrimonio(patrimonio, out p))
                return NotFound(msgErPat);

            p.ativo = false;
            context.SaveChanges();


            return Ok();
        }

        private bool verificaPatrimonio(Patrimonio patrimonio, out Patrimonio p)
        {

            p = context.Patrimonio.FirstOrDefault(a => a.Tombo == patrimonio.Tombo);

            if (p == null)
                return false;

            return true;
        }


    }
}