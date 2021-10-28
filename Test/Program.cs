using System;

namespace Test
{
    class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Testing MongoDB...");
            
            // Connect to DB...
            var db = new Mongo();
            
            // Data...
            var userId = Guid.NewGuid();
            var newUser = new User
            {
                Id = userId,
                FirstName = "John"
            };

            // Create...
            db.CreateUser(newUser);
            
            // Read...
            var existingUser = db.GetUser(userId);

            // Update...
            existingUser.LastName = "Morsley";
            db.UpdateUser(existingUser);
            
            // Delete...
            db.DeleteUser(userId);
            
            Console.WriteLine("Done! :-)");
        }
    }
}