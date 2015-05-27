using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class Question
    {
        public Guid QuestionUid { get; set; }
        public Guid CourseUid { get; set; }
        public string Text { get; set; }
    }
}
