using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using TrabalhoFinal.Models;
using TrabalhoFinal.UI;
using TrabalhoFinal.BancodeDados;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new ProjetoDbContext())
        {
            // Certificar-se de que o banco de dados existe
            db.Database.EnsureCreated();
            bool sair = false;
            Usuario usuarioLogado = null;
            Projeto projetoSelecionado = null;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("== Sistema de Gerenciamento de Projetos ==");
                Console.WriteLine();

                if (usuarioLogado == null)
                {
                    Console.WriteLine("1. Registrar");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("0. Sair");
                }
                else
                {
                    Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
                    Console.WriteLine("1. Criar Projeto");
                    Console.WriteLine("2. Listar Projetos");
                    Console.WriteLine("3. Selecionar Projeto");
                    Console.WriteLine("0. Logout");
                }

                Console.WriteLine();
                Console.Write("Opção: ");
                string opcaoPrincipal = Console.ReadLine();

                Console.Clear();

                switch (opcaoPrincipal)
                {
                    case "1":
                        if (usuarioLogado == null)
                        {
                            usuarioLogado = LoginUI.Registrar(db);
                        }
                        else
                        {
                            ProjetoUI.CriarProjeto(usuarioLogado, db);
                        }
                        break;
                    case "2":
                        if (usuarioLogado == null)
                        {
                            usuarioLogado = LoginUI.RealizarLogin(db);
                        }
                        else
                        {
                            ProjetoUI.ListarProjetos(usuarioLogado, db);
                        }
                        break;
                    case "3":
                        if (usuarioLogado != null)
                        {
                            projetoSelecionado = ProjetoUI.SelecionarProjeto(usuarioLogado, db);
                            if (projetoSelecionado != null)
                            {
                                ProjetoUI.AcessarProjeto(usuarioLogado, projetoSelecionado, db);
                            }
                        }
                        break;
                    case "0":
                        if (usuarioLogado == null)
                        {
                            sair = true;
                        }
                        else
                        {
                            usuarioLogado = null;
                            projetoSelecionado = null;
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
