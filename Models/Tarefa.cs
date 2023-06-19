using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;

namespace TrabalhoFinal.Models

{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public List<TarefaUsuario> TarefasUsuarios { get; set; }
        public string? Status { get; set; } // Adicionada a propriedade "Status"
        public Tarefa()
        {
            TarefasUsuarios = new List<TarefaUsuario>(); // Inicialize a lista
        }
    }
}