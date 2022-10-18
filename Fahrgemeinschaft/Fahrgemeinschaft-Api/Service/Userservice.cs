using System.Text;
using Tecalliance.Carpool.Models;
using TecAlliance.Carpool.Api.Models;

namespace TecAllience.Carpool.Api.Service
{
    public class Userservice
    {
        //add user to UserList.csv
        public void AddName()
        {
            
            FileStream fs = new FileStream("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv", FileMode.Append);
            string user = users.Last().Name + ";" + users.Last().Nachname + ";" + users.Last().Anmeldename + ";" + users.Last().Passwort + ";" + users.Last().Gender + ";" + users.Last().Alter.ToString() + ";" + "\n";
            byte[] buffer = Encoding.Default.GetBytes(user);
            fs.Write(buffer, 0, buffer.Length);
            Console.Clear();
            Console.WriteLine("Registrierung Erfolgreich!");
            Thread.Sleep(1500);
            Console.Clear();
            fs.Close();
            fs.Dispose();
        }
    }
}
