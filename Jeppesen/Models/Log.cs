using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Models
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
    }
}
