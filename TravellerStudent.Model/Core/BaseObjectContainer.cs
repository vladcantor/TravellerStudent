using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model.Core
{
    public abstract class BaseObjectContainer
    {
        #region Members
        private Dictionary<Type, BaseObjectContainer> _baseObjectInstances = new Dictionary<Type, BaseObjectContainer>();
        #endregion Members

        #region Methods

        /// <summary>
        /// This method is the generic method used to return a Base object.
        /// </summary>
        /// <typeparam name="TObject">The type is generic and needs to be specified when calling this class.</typeparam>
        /// <returns>An object derived from <see cref="TravellerStudent.Model.Core.BaseObjectContainer"/>.</returns>
        protected TObject GetObject<TObject>(ContextInformation contextInfo) where TObject : BaseObjectContainer
        {
            Type genericBaseObjectType = typeof(TObject);
            if (_baseObjectInstances.ContainsKey(genericBaseObjectType))
            {
                return (TObject)_baseObjectInstances[genericBaseObjectType];
            }
            TObject baseObject = (TObject)Activator.CreateInstance(genericBaseObjectType, contextInfo);
            _baseObjectInstances.Add(genericBaseObjectType, baseObject);
            return baseObject;
        }
        protected abstract void InitializeMembers();
        #endregion Methods
    }
}
