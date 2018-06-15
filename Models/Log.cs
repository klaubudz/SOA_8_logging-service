using System;

namespace Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Message { get; set; }
        public Priority Priority { get; set; }
    }
}
