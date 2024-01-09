using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection.Emit;


namespace Lab3;

public class SerializableLibrary : Library
{

    public string JsonSerialize()
    {
        return JsonSerializer.Serialize<IEnumerable<Book>>(_catalog);
    }

    public void JsonSerialize(string path)
    {
        string jsonString = JsonSerializer.Serialize<IEnumerable<Book>>(_catalog);
        File.WriteAllText(path, jsonString);

    }

    public string XmlSerialize()
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var writer = new StringWriter();
        serializer.Serialize(writer, _catalog);
        return writer.ToString();
    }

    public void XmlSeriaize(string path)
    {
        var serializer = new XmlSerializer(typeof(List<Book>));
        using var writer = new StringWriter();
        serializer.Serialize(writer, _catalog);
        File.WriteAllText(path, writer.ToString());
    }
    public void LoadFromJson(string json)
    {
        _catalog = JsonSerializer.Deserialize<List<Book>>(json);
    }

    public void LoadFromXml(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

        using (StringReader stringReader = new StringReader(xml))
        {
            _catalog = (List<Book>)serializer.Deserialize(stringReader);
        }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=books.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(b => b.ISBN);
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().Property(b => b.Genres).HasConversion(
                v => string.Join(',', v),
                v => v.Split(new[] { ',' }, StringSplitOptions.None).ToList());
            modelBuilder.Entity<Book>().Property(b => b.Tags).HasConversion(
                v => string.Join(',', v),
                v => v.Split(new[] { ',' }, StringSplitOptions.None).ToList());
        }
    }

}
