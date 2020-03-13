using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_Navita_DB
{
    public class Context: DbContext
    {
      
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Patrimonio> Patrimonio { get; set; }
    }
}
