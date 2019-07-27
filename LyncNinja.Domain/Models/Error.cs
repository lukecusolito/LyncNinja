using LyncNinja.Domain.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LyncNinja.Domain.Models
{
    public class Error
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
