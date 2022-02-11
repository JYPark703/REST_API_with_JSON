using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw02Server.Models
{
    public class Person
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Double PayRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}