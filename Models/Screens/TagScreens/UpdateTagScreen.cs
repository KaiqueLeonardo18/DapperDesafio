using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma Tags");
            Console.WriteLine("---------------------");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();
            Console.WriteLine("Nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Slug:");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Update(tag);
                Console.WriteLine("Tag cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}