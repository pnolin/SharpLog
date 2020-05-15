﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharpLog.Core.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";
    }
}