using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class UserBusinessServices
    {
        //Prüfen
        UserDataServices dataServices;

        public UserBusinessServices()
        {
            dataServices = new UserDataServices();
        }

        public void AddUser(UserDto user)
        {
            dataServices.
        }
    }
}
