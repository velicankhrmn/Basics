using BookDemo.Models;
namespace BookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>();
            Books.Add(new Book() { Id = 1, Title = "İnsan ne ile yaşar?", Price = 75});
            Books.Add(new Book() { Id = 2, Title = "Suç ve Ceza", Price = 100});
            Books.Add(new Book() { Id = 3, Title = "Sefiller", Price = 125});
        }
    }
}
