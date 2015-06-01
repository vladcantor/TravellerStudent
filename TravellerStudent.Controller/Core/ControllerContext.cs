using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Controller.Core
{
    public class ControllerContext
    {
        #region Members
        protected Lazy<ControllerObjectContainer> _controllerContainer;
        protected Lazy<RepositoryObjectContainer> _repositoryContainer;
        #endregion Members

        #region Constructors
        public ControllerContext(BaseContext context)
        {
            _controllerContainer = new Lazy<ControllerObjectContainer>(() => new ControllerObjectContainer(this));
            _repositoryContainer = new Lazy<RepositoryObjectContainer>(() => new RepositoryObjectContainer(new RepositoryContext(context)));
        }
        #endregion Constructors

        #region Properties
        public ControllerObjectContainer Controller { get { return _controllerContainer.Value; } }
        internal RepositoryObjectContainer Repository { get { return _repositoryContainer.Value; } }
        #endregion Properties

    }
}
