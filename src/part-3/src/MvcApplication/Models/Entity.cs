using MongoDB.Bson;
using Newtonsoft.Json;

namespace MvcApplication.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Entity
    {
        [JsonProperty(PropertyName = "id")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; protected set; }
    }
}