using System.Collections.Generic;
using TecAlliance.Carpool.Data.Model;

namespace TecAlliance.Carpool.Data.Services
{
    public class CarpoolDataServices
    {
        public List<CarpoolModel> SaveCarpools()
        {
            DirectoryInfo di = new DirectoryInfo("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools");
            int count = 0;
            if (di.GetFiles().Length == 0)
            {
                throw new Exception("Directory Is empty");
            }
            else
            {
                List<CarpoolModel> list = new List<CarpoolModel>();
                for (int i = 0; i < di.GetFiles().Length; i++)
                {
                    string[] lines = File.ReadAllLines($"C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools\\Carpools{count}.csv");
                    foreach (string line in lines)
                    {
                        CarpoolModel carpool = new CarpoolModel();
                        if (line == string.Empty)
                        {
                            return null;
                        }
                        else
                        {
                            string[] box = line.Split(';');

                            carpool.UserId = Convert.ToInt32(box[0]);
                            carpool.Name = box[1];
                            carpool.Nachname = box[2];
                            carpool.Anmeldename = box[3];
                            carpool.Gender = box[4];
                            carpool.Alter = Convert.ToInt32(box[5]);
                            carpool.AutoBezeichnung = box[6];
                            carpool.FreeSeat = Convert.ToInt32(box[7]);
                            carpool.Fahrers = Convert.ToBoolean(box[8]);
                            carpool.WohnOrt = box[9];
                            carpool.ZielOrt = box[10];
                            carpool.Abfahrtzeit = Convert.ToDateTime(box[11]);
                            list.Add(carpool);     
                        }
                    }
                    count++;
                }
                return list;
            }
            return null;
        }

        public void PostCarpool(CarpoolModel carpool)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools");
            int count = 0;
            for (int i = 0; i < di.GetFiles().Length; i++)
            {
                count++;
            }
            string str = $"{carpool.UserId};{carpool.Name};{carpool.Nachname};{carpool.Anmeldename};{carpool.Gender};{carpool.Alter};{carpool.AutoBezeichnung};{carpool.FreeSeat};{carpool.Fahrers};{carpool.WohnOrt};{carpool.ZielOrt};{carpool.Abfahrtzeit}";
            TextWriter fs = new StreamWriter($"C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools\\Carpools{count}.csv");
            char[] c = str.ToCharArray();
            fs.WriteLine(c);
            fs.Close();
            fs.Dispose();
        }
    }
}
