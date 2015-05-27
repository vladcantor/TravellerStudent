using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class Choice
    {
        public Guid ChoiceUid { get; set; }
        public Guid QuestionUid { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
