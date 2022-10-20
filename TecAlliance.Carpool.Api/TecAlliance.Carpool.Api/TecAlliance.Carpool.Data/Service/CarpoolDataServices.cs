using System.Text;
using TecAlliance.Carpool.Data.Model;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataServices
    {
        public List<CarpoolModel> SaveCarpools()
        {
            List<CarpoolModel> list = new List<CarpoolModel>();

            string[] lines = File.ReadAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools\\Carpools.csv");
            foreach (string line in lines)
            {
                CarpoolModel carpool = new CarpoolModel();
                if (line == string.Empty)
                {
                    return null;
                }
                else
                {
                    UserInfo driver = new UserInfo();
                    UserInfo passangerid = new UserInfo();
                    string[] box = line.Split(';');
                    carpool.CarpoolId = Convert.ToInt32(box[0]);
                    carpool.CarDesignation = box[1];
                    carpool.FreeSeat = Convert.ToInt32(box[2]);
                    carpool.StartPoint = box[3];
                    carpool.EndPoint = box[4];
                    carpool.DepartureTime = Convert.ToDateTime(box[5]);
                    driver.Id = Convert.ToInt32(box[6]);
                    driver.Name = "";
                    driver.IsDriver = true;
                    carpool.Drivers = driver;
                    List<UserInfo> pasgList = new List<UserInfo>();
                    for (int i = 7; i < box.Length-1; i++)
                    {
                        passangerid.Id = Convert.ToInt32(box[i]);
                        passangerid.Name = "";
                        passangerid.IsDriver = false;
                        pasgList.Add(passangerid);
                    }
                    carpool.Passengers = pasgList;

                }
                list.Add(carpool);
            }

            return list;
        }

        public void PostCarpool(List<CarpoolModel> carpoolList)
        {
            //Create File Stream
            FileStream fs = new FileStream("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools\\Carpools.csv", FileMode.Create);
            foreach (var carpool in carpoolList)
            {
                //Convert user to string 
                List<string> str = new List<string>();
                string userString = $"{carpool.CarpoolId};{carpool.CarDesignation};{carpool.FreeSeat};{carpool.StartPoint};{carpool.EndPoint};{carpool.DepartureTime};{carpool.Drivers.Id};";
                //Prepare user string for writing
                byte[] buffer = Encoding.Default.GetBytes(userString);
                //Write user in UserList.csv
                fs.Write(buffer, 0, buffer.Length);
                if (carpool.Passengers != null)
                {
                    foreach (var item in carpool.Passengers)
                    {
                        userString = $"{item.Id};";
                        buffer = Encoding.Default.GetBytes(userString);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    buffer = Encoding.Default.GetBytes("\n");
                    fs.Write(buffer);
                }
            }
            //close and dispose File stream
            fs.Close();
            fs.Dispose();
        }
    }
}
