using Contracts.Abstractions.Messages;
using Google.Protobuf.Compiler;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public class Projection
    {
        public class ListAccountUser : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("AggregateId")]
            public string AggregateId { get; set; } = string.Empty;
            [BsonElement("UserName")]
            public string UserName { get; set; } = string.Empty;
            [BsonElement("PassWord")]
            public string PassWord { get; set; } = string.Empty;
            [BsonElement("Role")]
            public string Role { get; set; } = string.Empty;
            [BsonElement("NickName")]
            public string NickName { get; set; } = string.Empty;
        }
    }
}
