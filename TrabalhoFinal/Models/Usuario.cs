using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;

namespace TrabalhoFinal.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<ProjetoUsuario> ProjetosUsuarios { get; set; }
        public List<TarefaUsuario> TarefasUsuarios { get; set; }
        public Usuario()
        {
            ProjetosUsuarios = new List<ProjetoUsuario>(); // Inicialize a lista
            TarefasUsuarios = new List<TarefaUsuario>(); // Inicialize a lista
        }
    }
}