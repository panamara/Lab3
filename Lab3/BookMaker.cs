
namespace Lab3;

public class BookMaker 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public List<string> Genres { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Annotation { get; set; }
    public string Isbn { get; set; }
    public List<string> Tags { get; set; }

    public SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public SetAuthor(string author)
    {
        Author = author;
        return this;
    }

    public SetGenres(IEnumerable<string> genres)
    {
        Genres = genres.ToList();
        return this;
    }

    public SetISBN(string isbn)
    {
        Isbn = isbn;
        return this;
    }

    public SetPublicationDate(DateTime date)
    {
        PublicationDate = date;
        return this;
    }

    public SetAnnotation(string annotation)
    {
        Annotation = annotation;
        return this;
    }

    public SetTags(IEnumerable<string> tags)
    {
        Tags = tags.ToList();
        return this;
    }

    public Book Build()
    {
        return new Book(Title, Author, Genres, PublicationDate, Annotation, Isbn, Tags);
    }
}