using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellerStudent.Model.Core
{
    public sealed class ContextInitializer
    {
        #region Members
        private static Dictionary<Type, BaseObjectContainer> _baseObjectInstances = new Dictionary<Type, BaseObjectContainer>();
        #endregion Members

        #region Methods
        /// <summary>
        /// This method is the generic method used to return a Base object.
        /// </summary>
        /// <typeparam name="TObject">The type is generic and needs to be specified when calling this class.</typeparam>
        /// <returns><see cref="QuizEngine.Infrastructure.BaseObject<T>"/></returns>
        public static TObject GetObject<TObject>(BaseContext context) where TObject : BaseObjectContainer
        {
            Type genericBaseObjectType = typeof(TObject);
            if (_baseObjectInstances.ContainsKey(genericBaseObjectType))
            {
                return (TObject)_baseObjectInstances[genericBaseObjectType];
            }
            TObject baseObject = (TObject)Activator.CreateInstance(genericBaseObjectType, context);
            _baseObjectInstances.Add(genericBaseObjectType, baseObject);
            return baseObject;
        }
        #endregion Methods
    }
}
