using BTKAkademiBookDemo.Models;

namespace BTKAkademiBookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books;
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){ID = 1, Title = "Karagöz ve Hacivat", Price = 25},
                new Book(){ID = 2, Title = "Mesnevi", Price = 30},
                new Book(){ID = 3, Title = "Dede Korkut", Price = 50}
            };

        }
    }
}
