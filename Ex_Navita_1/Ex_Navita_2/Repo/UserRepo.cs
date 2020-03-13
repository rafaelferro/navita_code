using Ex_Navita_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_Navita_2.Repo
{
    public class UserRepo
    {

        public static Usuario getUser(Usuario u)
        {

            var users = new List<Usuario>();
            users.Add(new Usuario { id = 1, email = "teste@teste", nome = "teste", senha = "teste" });
            users.Add(new Usuario { id = 2, email = "teste1@teste", nome = "teste1", senha = "teste" });
            users.Add(new Usuario { id = 3, email = "teste2@teste", nome = "teste2", senha = "teste" });

            return users.FirstOrDefault(a => a.email == u.email && a.senha == u.senha);


        }

    }
}
