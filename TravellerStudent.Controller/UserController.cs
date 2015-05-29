using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Controller.Core;
using TravellerStudent.Model;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Controller
{
    public class UserController:BaseController
    {
        public UserController(ControllerContext context):base(context)
        {

        }

        public void Add(User user)
        {
            _context.Repository.User.Add(user);
        }
    }
}
