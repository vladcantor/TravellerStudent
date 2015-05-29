using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravellerStudent.Test.Core;
using TravellerStudent.Model;

namespace TravellerStudent.Test
{
    [TestClass]
    public class UserTests : BaseTest
    {
        [TestMethod]
        public void TestAddUser()
        {
            User user = new User
            {
                UserUid = Guid.NewGuid(),
                LoginName = "user",
                Name = "Gigel",
                UserType = UserType.Student
            };

            _context.Controller.User.Add(user);
        }
    }
}
