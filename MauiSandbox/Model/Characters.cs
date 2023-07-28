using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiSandbox.Model
{
    public class Characters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
    }

    [JsonSerializable(typeof(List<Characters>))]
    internal sealed partial class CharactersContext : JsonSerializerContext
    {

    }
}
