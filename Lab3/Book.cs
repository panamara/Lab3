
using System.ComponentModel.DataAnnotations;

namespace Lab3;


public class Book 
{
    public Book()
    {
    }
    public Book(string title, string author, List<string> genres, DateTime publicationDate, string annotation, string isbn, List<string> tags)
    {
        Title = title;
        Author = author;
        Genres = genres;
        PublicationDate = publicationDate;
        Annotation = annotation;
        ISBN = isbn;
        Tags = tags;
    }

    public string Title { get; set; }

    public string Author { get; set; }

    public List<string> Genres { get; set; }

    public DateTime PublicationDate { get; set; }

    public string Annotation { get; set; }

    [Key]
    public string ISBN { get; set; }

    public List<string> Tags { get; set; }


    public string GetPrewiew()
    {
        return $"{Title} by {Author}, ISBN: {ISBN}";
    }
    public override string ToString()
    {
        return $"{Title} by {Author}, ISBN: {ISBN} \n {Annotation} \n Genres: {string.Join(", ", Genres)} \n Tags: {string.Join(", ", Tags)} \n Publication date: {PublicationDate}";
    }
}

