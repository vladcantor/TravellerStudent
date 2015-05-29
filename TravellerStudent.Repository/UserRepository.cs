using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Repository
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository(RepositoryContext context)
            : base(context)
        { 
           
        }

        protected override User ReaderToModel(System.Data.SqlClient.SqlDataReader reader)
        {
            return new User { 
            LoginName = reader.GetString(reader.GetOrdinal("LoginName")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            UserType = (UserType)reader.GetInt16(reader.GetOrdinal("UserType")),
            UserUid = reader.GetGuid(reader.GetOrdinal("UserGUID"))

            };
        }
    }
}
