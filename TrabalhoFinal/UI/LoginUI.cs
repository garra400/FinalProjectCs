using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using TrabalhoFinal.Models;
using TrabalhoFinal.BancodeDados;

namespace TrabalhoFinal.UI
{
    public class LoginUI
    {
        public static Usuario RealizarLogin(ProjetoDbContext db)
        {
            Console.WriteLine("== Login ==");

            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                Console.WriteLine("Email ou senha inválidos.");
                return null;
            }

            Console.WriteLine("Login realizado com sucesso!");

            return usuario;
        }

        public static Usuario Registrar(ProjetoDbContext db)
        {
            Console.WriteLine("== Registrar Usuário ==");

            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Usuario usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            Console.WriteLine("Usuário registrado com sucesso!");

            return usuario;
        }
    }
}
