using System.Text;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class UserDataServices
    {
        //Daten Schreiben und ausgeben 
        public List<User> SaveUser()
        {
            List<User> list = new List<User>();
            string[] lines = File.ReadAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv");
            foreach (string line in lines)
            {
                User user = new User();
                string[] box = line.Split(';');

                user.Id = Convert.ToInt32(box[0]);
                user.Name = box[1];
                user.Nachname = box[2];
                user.Anmeldename = box[3];
                user.Passwort = box[4];
                user.Gender = box[5];
                user.Alter = Convert.ToInt32(box[6]);
                list.Add(user);
            }
            return list;
        }

        public void AddUser(User user)
        {
            //Create File Stream
            FileStream fs = new FileStream("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv", FileMode.Append);
            //Convert user to string
            string userString = $"{user.Id};{user.Name};{user.Nachname};{user.Anmeldename};{user.Passwort};{user.Gender};{user.Alter}; \n";
            //Prepare user string for writing
            byte[] buffer = Encoding.Default.GetBytes(userString);
            //Write user in UserList.csv
            fs.Write(buffer, 0, buffer.Length);
            //close and dispose File stream
            fs.Close();
            fs.Dispose();
        }

    }
}
