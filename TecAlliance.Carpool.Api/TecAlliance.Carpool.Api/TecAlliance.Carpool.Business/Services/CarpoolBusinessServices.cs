using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Model;
using TecAlliance.Carpool.Data.Models;
using TecAlliance.Carpool.Data.Services;

namespace TecAlliance.Carpool.Business.Services
{
    public class CarpoolBusinessServices
    {
        //Global
        UserDataServices userDataServices;
        UserBusinessServices userBusinessServices;
        CarpoolDataServices carpoolDataServices;
        //Construktor
        public CarpoolBusinessServices() 
        { 
            userDataServices = new UserDataServices();
            userBusinessServices = new UserBusinessServices();
            carpoolDataServices = new CarpoolDataServices();
        }
        //Post Methode
        public void PostCarpool(int id, CarpoolDto carpoolDto)
        {
            UserDto userDto = userBusinessServices.GetUserdtoById(id);
            CarpoolModel carpool = CreateCarpool(carpoolDto,userBusinessServices.GetUserdtoById(id));
            carpoolDataServices.PostCarpool(carpool);
        }
        //Add CarpoolDto and userDto to one Carpool
        public CarpoolModel CreateCarpool(CarpoolDto carpoolDto, UserDto userDtoId)
        {
            CarpoolModel carpool = new CarpoolModel();
            carpool.UserId = userDtoId.Id;
            carpool.Name = userDtoId.Name;
            carpool.Nachname = userDtoId.Nachname;
            carpool.Anmeldename = userDtoId.Anmeldename;
            carpool.Gender = userDtoId.Gender;
            carpool.Alter = userDtoId.Alter;
            carpool.AutoBezeichnung = carpoolDto.AutoBezeichnung;
            carpool.FreeSeat = carpoolDto.FreeSeat;
            carpool.Fahrers = carpoolDto.Fahrers;
            carpool.WohnOrt = carpoolDto.WohnOrt;
            carpool.ZielOrt = carpoolDto.ZielOrt;
            carpool.Abfahrtzeit = carpoolDto.Abfahrtzeit;

            return carpool;
        }


        public CarpoolDtoWithUserInformation ConvertToCarpoolDtoWithUserInfo(CarpoolModel carpoolModel)
        {
            CarpoolDtoWithUserInformation carpoolDtoWithUserInfo = new CarpoolDtoWithUserInformation();
            carpoolDtoWithUserInfo.UserId = carpoolModel.UserId;
            carpoolDtoWithUserInfo.Name = carpoolModel.Name;
            carpoolDtoWithUserInfo.Nachname = carpoolModel.Nachname;
            carpoolDtoWithUserInfo.Anmeldename = carpoolModel.Anmeldename;
            carpoolDtoWithUserInfo.Gender = carpoolModel.Gender;
            carpoolDtoWithUserInfo.Alter = carpoolModel.Alter;
            carpoolDtoWithUserInfo.AutoBezeichnung = carpoolModel.AutoBezeichnung;
            carpoolDtoWithUserInfo.FreeSeat = carpoolModel.FreeSeat;
            carpoolDtoWithUserInfo.Fahrers = carpoolModel.Fahrers;
            carpoolDtoWithUserInfo.WohnOrt = carpoolModel.WohnOrt;
            carpoolDtoWithUserInfo.ZielOrt = carpoolModel.ZielOrt;
            carpoolDtoWithUserInfo.Abfahrtzeit = carpoolModel.Abfahrtzeit;

            return carpoolDtoWithUserInfo;
        }

        public List<CarpoolModel> GetAllCarpools()
        {
            List<CarpoolModel> list = carpoolDataServices.SaveCarpools();
            return list;

        }
    }
}
