using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dz_6_OOP
{
    public class Book
    {
        [JsonIgnore]
        public int PublishingHouseId { get; set; }
        [JsonPropertyName("Name")]
        public string Title { get; set; } = string.Empty;
        public PublishingHouse PublishingHouse { get; set; } = new PublishingHouse();
    }
}
