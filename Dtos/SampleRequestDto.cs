using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using EnsolTest.Converters;

namespace EnsolTest.Dtos
{
    public class SampleRequestDto
    {
        [Required]
        public string Str { get; set; }
        public long? Number { get; set; } = 1;

        public decimal? Decimal { get; set; } = 0.01m;

        public ObjectSample? objectSample { get; set; }
        [JsonConverter(typeof(SingleArrayJsonConverter<string>))]
        public string[]? Array { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? datetime { get; set; }
    }

    public class ObjectSample
    {
        public bool? ObjectA { get; set; }
        public string? ObjectB { get; set; }

        public override string ToString()
        {
            return $"ObjectA={ObjectA}, ObjectB={ObjectB}";
        }
    }
}
