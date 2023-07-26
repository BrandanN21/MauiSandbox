using MauiSandbox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiSandbox.Services
{
    public class BookService
    {
        HttpClient _httpClient;

        public BookService()
        {
            _httpClient = new HttpClient();
        }

        List<Book> bookList;

        public async Task<List<Book>> GetBooks()
        {
            if (bookList?.Count > 0)
                return bookList;

            using var stream = await FileSystem.OpenAppPackageFileAsync("bookdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            bookList = JsonSerializer.Deserialize(contents, BookContext.Default.ListBook);

            return bookList;
        }
    }
}
