using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Repository.Core
{
    public class RepositoryObjectContainer : BaseObjectContainer
    {
        #region Members
        private RepositoryContext _context;
        private Lazy<UserRepository> _userRepository;
        #endregion Members

        #region Constructors
        public RepositoryObjectContainer(RepositoryContext context)
        {
            _context = context;
            InitializeMembers();
        }
        #endregion Constructors

        #region Properties
        public UserRepository User { get { return _userRepository.Value; } }
        #endregion Properties

        #region Methods
        #region Protected
        protected override void InitializeMembers()
        {
            _userRepository = new Lazy<UserRepository>(() => new UserRepository(_context));
        }
        #endregion Protected
        #endregion Methods

    }
}
