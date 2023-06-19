using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;

namespace TrabalhoFinal.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public int UsuarioResponsavelId { get; set; }
        public Usuario UsuarioResponsavel { get; set; }
        public string? Descricao {get; set; }
        public List<ProjetoUsuario> ProjetosUsuarios { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public string? Status { get; set; } // Adicionada a propriedade "Status"
        public Projeto()
        {
            ProjetosUsuarios = new List<ProjetoUsuario>(); // Inicialize a lista
            Tarefas = new List<Tarefa>(); // Inicialize a lista
        }
    }
}