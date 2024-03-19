using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDesafio.Models.Screens.PostTagScreens
{
    public class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Vincular Post e Tag");
            Console.WriteLine("2 - Excluir Post e Tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    CreatePostTagScreen.Load();
                    break;
                case 2:
                    DeletePostTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}