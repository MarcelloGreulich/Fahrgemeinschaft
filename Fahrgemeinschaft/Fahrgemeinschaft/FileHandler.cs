using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace Tecalliance.Carpool.Models
{
    internal class FileHandler
    {
        //Set all Properties
        public List<User> Users { get; set; }
        public bool Test { get; set; }
        public List<Carpool> Carpools { get; set; }
        public string Anmeldename { get; set; }
        public string Name { get; set; }
        public string Nachname { get; set; }
        public string Gender { get; set; }
        public string Alter { get; set; }
        public int FreeSeat { get; set; }
        public bool Join { get; set; }
        public string Passwort { get; set; }
        public UserInputCheck User { get; set; }

        //konstruktor for FileHandler class
        public FileHandler(List<User> users, List<Carpool> carpools)
        {
            Users = users;
            Test = false;
            Carpools = carpools;
            Anmeldename = "";
            Name = "";
            Nachname = "";
            Gender = "";
            Alter = "";
            Join = false;
            User = new UserInputCheck();
        }

        //Login for user and storing password and username in Propaties
        public void Anmeldung()
        {
            string anmeldename = User.CheckLoginInput("Bitte geben sie ihren Anmeldename an");
            Anmeldename = anmeldename;


            string passwort = User.CheckLoginInput("Bitte geben sie ihr Passwort an");
            Passwort = passwort;

            string[] lines = File.ReadAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv");


            foreach (string line in lines)
            {
                string[] huso = line.Split(';');
                try
                {
                    if (huso[3].Equals(anmeldename) && huso[2].Equals(passwort))
                    {
                        Console.WriteLine("Erfolgreich Angemeldet");
                        Test = true;
                        Name = huso[0];
                        Nachname = huso[1];
                        Gender = huso[4];
                        Alter = huso[5];
                    }
                }
                catch (Exception)
                { }

            }

            if (Test == false)
            {
                Console.Clear();
                Console.WriteLine("Passwort oder Anmeldename ist falsch");
                Anmeldung();
            }
            Console.Clear();
        }
        //Delete user from Userlist.csv and Carpool
        public void DeleteName()
        {
            //Delete User
            string anmeldename = User.CheckLoginInput("Bitte geben sie ihren Anmeldename an");

            string passwort = User.CheckLoginInput("Bitte geben sie ihr Passwort an");

            string[] lines = File.ReadAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv");
            StreamWriter fs = new StreamWriter("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv");
            foreach (string line in lines)
            {
                string[] huso = line.Split(';');
                try
                {
                    if (huso[3].Equals(anmeldename) && huso[2].Equals(passwort))
                    {
                        Test = true;
                    }
                    else { fs.WriteLine(line); }
                }
                catch (Exception) { }
            }
            fs.Close();
            fs.Dispose();
            if (Test == false)
            {
                Console.Clear();
                Console.WriteLine("Passwort oder Anmeldename ist falsch");
                DeleteName();
            }

            //Delete Carpools
            foreach (string file in Directory.EnumerateFiles("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools"))
            {

                List<string> str = new List<string>();
                int m = 0;
                string[] lüne = File.ReadAllLines(file);
                
                foreach (var item in lüne)
                {
                    str.Add(item);
                    string[] l = item.Split(';');
                    try
                    {
                        if (l[2].Equals(anmeldename))
                        {
                            str.RemoveAt(m);
                        }
                    }
                    catch (Exception) { }
                    m++;
                }
                File.WriteAllLines(file, str);
                try
                {
                    if (str.Count == 0)
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception) { }

            }

            Console.Clear();
        }
        //Add user as driver and creates Carpool csv
        public void BeADriver(List<Fahrer> fahrers)
        {
            Console.Clear();
            foreach (var fahrer in fahrers)
            {
                string str = (Name + ";" + Nachname + ";" + Anmeldename + ";" + Gender + ";" + Alter + ";" + fahrer.Abfahrtzeit.ToShortTimeString() + ";" + fahrer.Fahrers.ToString() + ";" + fahrer.WohnOrt + ";" + fahrer.ZielOrt + ";" + fahrer.AutoBezeichnung + " ; " + fahrer.FreeSeat.ToString());

                DirectoryInfo di = new DirectoryInfo("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools");
                int count = 0;
                for (int i = 0; i < di.GetFiles().Length; i++)
                {
                    count++;
                }
                TextWriter fs = new StreamWriter($"C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools\\Carpools{count}.csv");
                char[] c = str.ToCharArray();
                fs.WriteLine(c);
                fs.Close();
                fs.Dispose();
                Console.WriteLine(Name + " " + Nachname + " " + Anmeldename + " " + Gender + " " + Alter + " " + fahrer.Abfahrtzeit.ToShortTimeString() + " " + fahrer.Fahrers.ToString() + " " + fahrer.WohnOrt + " " + fahrer.ZielOrt + " " + fahrer.AutoBezeichnung + " " + fahrer.FreeSeat.ToString() + "\n");
                FreeSeat = fahrer.FreeSeat;
            }


        }
        //Add user as passenger in Carpool csv
        public void BeABeifahrer(List<Beifahrer> beifahrers)
        {
            Console.Clear();
            foreach (string file in Directory.EnumerateFiles("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools"))
            {
                string[] lines = File.ReadAllLines(file);
                //Carpool check seats and add user
                var line = lines.Last();
                Console.Clear();
                string title = @" 
 __________      ______                                     _____                    ______        ____________             
 ___  ____/_____ ___  /_______________ ____________ ___________(_)______________________  /_______ ___  __/_  /
 __  /_   _  __ `/_  __ \_  ___/_  __ `/  _ \_  __ `__ \  _ \_  /__  __ \_  ___/  ___/_  __ \  __ `/_  /_ _  __/  
 _  __/   / /_/ /_  / / /  /   _  /_/ //  __/  / / / / /  __/  / _  / / /(__  )/ /__ _  / / / /_/ /_  __/ / /_ 
 /_/      \__,_/ /_/ /_//_/    _\__, / \___//_/ /_/ /_/\___//_/  /_/ /_//____/ \___/ /_/ /_/\__,_/ /_/    \__/ 
                               /____/  
 ________________________________________________________________________________________________________________  
";
                Console.WriteLine(title);
                bool prof = false;
                foreach (var item in lines)
                {
                    try
                    {
                        string[] l = item.Split(';');
                        if (l[5].Equals(beifahrers.Last().Abfahrtzeit.ToShortTimeString()) && l[7].Equals(beifahrers.Last().WohnOrt) && l[8].Equals(beifahrers.Last().ZielOrt))
                        {
                            Console.WriteLine(item);
                            prof = true;
                        }
                        else
                        {
                            prof = false;
                        }

                    }
                    catch (Exception)
                    { }
                }
                if (prof==true)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("wollen sie dieser fahrgemeinschaft beitreten? y/n");
                    string str = Console.ReadLine();

                    switch (str)
                    {
                        case "y":
                            Join = true;
                            break;
                        case "n":
                            Join = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Es gibt noch keine Fahrgemeinschaft zu diesen Bedingungen");
                    Thread.Sleep(1500);
                }
            }

            foreach (string file in Directory.EnumerateFiles("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools"))
            {
                string[] lines = File.ReadAllLines(file);
                var line = lines.Last();

                if (line != null && line != "")
                {
                    string[] l = line.Split(';');
                    if (l[5].Equals(beifahrers.Last().Abfahrtzeit.ToShortTimeString()) && l[7].Equals(beifahrers.Last().WohnOrt) && l[8].Equals(beifahrers.Last().ZielOrt))
                    {
                        if (Join == true)
                        {
                            FreeSeat = Convert.ToInt32(l[10]);
                            if (Convert.ToInt32(l[10]) > 0)
                            {
                                FileStream fs = new FileStream(file, FileMode.Append);
                                string user = (Name + ";" + Nachname + ";" + Anmeldename + ";" + Gender + ";" + Alter + ";" + beifahrers.Last().Abfahrtzeit.ToShortTimeString() + ";" + beifahrers.Last().Fahrers.ToString() + ";" + beifahrers.Last().WohnOrt + ";" + beifahrers.Last().ZielOrt + ";" + "none" + ";" + (FreeSeat - 1).ToString() + "\n");
                                Console.Write("Sie sind der Fahrgemeinschaft beigetreten");
                                byte[] buffer = Encoding.Default.GetBytes(user);
                                fs.Write(buffer, 0, buffer.Length);
                                fs.Close();
                                fs.Dispose();
                            }
                            else
                            {
                                Console.WriteLine("Die Fahrgemeinschaft ist bereits voll");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sie sind nicht beigetreten");
                        }
                    }


                }
            }
        }
        //Change Info from user in UserList.csv
        public void ChangeInfo()
        {
            string[] lines = File.ReadAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv");
            List<string> newL = new List<string>();
            int f = 0;
            foreach (var line in lines)
            {
                newL.Add(line);
                if (line.Contains(Anmeldename) && line.Contains(Passwort))
                {
                    string[] l = line.Split(';');
                    Console.WriteLine($"Welche Information wollen sie ändern? \n" +
                        $" [1]Name: {l[0]} {l[1]}\n" +
                        $" [2]Anmeldename: {l[3]} \n" +
                        $" [3]Passwort: {l[2]}\n" +
                        $" [4]Geschlecht: {l[4]}\n" +
                        $" [5]Alter: {l[5]}\n" +
                        $" [6]Zurück");
                    int w = Convert.ToInt32(Console.ReadLine());

                    switch (w)
                    {
                        case 1:
                            Console.WriteLine("bitte geben Sie ihren Vornamen ein");
                            string name = Console.ReadLine();

                            Console.WriteLine("bitte geben Sie ihren Nachnamen ein");
                            string nachname = Console.ReadLine();

                            l[0] = name;
                            l[1] = nachname;
                            break;
                        case 2:
                            Console.WriteLine("Bitte neuen Anmeldenamen Eingeben");
                            string an = Console.ReadLine();

                            l[3] = an;
                            break;
                        case 3:
                            Console.WriteLine("Bitte neues Passwort Eingeben");
                            string pw = Console.ReadLine();

                            l[2] = pw;
                            break;
                        case 4:
                            Console.WriteLine("Bitte geben sie ihr neues Geschlecht ein");
                            Console.WriteLine("(1) Männlich");
                            Console.WriteLine("(2) Weiblich");
                            Console.WriteLine("(3) Diverse");
                            int i = Convert.ToInt32(Console.ReadLine());
                            string gender = " ";
                            switch (i)
                            {
                                case 1:
                                    gender = "Männlich";
                                    break;
                                case 2:
                                    gender = "Weiblich";
                                    break;
                                case 3:
                                    gender = "Diverse";
                                    break;
                            }

                            l[4] = gender;
                            break;
                        case 5:
                            Console.WriteLine("Bitte geben sie ihr Alter an");
                            string al = Console.ReadLine();

                            l[2] = al;
                            break;
                    }

                    newL.RemoveAt(f);
                    newL.Add(l[0] + ";" + l[1] + ";" + l[2] + ";" + l[3] + ";" + l[4] + ";" + l[5]);
                }
                f++;
            }
            File.WriteAllLines("C:\\010 Projects\\020 Fahrgemeinschaft\\UserList.csv", newL);
            Console.Clear();
        }
        //Prints every Carpool the user is included
        public void ShowCarpools()
        {
            foreach (string file in Directory.EnumerateFiles("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools"))
            {  
                string[] lines = File.ReadAllLines(file);

                foreach (var item in lines)
                {
                    string[] l = item.Split(';');
                    try
                    {
                        if (l[2].Equals(Anmeldename))
                        {
                            Console.WriteLine("----------------------------Fahrgemeinschaft----------------------------");
                            string[] liner = File.ReadAllLines(file);
                            foreach (var i in liner)
                            {
                                string[] x = i.Split(';');
                                if (Convert.ToBoolean(x[6]) == true)
                                {
                                    Console.Write("Von: " + x[7] + " Bis: " + x[8] + " Uhr: " + x[5] + "\n" +
                                    "Fahrer: " + x[0] + " " + x[1] + " Alter: " + x[4] + " Geschlecht: " + x[3] + " Auto: " + x[9] + "\n");
                                }
                                else
                                {
                                    Console.WriteLine("Beifahrer: " + x[0] + " " + x[1] + " Alter: " + x[4] + " Geschlecht: " + x[3] + "\n");
                                }
                            }
                        }
                    }
                    catch (Exception) { }

                }
            }
        }
        //Ask user for the right carpool and delte user from it
        //also the Carpool file gets deleted if it is empty
        public void LeaveCarpool()
        {

            foreach (string file in Directory.EnumerateFiles("C:\\010 Projects\\020 Fahrgemeinschaft\\Carpools"))
            {
                Console.Clear();
                string[] lines = File.ReadAllLines(file);

                foreach (var item in lines)
                {
                    string[] l = item.Split(';');
                    try
                    {
                        if (l[2].Equals(Anmeldename))
                        {
                            Console.Clear();
                            string title7 = @" 
  ___    __           ______                                 
  __ |  / /______________  /_____ __________________________ 
  __ | / /_  _ \_  ___/_  /_  __ `/_  ___/_  ___/  _ \_  __ \
  __ |/ / /  __/  /   _  / / /_/ /_(__  )_(__  )/  __/  / / /
  _____/  \___//_/    /_/  \__,_/ /____/ /____/ \___//_/ /_/ 
  __________________________________________________________

";
                            Console.WriteLine(title7);
                            Console.WriteLine("----------------------------Fahrgemeinschaft----------------------------");
                            Console.WriteLine("");
                            string[] liner = File.ReadAllLines(file);
                            foreach (var i in liner)
                            {
                                string[] x = i.Split(';');
                                if (Convert.ToBoolean(x[6]) == true)
                                {
                                    Console.Write("Von: " + x[7] + " Bis: " + x[8] + " Uhr: " + x[5] + "\n" +
                                    "Fahrer: " + x[0] + " " + x[1] + " Alter: " + x[4] + " Geschlecht: " + x[3] + " Auto: " + x[9] + "\n");
                                }
                                else
                                {
                                    Console.WriteLine("Beifahrer: " + x[0] + " " + x[1] + " Alter: " + x[4] + " Geschlecht: " + x[3] + "\n");
                                }




                            }
                        }
                    }
                    catch (Exception) { }

                }
                string anw = User.CheckStringInput("Möchten sie diese Fahrgemeinschaft  verlassen? y/n");
                if (anw == "y")
                {
                    List<string> str = new List<string>();
                    int m = 0;
                    string[] lüne = File.ReadAllLines(file);

                    foreach (var j in lüne)
                    {
                        str.Add(j);
                        string[] c = j.Split(';');
                        try
                        {
                            if (c[2].Equals(Anmeldename))
                            {
                                str.RemoveAt(m);
                            }
                        }
                        catch (Exception) { }
                        m++;
                    }
                    File.WriteAllLines(file, str);
                    try
                    {
                        if (str.Count == 0)
                        {
                            File.Delete(file);
                        }
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}



