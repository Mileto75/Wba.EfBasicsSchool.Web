using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class Student : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
