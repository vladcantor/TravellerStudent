using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Controller.Core
{
    public class ControllerContext:BaseContext
    {
        #region Members
        protected Lazy<ControllerObjectContainer> _controllerContainer;
        protected Lazy<RepositoryContext> _repositoryContext;
        #endregion Members

        #region Constructors
        public ControllerContext(ContextInformation contextInfo):base(contextInfo)
        {
            _controllerContainer = new Lazy<ControllerObjectContainer>(() => new ControllerObjectContainer(this));
            _repositoryContext = new Lazy<RepositoryContext>(() => new RepositoryContext(contextInfo));
        }
        #endregion Constructors

        #region Properties
        public ControllerObjectContainer Controller { get { return _controllerContainer.Value; } }
        internal RepositoryObjectContainer Repository { get { return _repositoryContext.Value.Repository; } }
        #endregion Properties

    }
}
