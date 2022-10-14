using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Fahrgemeinschaft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInputCheck user=new UserInputCheck();
            string title = @"         
 __________      ______                                     _____                    ______        ____________ 
 ___  ____/_____ ___  /_______________ ____________ ___________(_)______________________  /_______ ___  __/_  /_
 __  /_   _  __ `/_  __ \_  ___/_  __ `/  _ \_  __ `__ \  _ \_  /__  __ \_  ___/  ___/_  __ \  __ `/_  /_ _  __/
 _  __/   / /_/ /_  / / /  /   _  /_/ //  __/  / / / / /  __/  / _  / / /(__  )/ /__ _  / / / /_/ /_  __/ / /_  
 /_/      \__,_/ /_/ /_//_/    _\__, / \___//_/ /_/ /_/\___//_/  /_/ /_//____/ \___/ /_/ /_/\__,_/ /_/    \__/  
                               /____/                                       
________________________________________________________________________________________________________________
                                                                                 ";

            Console.WriteLine(title);
            //Ask for number input for Registraton, Login or deleting user
            int count = user.CheckIntInput("Wählen sie eine Option \n(1) Registrieren \n(2) Anmelden \n(3) Löschen");

            FileHandler file = new FileHandler(null,null);
            switch (count)
            {
                //Registraton user
                case 1:
                    Console.Clear();
                    string title8 = @" 
 ________             _____       _____       _____                                   
 ___  __ \___________ ___(_)________  /__________(_)_______________  _______________ _
 __  /_/ /  _ \_  __ `/_  /__  ___/  __/_  ___/_  /_  _ \_  ___/  / / /_  __ \_  __ `/
 _  _, _//  __/  /_/ /_  / _(__  )/ /_ _  /   _  / /  __/  /   / /_/ /_  / / /  /_/ / 
 /_/ |_| \___/_\__, / /_/  /____/ \__/ /_/    /_/  \___//_/    \__,_/ /_/ /_/_\__, /  
              /____/                                                         /____/    
 _______________________________________________________________________ 
";
                    Console.WriteLine(title8);
                    file = new FileHandler(CreateUser(), null);
                    file.AddName();
                    Usercoice(file);
                    break;
                    //Login user
                case 2:
                    Console.Clear();
                    string title7 = @" 
 _______                       ______________                          
 ___    |_____________ ___________  /_____  /___  ________ __________ _
 __  /| |_  __ \_  __ `__ \  _ \_  /_  __  /_  / / /_  __ `__ \_  __ `/
 _  ___ |  / / /  / / / / /  __/  / / /_/ / / /_/ /_  / / / / /  /_/ / 
 /_/  |_/_/ /_//_/ /_/ /_/\___//_/  \__,_/  \__,_/ /_/ /_/ /_/_\__, /  
                                                              /____/   
 _______________________________________________________________________ 
";
                    Console.WriteLine(title7);
                    file.Anmeldung();
                    Usercoice(file);
                    break;
                case 3:
                    //Delete user
                    Console.Clear();
                    string title9 = @" 
 ______ ______            ________              
 ___  / _(_)(_)________________  /_____________ 
 __  /  _  __ \_  ___/  ___/_  __ \  _ \_  __ \
 _  /___/ /_/ /(__  )/ /__ _  / / /  __/  / / /
 /_____/\____//____/ \___/ /_/ /_/\___//_/ /_/    
 _______________________________________________________________________ 
";
                    Console.WriteLine(title9);
                    file.DeleteName();
                    Console.WriteLine("Ihr Account wurde Gelöscht!");
                    Console.ReadLine();
                    Main(args);
                    break;
                    default:
                        Main(args);
                    return;
            }
            Console.ReadKey();

        }

        //Creates User in UserList.csv
        static public List<User> CreateUser()
        {
            UserInputCheck user = new UserInputCheck();

            //Ask user for information
            string name = user.CheckStringInput("bitte geben Sie ihren Vornamen ein");

            string nachname = user.CheckStringInput("bitte geben Sie ihren Nachnamen ein");

            string anmeldename = user.CheckStringInput("bitte geben Sie ihren Anmeldename ein");

            string passwort = user.CheckLoginInput("Bitte wählen sie ein Passwort");

            int i = user.CheckIntInput("Welches Geschlecht haben sie\n(1) Männlich\n(2) Weiblich\n(3) Diverse");
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

            int alter = user.CheckIntInput("Wie alt sind sie?");

            List<User> list = new List<User>();
 
            list.Add(new User(name, nachname, passwort, anmeldename, gender, alter));
           
            return list;
        }
        //Creates Driver in Carpool
        public static List<Fahrer> CreateFahrer()
        {
            UserInputCheck user = new UserInputCheck();
            //Ask user for Carpoll information
            string auto = user.CheckStringInput("Welches Auto fahren sie?");

            int sitze = user.CheckIntInput("Wie Viele freie Sitze haben sie?");

            string wohnort = user.CheckStringInput("Von wo aus möchten sie Starten");

            string zielort = user.CheckStringInput("Wo möchten sie hin?");

            DateTime abfarhtzrit = user.CheckDateTimeInput("Wann wollen Sie losfahren?");

            List<Fahrer> fahrer = new List<Fahrer>();
            fahrer.Add(new Fahrer(abfarhtzrit, true, wohnort, zielort, auto, sitze));

            return fahrer;

        }
        //Creates and Append passenger to Carpool
        public static List<Beifahrer> CreateBeifahrer()
        {
            UserInputCheck user = new UserInputCheck();
            //ask user for information
            string wohnort = user.CheckStringInput("Von wo aus möchten sie Starten");

            string zielort = user.CheckStringInput("Wo möchten sie hin?");

            DateTime abfarhtzrit = user.CheckDateTimeInput("Wann wollen Sie losfahren?");

            List<Beifahrer> beifahrers = new List<Beifahrer>();
            beifahrers.Add(new Beifahrer(abfarhtzrit, false, wohnort, zielort));

            return beifahrers;

        }
        //After register or Login for the user to choose Options
        public static void Usercoice( FileHandler file)
        {
            UserInputCheck user = new UserInputCheck();

            string title2 = @" 
 _______                               ______ ______
 ___    |___  ___________      _______ ___  /____  /
 __  /| |  / / /_  ___/_ | /| / /  __ `/_  __ \_  / 
 _  ___ / /_/ /_(__  )__ |/ |/ // /_/ /_  / / /  /  
 /_/  |_\__,_/ /____/ ____/|__/ \__,_/ /_/ /_//_/ 
 ____________________________________________________  
";
            Console.WriteLine(title2);
            //Ask user for number to select Menu point
            int count = user.CheckIntInput("(1) Sei ein Fahrer\n(2) Sei ein Beifahrer\n(3) Informationen ändern\n(4) Fahrgemeinschaft anzeigen\n(5) Fahrgemeinschaft verlassen\n(6) Ausloggen");
            switch (count)
            {
                //Creates driver
                case 1:
                    Console.Clear();
                    string title5 = @" 
 __________             _____     ___________            
 ___  ____/_______________  /________  /__  /___________ 
 __  __/  __  ___/_  ___/  __/  _ \_  /__  /_  _ \_  __ \
 _  /___  _  /   _(__  )/ /_ /  __/  / _  / /  __/  / / /
 /_____/  /_/    /____/ \__/ \___//_/  /_/  \___//_/ /_/ 
 ________________________________________________________  
";
                    Console.WriteLine(title5);
                    Console.WriteLine("Du bist nun ein Fahrer");
                    file.BeADriver(CreateFahrer());
                    Console.Clear();
                    Usercoice(file);
                    break;
                    //Join a Carpool as Passenger
                case 2:
                    Console.Clear();
                    string title6 = @" 
 ________     __________            _____             
 ___  __ )_______(_)_  /______________  /____________ 
 __  __  |  _ \_  /_  __/_  ___/  _ \  __/  _ \_  __ \
 _  /_/ //  __/  / / /_ _  /   /  __/ /_ /  __/  / / /
 /_____/ \___//_/  \__/ /_/    \___/\__/ \___//_/ /_/  
 ______________________________________________________  
";
                    Console.WriteLine(title6);
                    Console.WriteLine("Du bist nun ein Beifahrer");
                    file.BeABeifahrer(CreateBeifahrer());
                    Console.Clear();
                    Usercoice(file);
                    break;
                    //Change User Information
                case 3:
                    Console.Clear();
                    string title4 = @" 
 ________      ________      
 ____  _/_________  __/_____ 
  __  / __  __ \_  /_ _  __ \
 __/ /  _  / / /  __/ / /_/ /
 /___/  /_/ /_//_/    \____/  
 ____________________________
";
                    Console.WriteLine(title4);
                    file.ChangeInfo();
                    Console.Clear();
                    Usercoice(file);
                    break;
                    //Print all Carfrom user
                case 4:
                    Console.Clear();
                    string title3 = @" 
 _____  _______                    _____      ______ _____ 
 __(_) (_)__  /_______________________(_)________  /___  /_
 _  / / /__  __ \  _ \_  ___/_  ___/_  /_  ___/_  __ \  __/
 / /_/ / _  /_/ /  __/  /   _(__  )_  / / /__ _  / / / /_  
 \____/  /_.___/\___//_/    /____/ /_/  \___/ /_/ /_/\__/  
 __________________________________________________________  
";
                    Console.WriteLine(title3);
                    file.ShowCarpools();
                    Console.ReadKey();
                    Console.Clear();
                    Usercoice(file);
                    break;
                    //leave and if file empty delete Carpool fle
                case 5:

                    file.LeaveCarpool();
                    Thread.Sleep(1500);
                    Console.Clear();
                    Usercoice(file);
                    break;
                    //Logout
                case 6:
                    Console.WriteLine("Sie sind Angemeldet");
                    Thread.Sleep(2000);
                    break;
                default:
                    Usercoice(file);
                    break;
            }

        }
    }
}
