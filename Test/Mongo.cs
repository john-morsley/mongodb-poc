using System;
using MongoDB.Driver;

namespace Test
{
    public class Mongo
    {
        private const string DatabaseName = "morsley";
        private const string TableName = "users";

        private readonly IMongoDatabase _db;

        public Mongo()
        {
            var username = "john";
            var password = "morsley";
            var mongoDbAuthMechanism = "SCRAM-SHA-1";
            var internalIdentity = new MongoInternalIdentity("admin", username);
            var passwordEvidence = new PasswordEvidence(password);
            var mongoCredential = new MongoCredential(mongoDbAuthMechanism, internalIdentity, passwordEvidence);
            
            try
            {
                var settings = new MongoClientSettings
                {
                    Credential = mongoCredential,
                    Server = new MongoServerAddress("localhost", 27017)
                };
                var client = new MongoClient(settings);
                _db = client.GetDatabase(DatabaseName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                var users = _db.GetCollection<User>(TableName);
                users.InsertOne(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public User GetUser(Guid userId)
        {
            try
            {
                var users = _db.GetCollection<User>(TableName);
                return users.Find<User>(user => user.Id == userId).SingleOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                var users = _db.GetCollection<User>(TableName);
                users.ReplaceOne(i => i.Id == user.Id, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public void DeleteUser(Guid userId)
        {
            try
            {
                var users = _db.GetCollection<User>(TableName);
                users.DeleteOne(i => i.Id == userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}