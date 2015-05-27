using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class Course
    {
        public Guid CourseUid { get; set; }
        public Guid TeacherUid { get; set; }
        public string Name { get; set; }
    }
}
