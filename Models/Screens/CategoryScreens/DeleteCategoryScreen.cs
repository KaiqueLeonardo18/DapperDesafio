using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma categoria");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            Delete(new Category
            {
                Id = int.Parse(id)
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Delete(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Delete(category);
                Console.WriteLine("categoria deletada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}