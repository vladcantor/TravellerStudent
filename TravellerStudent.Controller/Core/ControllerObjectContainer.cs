using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Controller.Core
{
    public class ControllerObjectContainer:BaseObjectContainer
    {
          #region Members
        private ControllerContext _context;
        private Lazy<UserController> _userRepository;
        #endregion Members

        #region Constructors
        public ControllerObjectContainer(ControllerContext context)
        {
            _context = context;
            InitializeMembers();
        }
        #endregion Constructors

        #region Properties
        public UserController User { get { return _userRepository.Value; } }
        #endregion Properties

        #region Methods
        #region Protected
        protected override void InitializeMembers()
        {
            _userRepository = new Lazy<UserController>(() => new UserController(_context));
        }
        #endregion Protected
        #endregion Methods

        #region IDisposable
        public void Dispose()
        {
            return;
        }
        #endregion IDisposable
    }
}
