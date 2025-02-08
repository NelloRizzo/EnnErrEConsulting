using nr.PresentationLayer.Controllers.Api.Models.Attachments;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.JsonConverters
{
    /// <summary>
    /// Converter JSON per tutti gli indirizzi.
    /// </summary>
    public class LinkModelConverter : JsonConverter<LinkModel>
    {
        /// <inheritdoc/>
        public override LinkModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;
            var type = root.GetProperty("type").GetString();
            return
                 (type == ContentLinkModel.ModelType) ? JsonSerializer.Deserialize<ContentLinkModel>(root.GetRawText(), options) :
                 (type == UrlLinkModel.ModelType) ? JsonSerializer.Deserialize<UrlLinkModel>(root.GetRawText(), options) :
                 throw new NotSupportedException($"Type {type} is not supported");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, LinkModel value, JsonSerializerOptions options) {
            if (value.Type == ContentLinkModel.ModelType)
                JsonSerializer.Serialize(writer, (ContentLinkModel)value, options);
            else if (value.Type == UrlLinkModel.ModelType)
                JsonSerializer.Serialize(writer, (UrlLinkModel)value, options);
            else
                throw new NotSupportedException($"Type {value.Type} not supported");
        }
    }
}
