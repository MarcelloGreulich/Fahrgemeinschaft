using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    //Prüfen
    public class UserBusinessServices
    {
        //Global
        UserDataServices dataServices;

        //Constructor
        public UserBusinessServices()
        {
            dataServices = new UserDataServices();
        }
        //
        public void AddUser(UserDto user)
        {
            //Add converted user to DataServices
            user.Id = GetId();
            dataServices.AddUser(ConvertIntoUser(user));
        }


        //Converts UserDto to User Model from DataServices
        public User ConvertIntoUser(UserDto user)
        {

            User newUser = new User();
            newUser.Id = user.Id;
            newUser.Name = user.Name;
            newUser.Nachname = user.Nachname;
            newUser.Anmeldename = user.Anmeldename;
            newUser.Passwort = user.Passwort;
            newUser.Gender = user.Gender;
            newUser.Alter = user.Alter;

            return newUser;
        }
        //Converts User to UserDto Model from DataServices
        public UserDto ConvertIntoUserDto(User user)
        { 
            UserDto newUser = new UserDto();
            newUser.Id = user.Id;
            newUser.Name = user.Name;
            newUser.Nachname = user.Nachname;
            newUser.Anmeldename = user.Anmeldename;
            newUser.Passwort = user.Passwort;
            newUser.Gender = user.Gender;
            newUser.Alter = user.Alter;

            return newUser;
        }


        //Get last user id of UserList.csv
        private int GetId()
        {
            int id = 0;
            List<User> users = dataServices.SaveUser();

            foreach (var line in users)
            {
                if (line.Id == 0)
                {
                    id = 1;
                    return id;
                }
                else
                {
                    id = line.Id + 1;
                    return id;
                }
            }
            throw new Exception("User Id invalid");
        }

        //returns User with right id
        public UserDto GetUserdtoById(int inputId)
        {
            bool idTrue = FindUserDtoId(inputId);
            List<User> users = dataServices.SaveUser();
            if (idTrue) { 
                foreach (var user in users)
                {
                    if (user.Id == inputId)
                    {
                        //Converting user in UsterDto
                        return ConvertIntoUserDto(user);
                    }
                }
            }
            throw new Exception("User Id invalid");
        }
        //Get all users
        public List<UserDto> GetAllUsers()
        {
            List<User> users = dataServices.SaveUser();
            List<UserDto> newUsers = new List<UserDto>();
            foreach (var user in users)
            {
                User convertUser = new User();
                convertUser = user;
                newUsers.Add(ConvertIntoUserDto(convertUser));
            }
            return newUsers;
        }

        //Checks if Input Id is in Userlist
        private bool FindUserDtoId(int inputId)
        {
            List<User> users = dataServices.SaveUser();
            bool idTrue= false;
            foreach (var line in users)
            {
                if (inputId == line.Id)
                {
                    idTrue = true;
                    return idTrue;
                }
            }
            throw new Exception("User Id invalid");
        }

    }
}
