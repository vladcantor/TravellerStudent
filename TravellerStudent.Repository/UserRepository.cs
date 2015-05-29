using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        #region Constants
        #endregion Constants
        private const string TRAVELLERSTUDENT_USERS_INSERT = "dbo.TravellerStudent_Users_Insert";
        #region Constructors
        public UserRepository(RepositoryContext context)
            : base(context) { }
        #endregion Constructors

        #region Methods
        public void Add(User user) {
            SqlParameter[] param = {
                                     new SqlParameter("@UserGUID", SqlDbType.UniqueIdentifier){Value = user.UserUid},
                                     new SqlParameter("@LoginName", SqlDbType.NVarChar, 100){Value = user.LoginName},
                                     new SqlParameter("@Name", SqlDbType.NVarChar, 100){Value = user.Name},
                                     new SqlParameter("@UserType", SqlDbType.SmallInt){Value = user.UserType}
                    };
            ExecuteCommand(TRAVELLERSTUDENT_USERS_INSERT, param);
        }

        protected override User ReaderToModel(System.Data.SqlClient.SqlDataReader reader)
        {
            return new User
            {
                LoginName = reader.GetString(reader.GetOrdinal("LoginName")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                UserType = (UserType)reader.GetInt16(reader.GetOrdinal("UserType")),
                UserUid = reader.GetGuid(reader.GetOrdinal("UserGUID"))

            };
        }
        #endregion Methods
    }
}
