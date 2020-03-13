using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_Navita_2.Service;
using Ex_Navita_DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex_Navita_2.Controllers
{

    [Route("api/usuario")]
    public class UsuarioController : Controller
    {

        Context context = new Context();

        [HttpPost("login")]
        public IActionResult login([FromBody]Usuario model)
        {
            var usuario = Repo.UserRepo.getUser(model);
            if (usuario == null)
                return NotFound("Usuario não encontrado");
            var token = JwtClass.token(usuario);
            usuario.senha = "";

            return Ok(new { usuario, token });
        }      


        [HttpPost("NewUser")]
        public IActionResult NewUser(Usuario usuario)
        {
            Usuario u;

            if (string.IsNullOrEmpty(usuario.email))
            {
                if (string.IsNullOrEmpty(usuario.nome) || string.IsNullOrEmpty(usuario.senha))
                    return NotFound("Nome ou Senha não podem ser nulos");

                u = context.Usuario.FirstOrDefault(a => a.email == usuario.email);
            }
            else
            {
                return NotFound("Email não pode ser nulo");
            }


            if (u != null)
            {
                return NotFound("Email Já cadastrado");
            }
            else
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }

            return Ok(u);
        }
      

        [HttpGet("getUser")]
        [Authorize(Roles = "teste@teste")]
        public IActionResult getUser(int id)
        {
            Usuario u;

            u = context.Usuario.FirstOrDefault(a => a.id == id);

            if (u == null)
                return NotFound("Usuario não exite");

            u.senha = "";
                       
            return Ok(u);
        }

        [HttpPost("updatePassUser")]
        [Authorize]
        public IActionResult updatePassUser(string email, string senhaAtual, string senhaNova)
        {
            Usuario u;

            u = context.Usuario.FirstOrDefault(a => a.email == email);

            if (u != null && u.senha == senhaAtual)
            {
                u.senha = senhaNova;
                context.SaveChanges();
            }

            return Ok("Senha alterada");
        }

        

        [HttpPost("updateName")]
        [Authorize]
        public IActionResult updateName(string email, string novoNome)
        {
            Usuario u;

            u = context.Usuario.FirstOrDefault(a => a.email == email);

            if (u != null)
            {
                u.nome = novoNome;
                context.SaveChanges();
            }
            else
            {
                return NotFound("Usuario  não existe");
            }

            return Ok("Nome alterado com sucesso");
        }


    }
}