using MongoDB.Bson;
using Newtonsoft.Json;

namespace MvcApplication.Models
{
    public abstract class Entity
    {
        public ObjectId Id { get; protected set; }
    }
}