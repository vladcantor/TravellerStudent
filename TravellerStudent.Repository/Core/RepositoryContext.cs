using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Repository.Core
{
    public class RepositoryContext:BaseContext
    {
        #region Members
        protected Lazy<RepositoryObjectContainer> _objectContainer;
        #endregion Members

        #region Constructors
        public RepositoryContext(ContextInformation contextInfo):base(contextInfo)
        {
            _objectContainer = new Lazy<RepositoryObjectContainer>(() => new RepositoryObjectContainer(this));
        }
        #endregion Constructors

        #region Properties
        public RepositoryObjectContainer Repository { get { return _objectContainer.Value; } }
        public string ConnectionString { get { return "Data Source=VMVLAD;Initial Catalog=TravellerStudent;Integrated Security=True"; } }
        #endregion Properties
    }
}
