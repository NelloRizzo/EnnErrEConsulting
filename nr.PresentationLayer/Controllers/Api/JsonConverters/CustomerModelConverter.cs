using nr.PresentationLayer.Controllers.Api.Models.Customers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.JsonConverters
{
    /// <summary>
    /// Converter JSON per tutti i clienti.
    /// </summary>
    public class CustomerModelConverter : JsonConverter<CustomerModel>
    {
        /// <inheritdoc/>
        public override CustomerModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;
            var type = root.GetProperty("type").GetString();
            return
                (type == CompanyModel.ModelType) ? JsonSerializer.Deserialize<CompanyModel>(root.GetRawText(), options) :
                (type == PersonModel.ModelType) ? JsonSerializer.Deserialize<PersonModel>(root.GetRawText(), options) :
                throw new NotSupportedException($"Type {type} is not supported");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, CustomerModel value, JsonSerializerOptions options) {
            if (value.Type == CompanyModel.ModelType)
                JsonSerializer.Serialize(writer, (CompanyModel)value, options);
            else if (value.Type == PersonModel.ModelType)
                JsonSerializer.Serialize(writer, (PersonModel)value, options);
            else
                throw new NotSupportedException($"Type {value.Type} not supported");
        }
    }
}
