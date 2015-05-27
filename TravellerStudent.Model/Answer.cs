using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class Answer
    {
        public Guid ChoiceUid { get; set; }
        public Guid QuizUid { get; set; }
        public Guid UserUid { get; set; }
    }
}
