using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellerStudent.Controller.Core;
using TravellerStudent.Model.Core;

namespace TravellerStudentServer.Core
{
    public class BaseService : System.Web.Services.WebService
    {
        #region Members
        protected Lazy<ControllerContext> _context;
        #endregion Members

        #region Constructors
        public BaseService()
            : base()
        {
            _context = new Lazy<ControllerContext>(() => new ControllerContext(
                GetContextInformation()));
        }

        private ContextInformation GetContextInformation()
        {
            if (Context.Request.Headers.AllKeys.Contains("Token"))
            {
                return new ContextInformation { 
                    CurrentUsername = DecodeToke(Context.Request.Headers["Token"])
                };
            }
            return null;
        }

        private string DecodeToke(string token)
        {
            return token;
        }
        #endregion Constructors

        #region Properties

        #endregion Properties
    }
}