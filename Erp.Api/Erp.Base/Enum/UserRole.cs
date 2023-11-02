using System.Text.Json.Serialization;

namespace Erp.Base.Enum
{
    public enum UserRole
    {
        [JsonPropertyName("admin")]
        admin,
        [JsonPropertyName("dealer")]
        dealer
    }
}
