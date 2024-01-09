

namespace Lab3;

internal class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nГлавное меню:");
            Console.WriteLine("1. Добавить книгу в каталог");
            Console.WriteLine("2. Найти по названию");
            Console.WriteLine("3. Найти по автору");
            Console.WriteLine("4. Найти по ISBN");
            Console.WriteLine("5. Найти по ключевым словам (тегам)");
            Console.WriteLine("6. Выход");

            Console.Write("Введите ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBookToCatalog(library);
                    break;
                case "2":
                    Console.Write("Введите название или его фрагмент: ");
                    string title = Console.ReadLine();
                    DisplayResults(library.SearchByTitle(title));
                    break;
                case "3":
                    Console.Write("Введите имя автора или его фрагмент: ");
                    string author = Console.ReadLine();
                    DisplayResults(library.SearchByAuthor(author));
                    break;
                case "4":
                    Console.Write("Введите ISBN: ");
                    string isbn = Console.ReadLine();
                    DisplayResults(library.SearchByISBN(isbn));
                    break;
                case "5":
                    Console.Write("Введите теги через пробел: ");
                    string[] tags = Console.ReadLine().Split(' ');
                    DisplayResults(library.SearchByTags(tags));
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор, введите значение от 1 до 6");
                    break;
            }
        }
    }

    static void AddBookToCatalog(Library library)
    {
        BookBuilder book = new BookBuilder();

        Console.Write("Введите название: ");
        book.SetTitle(Console.ReadLine());

        Console.Write("Введите автора: ");
        book.SetAuthor(Console.ReadLine());

        Console.Write("Введите жанры через запятую: ");
        string[] genres = Console.ReadLine().Split(',');
        book.SetGenres(genres.Select(g => g.Trim()).ToList());

        Console.Write("Введите дату публикации (год-месяц-день): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            book.SetPublicationDate(date);
        }
        else
        {
            Console.WriteLine("Неверный формат даты");
            book.SetPublicationDate(DateTime.MinValue);
        }

        Console.Write("Введите аннотацию: ");
        book.SetAnnotation(Console.ReadLine());

        Console.Write("Введите ISBN: ");
        book.SetISBN(Console.ReadLine());

        Console.Write("Введите теги через пробел: ");
        string[] tags = Console.ReadLine().Split(' ');
        book.SetTags(tags.Select(g => g.Trim()).ToList());

        library.AddBook(book.Build());
        Console.WriteLine("\nКнига добавлена в каталог");
    }

    private static void DisplayResults(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine(book.GetPrewiew());
        }
    }
}

