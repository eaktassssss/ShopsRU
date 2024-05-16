using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Common
{
    public abstract class MongoBaseEntity : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = BsonObjectId.GenerateNewId().ToString();
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
