

namespace Lab3;

public static class BookTester
{
    public static bool CompareBookLists(List<Book> first, List<Book> second)
    {
        if (first.Count != second.Count)
        {
            return false;
        }
        for (int i = 0; i < first.Count; i++)
        {
            if (!CompareBooks(first[i], second[i]))
            {
                return false;
            }
        }
        return true;
    }
    static bool CompareBooks(Book first, Book second)
    {
        if (first.Title != second.Title)
        {
            return false;
        }
        if (first.Author != second.Author)
        {
            return false;
        }
        if (first.ISBN != second.ISBN)
        {
            return false;
        }
        if (first.PublicationDate != second.PublicationDate)
        {
            return false;
        }
        if (first.Annotation != second.Annotation)
        {
            return false;
        }
        if (first.Genres.Count != second.Genres.Count)
        {
            return false;
        }
        if (first.Tags.Count != second.Tags.Count)
        {
            return false;
        }
        if (first.Genres.Except(second.Genres).Any())
        {
            return false;
        }
        if (first.Tags.Except(second.Tags).Any())
        {
            return false;
        }
        return true;
    }
}