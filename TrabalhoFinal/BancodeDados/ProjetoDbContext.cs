using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using TrabalhoFinal.Models;
using TrabalhoFinal.UI;

namespace TrabalhoFinal.BancodeDados
{
    public class ProjetoDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ProjetoUsuario> ProjetosUsuarios { get; set; }
        public DbSet<TarefaUsuario> TarefasUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;database=db_GerenciadordeProjetos", new MySqlServerVersion(new Version(8, 0, 26)));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjetoUsuario>()
                .HasKey(pu => new { pu.UsuarioId, pu.ProjetoId });

            modelBuilder.Entity<ProjetoUsuario>()
                .HasOne(pu => pu.Usuario)
                .WithMany(u => u.ProjetosUsuarios)
                .HasForeignKey(pu => pu.UsuarioId);

            modelBuilder.Entity<ProjetoUsuario>()
                .HasOne(pu => pu.Projeto)
                .WithMany(p => p.ProjetosUsuarios)
                .HasForeignKey(pu => pu.ProjetoId);

            modelBuilder.Entity<TarefaUsuario>()
                .HasKey(tu => new { tu.UsuarioId, tu.TarefaId });

            modelBuilder.Entity<TarefaUsuario>()
                .HasOne(tu => tu.Usuario)
                .WithMany(u => u.TarefasUsuarios)
                .HasForeignKey(tu => tu.UsuarioId);

            modelBuilder.Entity<TarefaUsuario>()
                .HasOne(tu => tu.Tarefa)
                .WithMany(t => t.TarefasUsuarios)
                .HasForeignKey(tu => tu.TarefaId);

            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId);

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Status)
                .IsRequired(false); // Adicionar status como campo obrigatório

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .IsRequired(false); // Adicionar status como campo obrigatório

            base.OnModelCreating(modelBuilder);
        }
    }
}