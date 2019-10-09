using Jeppesen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Interfaces
{
    public interface IRecordsService
    {
        bool Create(string band, string title, long unitsSold, Genre genre);
        Record Read(string band, string title);
        bool Update(string band, string title, long unitsSold);
        bool Delete(string band, string title);
    }
}
