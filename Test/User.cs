using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Test
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}