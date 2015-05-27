using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;
using TravellerStudent.Repository.Core;

namespace TravellerStudent.Repository
{
    public class UserRepository:BaseRepository
    {
        public UserRepository(BaseContext context):base(context)
        { 
           
        }
    }
}
