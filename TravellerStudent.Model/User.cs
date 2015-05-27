using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model
{
    public class User
    {
        public Guid UserUid { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public UserType UserType { get; set; }
    }
}
