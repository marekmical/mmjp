using Jeppesen.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jeppesen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RecordStoreContext context)
        {
            const int MaxAttempts = 10;
            int attempts = 0;
            bool dbCreated = false;

            // Wait for MS SQL to fully initialize
            while(attempts < MaxAttempts)
            {
                try
                {
                    dbCreated = context.Database.EnsureCreated();
                }
                catch(SqlException) { }

                if (dbCreated) break;

                Thread.Sleep(30 * 1000);
                attempts++;
            }

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.Add(new User { Login = "test", Password = "test" });
            context.SaveChanges();

            context.Records.Add(new Record { Title = "In Utero", Band = "Nirvana", Genre = Genre.Rock, UnitsSold = 100000000 });
            context.SaveChanges();

            context.Logs.Add(new Log { TimeStamp = DateTime.Now.Date, UserID = 1, Description = "In Utero by Nirvana added to store records" });
            context.SaveChanges();
        }
    }
}
