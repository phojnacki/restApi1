using Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Post : AuditableEntity
    {

        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("Id")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [BsonElement("Title")]
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        [JsonPropertyName("Content")]
        public string Content { get; set; }

        public Post() { }

        public Post(int id,string title,string content)
        {
            (Id, Title, Content) = (id, title, content);
        }
    }
}
