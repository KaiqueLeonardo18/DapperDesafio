using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesafio.Models.Screens.UserRoleScreens
{
    public class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Vincular usuário e Role");
            Console.WriteLine("2 - Excluir usuário e Role");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    CreateUserRoleScreen.Load();
                    break;
                case 2:
                    DeleteUserRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}