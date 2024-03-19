using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorias");
            Console.WriteLine("---------------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Category>(Database.connection);
            var roles = repository.Get();

            foreach (var item in roles)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}