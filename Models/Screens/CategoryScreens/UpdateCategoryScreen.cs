using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma Categoria");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();
            Console.WriteLine("Nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Slug:");
            var slug = Console.ReadLine();

            Update(new Category
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a Categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}