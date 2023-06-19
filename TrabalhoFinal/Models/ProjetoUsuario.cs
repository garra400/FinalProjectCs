using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;

namespace TrabalhoFinal.Models

{
    public class ProjetoUsuario
    {
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public bool IsGerente { get; set; }
    }
}