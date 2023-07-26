using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiSandbox.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string Author { get; set; }

        public List<Characters> Characters { get; set; }
    }

    [JsonSerializable(typeof(List<Book>))]
    internal sealed partial class BookContext : JsonSerializerContext
    {

    }
}
