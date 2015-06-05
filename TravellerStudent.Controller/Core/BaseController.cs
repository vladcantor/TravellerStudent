using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Controller.Core
{
    public class BaseController
    {
        protected ControllerContext _context;
        public BaseController(ControllerContext context)
        {
            _context = context; 
        }
    }
}
