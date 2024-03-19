using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Id: ");
            var id = Console.ReadLine()!;
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Email: ");
            var email = Console.ReadLine()!;
            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine()!;
            Console.WriteLine("Image: ");
            var image = Console.ReadLine()!;
            Console.WriteLine("Senha: ");
            var senha = Console.ReadLine()!;
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine()!;

            Update(new User
            {
                Id = int.Parse(id),
                Name = name,
                Email = email,
                Bio = bio,
                Image = image,
                PasswordHash = senha,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}