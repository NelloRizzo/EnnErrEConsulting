using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.JsonConverters
{
    /// <summary>
    /// Converter JSON per tutti gli indirizzi.
    /// </summary>
    public class AddressModelConverter : JsonConverter<AddressModel>
    {
        /// <inheritdoc/>
        public override AddressModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;
            var type = root.GetProperty("type").GetString();
            return type switch {
                "EmailAddressModel" => JsonSerializer.Deserialize<EmailAddressModel>(root.GetRawText(), options),
                "PhoneNumberAddressModel" => JsonSerializer.Deserialize<PhoneNumberAddressModel>(root.GetRawText(), options),
                "PostalAddressModel" => JsonSerializer.Deserialize<PostalAddressModel>(root.GetRawText(), options),
                _ => throw new NotSupportedException($"Type {type} is not supported")
            };
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, AddressModel value, JsonSerializerOptions options) {
            switch (value.Type) {
                case "EmailAddressModel": JsonSerializer.Serialize(writer, (EmailAddressModel)value, options); break;
                case "PhoneNumberAddressModel": JsonSerializer.Serialize(writer, (PhoneNumberAddressModel)value, options); break;
                case "PostalAddressModel": JsonSerializer.Serialize(writer, (PostalAddressModel)value, options); break;
                default: throw new NotSupportedException($"Type not supported");
            };
        }
    }
}
