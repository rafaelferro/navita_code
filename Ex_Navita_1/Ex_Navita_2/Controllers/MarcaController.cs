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

    [Route("api/marca")]
    public class MarcaController : Controller
    {
        Context context = new Context();
        string erroNExi = "Marca não existe";


        [HttpPost("NewMarca")]
        [Authorize]
        public IActionResult NewMarca(Marca marca)
        {

            Marca m;

            if (!verificaMarca(marca, out m))
            {
                m = new Marca();
                m.nome = marca.nome;
                m.marcald = marca.marcald;
                context.Add(m);
                context.SaveChanges();
            }
            else
            {

                return NotFound("Marca já existe");

            }



            return Ok(m);
        }

        [HttpGet("GetMarca")]
        [Authorize]
        public IActionResult GetMarca(Marca marca)
        {

            Marca m;



            if (!verificaMarca(marca, out m))
                return NotFound(erroNExi);


                return Ok(m);
        }


        [HttpGet("GetMarcas")]
        [Authorize]
        public IActionResult GetMarcas( bool ativo)
        {
            List<Marca> Marcas = new List<Marca>();
            Marcas = context.Marca.Where(a => a.ativo == ativo).ToList();

            if (Marcas.Count == 0)
                return NotFound("Não existem marcas para serem listadas");


            return Ok(Marcas);
        }

        [HttpPost("UpdateMarca")]
        [Authorize]
        public IActionResult UpdateMarca(Marca marca)
        {
            Marca m;

            if (!verificaMarca(marca,out m))
                return NotFound(erroNExi);

            m.marcald = marca.marcald;
            m.ativo = marca.ativo;
            context.SaveChanges();

            return Ok();
        }

        [HttpPost("DesativaeMarca")]
        [Authorize]
        public IActionResult DesativaeMarca(Marca marca)
        {

            Marca m;

            if (!verificaMarca(marca, out m))
                return NotFound(erroNExi);

            m.ativo = false;
            context.SaveChanges();

            return Ok();
        }

        private bool verificaMarca(Marca marca, out Marca marcas)
        {
            
            marcas = context.Marca.FirstOrDefault(a => a.nome == marca.nome);

            if (marcas == null)
                return false;


            return true;
        }


    }
}