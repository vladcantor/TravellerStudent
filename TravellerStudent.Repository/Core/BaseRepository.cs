using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Repository.Core
{
    public class BaseRepository
    {
        #region Members
        protected RepositoryObjectContainer _context;
        #endregion Members

        #region Constructors
        public BaseRepository(BaseContext context)
        {
            _context = ContextInitializer.GetObject<RepositoryObjectContainer>(context);
        }
        #endregion Constructors
    }
}
