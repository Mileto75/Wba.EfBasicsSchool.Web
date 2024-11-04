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
    }
}
