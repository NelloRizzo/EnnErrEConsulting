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
            return
                 (type == EmailAddressModel.ModelType) ? JsonSerializer.Deserialize<EmailAddressModel>(root.GetRawText(), options) :
                 (type == PhoneNumberAddressModel.ModelType) ? JsonSerializer.Deserialize<PhoneNumberAddressModel>(root.GetRawText(), options) :
                 (type == PostalAddressModel.ModelType) ? JsonSerializer.Deserialize<PostalAddressModel>(root.GetRawText(), options) :
                 throw new NotSupportedException($"Type {type} is not supported");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, AddressModel value, JsonSerializerOptions options) {
            if (value.Type == EmailAddressModel.ModelType)
                JsonSerializer.Serialize(writer, (EmailAddressModel)value, options);
            else if (value.Type == PhoneNumberAddressModel.ModelType)
                JsonSerializer.Serialize(writer, (PhoneNumberAddressModel)value, options);
            else if (value.Type == PostalAddressModel.ModelType)
                JsonSerializer.Serialize(writer, (PostalAddressModel)value, options);
            else
                throw new NotSupportedException($"Type {value.Type} not supported");
        }
    }
}
