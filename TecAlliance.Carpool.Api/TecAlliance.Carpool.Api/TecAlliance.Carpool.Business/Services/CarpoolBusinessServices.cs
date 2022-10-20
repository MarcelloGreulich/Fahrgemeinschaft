using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Data.Model;
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
        public void PostCarpool(int id, CarpoolDto carpoolDto, bool isDriver)
        {
            UserDto userDto = userBusinessServices.GetUserdtoById(id);
            UserInoDto userInfoDto = ConvertIntoUserInfoDto(userDto, isDriver);
            List<CarpoolModel> carpool = CreateCarpool(carpoolDto, userInfoDto);
            carpoolDataServices.PostCarpool(carpool);
        }


        public UserInoDto ConvertIntoUserInfoDto(UserDto userDto, bool idDriver)
        {
            UserInoDto userInoDto = new UserInoDto();
            userInoDto.Id = userDto.Id;
            userInoDto.Name = userDto.Name;
            userInoDto.IsDriver = idDriver;
            return userInoDto;
        }
        public UserInfo ConvertIntoUserInfo(UserInoDto userDto)
        {
            UserInfo userInoDto = new UserInfo();
            userInoDto.Id = userDto.Id;
            userInoDto.Name = userDto.Name;
            userInoDto.IsDriver = userDto.IsDriver;
            return userInoDto;
        }
        public int GetId()
        {
            int id = 0;
            List<CarpoolModel> carpools = carpoolDataServices.SaveCarpools();

            if (carpools!=null)
            {
                foreach (var carpool in carpools)
                {
                    id = carpool.CarpoolId + 1;
                }

            }
            else
            {
                id=0;
            }

            return id;
        }
        //Add CarpoolDto and userDto to one Carpool
        public List<CarpoolModel> CreateCarpool(CarpoolDto carpoolDto, UserInoDto userDto)
        {

            List<CarpoolModel> carpoollList = new List<CarpoolModel>();
            if (userDto.IsDriver)
            {
                CarpoolModel carpool = new CarpoolModel();
                carpool.CarpoolId = GetId();
                carpool = convertAllInfo(carpoolDto, userDto);
                carpoollList.Add(carpool);
            }
            else
            {
                carpoollList.Add(convertAllInfo(carpoolDto, userDto));
            }
            return carpoollList;
        }
        public CarpoolModel convertAllInfo(CarpoolDto carpoolDto, UserInoDto userDto)
        {
            CarpoolModel carpool = new CarpoolModel();       
            carpool.CarDesignation = carpoolDto.CarDesignation;
            carpool.FreeSeat = carpoolDto.FreeSeat;
            carpool.StartPoint = carpoolDto.StartPoint;
            carpool.EndPoint = carpoolDto.EndPoint;
            carpool.DepartureTime = carpoolDto.DepartureTime;
            carpool.Drivers = ConvertIntoUserInfo(userDto);
            List<CarpoolModel> list = carpoolDataServices.SaveCarpools();
            List<UserInfo> userInfoList = new List<UserInfo>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    UserInfo userInfotest = new UserInfo();
                    List<UserInfo> passanger = new List<UserInfo>();
                    UserInfo passangertest = new UserInfo();
                    if (item.CarpoolId == carpool.CarpoolId)
                    {
                        carpool.Drivers = item.Drivers;
                        userInfotest = ConvertIntoUserInfo(userDto);
                        passanger = item.Passengers;
                        if (passanger != null)
                        {
                            userInfoList.Add(userInfotest);
                            foreach (var pesItem in passanger)
                            {     
                                passangertest.Id = pesItem.Id;
                                passangertest.Name = pesItem.Name;
                                passangertest.IsDriver = pesItem.IsDriver;
                                userInfoList.Add(passangertest);
                            }
                        }
                        else
                        {

                            userInfoList.Add(userInfotest);
                            carpool.Passengers = userInfoList;
                            return carpool;
                        }

                        userInfoList.Add(userInfotest);
                    }
                    carpool.Passengers = userInfoList;
                }
            }
            return carpool;
        }
        public UserInoDto ConvertIntoUserInfoDtoDrivcer(UserInfo userDto)
        {
            UserInoDto userInoDto = new UserInoDto();
            userInoDto.Id = userDto.Id;
            userInoDto.Name = userDto.Name;
            userInoDto.IsDriver = userDto.IsDriver;
            return userInoDto;
        }
        public CarpoolDtoWithUserInformation ConvertToCarpoolDtoWithUserInfo(CarpoolModel carpoolModel)
        {
            CarpoolDtoWithUserInformation carpoolDtoWithUserInfo = new CarpoolDtoWithUserInformation();
            carpoolDtoWithUserInfo.CarpoolId = carpoolModel.CarpoolId;
            carpoolDtoWithUserInfo.CarDesignation = carpoolModel.CarDesignation;
            carpoolDtoWithUserInfo.FreeSeat = carpoolModel.FreeSeat;
            carpoolDtoWithUserInfo.StartPoint = carpoolModel.StartPoint;
            carpoolDtoWithUserInfo.EndPoint = carpoolModel.EndPoint;
            carpoolDtoWithUserInfo.DepartureTime = carpoolModel.DepartureTime;
            carpoolDtoWithUserInfo.Drivers = ConvertIntoUserInfoDtoDrivcer(carpoolModel.Drivers);
            foreach (var item in carpoolModel.Passengers)
            {
                carpoolDtoWithUserInfo.Passengers.Add(ConvertIntoUserInfoDtoDrivcer(item));
            }
            return carpoolDtoWithUserInfo;
        }

        public List<CarpoolModel> GetAllCarpools()
        {
            List<CarpoolModel> list = carpoolDataServices.SaveCarpools();
            return list;

        }
    }
}
