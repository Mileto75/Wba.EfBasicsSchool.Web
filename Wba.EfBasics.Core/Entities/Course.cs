using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        //define the teacher relation one teacher
        //navigation property
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
