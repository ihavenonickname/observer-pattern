using System;
using System.Collections.Generic;

namespace EventsExampleCS
{
    class Program
    {
        public class BookSoldEventArgs : EventArgs
        {
            public string BookSold;
            public List<string> Books;
        }

        public class BookStore
        {
            public event EventHandler<BookSoldEventArgs> BookSold;

            private List<string> books;

            public BookStore()
            {
                books = new List<string>()
                {
                    "The God Delusion - Dawkins",
                    "Animal Farm - Orwell",
                    "Symposium - Plato",
                    "Ecce Homo - Nietzsche",
                    "The Trial - Kafka"
                };
            }

            public void Sell(string bookName)
            {
                if (books.Remove(bookName))
                {
                    BookSold?.Invoke(this, new BookSoldEventArgs()
                    {
                        BookSold = bookName,
                        Books = books
                    });
                }
            }
        }

        static void Main(string[] args)
        {
            var bs = new BookStore();

            bs.BookSold += (object sender, BookSoldEventArgs e) =>
            {
                Console.WriteLine($"{e.BookSold} sold, there are more {e.Books.Count} books");
            };

            bs.Sell("The God Delusion - Dawkins");
            bs.Sell("Muito Mais Que 5inco Minutos – Kefera");
            bs.Sell("Ecce Homo - Nietzsche");

            Console.ReadKey();
        }
    }
}
