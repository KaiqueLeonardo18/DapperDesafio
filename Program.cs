using System;
using System.Data;
using System.Runtime.CompilerServices;
using Azure.Identity;
using Blog;
using BlogDesafio.Models;
using BlogDesafio.Models.Screens.CategoryScreens;
using BlogDesafio.Models.Screens.RoleScreens;
using BlogDesafio.Models.Screens.TagScreens;
using BlogDesafio.Models.Screens.UserRoleScreens;
using BlogDesafio.Models.Screens.UserScreens;
using BlogDesafio.Repository;
using Microsoft.Data.SqlClient;

namespace BlogDesafio
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            Database.connection = new SqlConnection(CONNECTION_STRING);
            Database.connection.Open();
            Load();

            Console.ReadKey();
            Database.connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuUserRoleScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}