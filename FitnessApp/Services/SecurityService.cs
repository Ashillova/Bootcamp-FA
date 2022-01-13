using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Services
{
    public class SecurityService
    {

        List<Login> knownUsers = new List<Login>();
        public SecurityService()
        {
            knownUsers.Add(new Login { ID = 0, Username = "Ardit", Password = "Shillova" });
            knownUsers.Add(new Login { ID = 1, Username = "Ardit1", Password = "Shillova1" });
            knownUsers.Add(new Login { ID = 2, Username = "Ardit2", Password = "Shillova2" });
            knownUsers.Add(new Login { ID = 3, Username = "Ardit3", Password = "Shillova3" });
        }

        public bool IsValid(Login login)
        {
            return knownUsers.Any(x => x.Username == login.Username && x.Password == login.Password);
        }

    }
}