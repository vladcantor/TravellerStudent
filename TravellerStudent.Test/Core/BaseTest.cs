using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Controller.Core;

namespace TravellerStudent.Test.Core
{
    public class BaseTest
    {
        protected ControllerContext _context;

        public BaseTest()
        {
            _context = new ControllerContext(new Model.Core.ContextInformation());
        }
    }
}
