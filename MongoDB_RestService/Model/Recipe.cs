using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_RestService.Model
{
    public class Recipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("NumOfIng")]
        public int NumOfIng { get; set; }
        [BsonElement("Instruction")]
        public string Instructions { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
    }
}
