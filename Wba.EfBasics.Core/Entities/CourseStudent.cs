using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.EfBasics.Core.Entities
{
    public class CourseStudent
    {
        //one student
        public Student Student { get; set; }
        public int StudentId { get; set; }
        //has one course
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int Score { get; set; }
    }
}
