using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnsolTest.Converters
{
    public class SingleArrayJsonConverter<T> : JsonConverter<T[]>
    {
        public override T[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // null 처리 (필요에 따라 Array.Empty<T>()로 바꿔도 됨)
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null!;
            }

            var elementConverter = (JsonConverter<T>)options.GetConverter(typeof(T));

            // [ ... ] 배열인 경우
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var list = new List<T>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                        break;

                    // 배열의 각 요소를 T로 읽기
                    var value = elementConverter.Read(ref reader, typeof(T), options);
                    list.Add(value!);
                }

                return list.ToArray();
            }

            // 단일 값인 경우: 그 값을 T로 읽어서 길이 1짜리 배열로 반환
            var singleValue = elementConverter.Read(ref reader, typeof(T), options);
            return new[] { singleValue! };
        }

        public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            var elementConverter = (JsonConverter<T>)options.GetConverter(typeof(T));

            foreach (var v in value)
            {
                elementConverter.Write(writer, v, options);
            }

            writer.WriteEndArray();
        }
    }
}
