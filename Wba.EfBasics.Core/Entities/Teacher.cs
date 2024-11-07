using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Teacher :  BaseEntity
    {
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        //one to many by convention teacher => courses
        //navigation properties
        public ICollection<Course> Courses { get; set; }

        public Address Address { get; set; }
        public int? AddressId { get; set; }
    }
}
