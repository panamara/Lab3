
using System.Reflection.Metadata;

namespace Lab3.TestProject3
{

    public class JsonTests
    {
        [Fact]
        public void JsonTest()
        {
            var library = new SerializableLibrary();
            var bookone = new BookMaker();
            var book = bookone
                .SetTitle("Name")
                .SetAuthor("AuthorName")
                .SetGenres(new[] { "Adventure" })
                .SetISBN("548754-23-1")
                .SetPublicationDate(new DateTime(1954, 7, 29))
                .SetAnnotation("Something")
                .SetTags(new[] { "classic" })
                .Build();
            library.AddBook(book);
            string json = library.JsonSerialize();
            var loadLibrary = new SerializableLibrary();
            loadLibrary.LoadFromJson(json);

            Assert.True(BookTester.CompareBookLists(library.GetCatalog().ToList(), loadLibrary.GetCatalog().ToList()));
        }
    }
}
