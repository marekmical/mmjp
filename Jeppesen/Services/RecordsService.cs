using Jeppesen.Models;
using Jeppesen.Data;
using Jeppesen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Services
{
    public enum OperationType { Create, Read, Update, Delete };

    public class RecordsService : IRecordsService
    {
        private readonly RecordStoreContext context;
        private readonly IUserService userService;

        public RecordsService(RecordStoreContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        
        public bool Create(string band, string title, long unitsSold, Genre genre)
        {
            var isLoggedIn = CheckLogSession(OperationType.Delete);
            bool success = false;

            if (!isLoggedIn)
            {
                return success;
            }

            var existingRecord = this.context.Records.Where(rec => rec.Band == band && rec.Title == title).FirstOrDefault();

            string logMessage = string.Format("User {0} {1} attempted to create record {2} by {3}", userService.UserID, existingRecord == null ? "successfully" : "unsuccessfully", title, band);

            if (existingRecord == null)
            {
                var record = new Record { Band = band, Title = title, Genre = genre, UnitsSold = unitsSold };
                this.context.Add(record);
                this.context.SaveChanges();
                success = true;
            }

            LogAction(logMessage);

            return success;
        }

        public Record Read(string band, string title)
        {
            var isLoggedIn = CheckLogSession(OperationType.Read);
            Record record = null;

            if (isLoggedIn)
            {

                record = this.context.Records.Where(rec => rec.Band == band && rec.Title == title).FirstOrDefault();

                string logMessage = string.Format("User {0} {1} attempted to read record {2} by {3}", userService.UserID, record != null ? "successfully" : "unsuccessfully", title, band);

                LogAction(logMessage);
            }

            return record;
        }

        public bool Update(string band, string title, long unitsSold)
        {
            var isLoggedIn = CheckLogSession(OperationType.Update);
            bool success = false;

            if (!isLoggedIn)
            {
                return success;
            }

            var record = this.context.Records.Where(rec => rec.Band == band && rec.Title == title).FirstOrDefault();

            string logMessage = string.Format("User {0} {1} attempted to update record {2} by {3}", userService.UserID, record != null ? "successfully" : "unsuccessfully", title, band);

            if (record != null)
            {
                string.Concat(logMessage, "Units sold value updated from {0} to {1}", record.UnitsSold, unitsSold);
                record.UnitsSold = unitsSold;
                this.context.SaveChanges();
                success = true;
            }

            LogAction(logMessage);

            return success;
        }

        public bool Delete(string band, string title)
        {
            var isLoggedIn = CheckLogSession(OperationType.Delete);
            bool success = false;

            if (!isLoggedIn)
            {
                return success;
            }

            var record = this.context.Records.Where(rec => rec.Band == band && rec.Title == title).FirstOrDefault();

            string logMessage = string.Format("User {0} {1} attempted to delete record {2} by {3}", userService.UserID, record != null ? "successfully" : "unsuccessfully", title, band);

            if (record != null)
            {
                this.context.Remove(record);
                this.context.SaveChanges();
                success = true;
            }

            LogAction(logMessage);

            return success;
        }

        private bool CheckLogSession(OperationType operationType)
        {
            var userID = this.userService.UserID;

            if (userID == 0)
            {
                var logMessage = string.Format("Attempted {0} operation by non-logged user", operationType.ToString().ToLower());
                LogAction(logMessage);
                return false;
            }

            return true;
        }

        private void LogAction(string message)
        {
            var log = new Log { UserID = userService.UserID, TimeStamp = DateTime.Now, Description = message };
            this.context.Logs.Add(log);
            this.context.SaveChanges();
        }
    }
}
