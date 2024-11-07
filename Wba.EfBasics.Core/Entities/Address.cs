using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Address : BaseEntity
    {
        public string FullAdress { get; set; }
        //one to one
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
