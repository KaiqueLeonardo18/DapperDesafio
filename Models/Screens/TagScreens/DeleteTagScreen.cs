using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma Tag");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            Delete(new Tag
            {
                Id = int.Parse(id)
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Delete(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Delete(tag);
                Console.WriteLine("Tag deletada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}