using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class Quiz
    {
        public Guid QuizUid { get; set; }
        public Guid CourseUid { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
