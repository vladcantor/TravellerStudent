using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model.Core
{
    public class BaseContext
    {
        private ContextInformation _contextInfo;
        public BaseContext(ContextInformation contextInfo)
        {
            _contextInfo = contextInfo;
        }
        public ContextInformation ContextInformation { get { return _contextInfo; } }
    }
}
