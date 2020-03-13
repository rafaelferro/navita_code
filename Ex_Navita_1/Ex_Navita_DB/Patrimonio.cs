using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ex_Navita_DB
{
    public class Patrimonio
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tombo;

        public string Nome;
        public int Id_Marcald;
        public string Descricao;
        public bool ativo;
    }
}
