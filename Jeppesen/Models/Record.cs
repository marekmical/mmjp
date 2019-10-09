using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Genre
    {
        Rock, Pop, Country, Rap, Jazz, Heavy
    }

    public class Record
    {
        public string Title { get; set; }
        public string Band { get; set; }
        public long UnitsSold { get; set; }
        public Genre Genre { get; set; }
    }
}
