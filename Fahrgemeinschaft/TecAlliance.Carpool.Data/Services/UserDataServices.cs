using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class UserDataServices
    {
        //Daten Schreiben und ausgeben 

        public void AddUser(User user)
        {
            FileStream fs = new FileStream("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv", FileMode.Append);
            string userString = user.ToString();
            byte[] buffer = Encoding.Default.GetBytes(userString);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            fs.Dispose();
        }

    }
}
