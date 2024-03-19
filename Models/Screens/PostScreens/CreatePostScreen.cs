using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Post");
            Console.WriteLine("---------------------");
            Console.WriteLine("Categoria Id:");
            var idCategory = Console.ReadLine();

            Console.WriteLine("Usuario Id:");
            var idUser = Console.ReadLine();

            Create(new Post
            {
                CategoryId = int.Parse(idCategory),
                AuthorId = int.Parse(idUser),
                

            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void Create(Post post)
        {

        }

        public static Category GetCategory(string name)
        {
            var repository = new CategoryRepository(Database.connection);
            return repository.GetCategoryByName(name);
        }

        public static User GetUser(string name)
        {
            var repository = new UserRepository(Database.connection);
            return repository.GetUserForName(name);
        }
    }
}