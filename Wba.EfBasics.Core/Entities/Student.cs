using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Student : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //many to many with courses
        //student has many courses
        public ICollection<Course> Courses { get; set; }
        public Address Address { get; set; }
        public int? AddressId { get; set; }
    }
}
