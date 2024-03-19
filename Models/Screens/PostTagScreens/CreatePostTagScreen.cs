
using Blog;
using BlogDesafio.Repository;

namespace BlogDesafio.Models.Screens.PostTagScreens
{
    public class CreatePostTagScreen
    {
        public static void Load()
        {
            Console.WriteLine("Novo vinculo de Post e Tag");
            Console.WriteLine("Nome do slug: ");
            var slug = Console.ReadLine();
            var post = PostLink(slug);

            if (post is null)
            {
                Console.WriteLine("Post não encontrado");
            }

            Console.WriteLine("Nome da Tag: ");
            var tagName = Console.ReadLine();
            var tag = TagLink(tagName);
            if (tag is null)
            {
                Console.WriteLine("Tag não encontrado");
                Load();
            }

            Create(new PostTag
            {
                PostId = post.Id,
                TagId = tag.Id
            });
        }

        private static void Create(PostTag postTag)
        {
            var repository = new Repository<PostTag>(Database.connection);
            repository.Create(postTag);
        }

        private static Post PostLink(string? slug)
        {
            try
            {
                var repository = new PostRepository(Database.connection);
                return repository.GetPostForSlug(slug);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve um erro ao procurar o Post");
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private static Tag TagLink(string? name)
        {
            try
            {
                var repository = new TagRepository(Database.connection);
                return repository.GetTagForName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Houve um erro ao procurar o Post");
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}