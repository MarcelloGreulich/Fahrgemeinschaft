﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;
using TecAlliance.Carpool.Data.Models;

namespace TecAlliance.Carpool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarpoolController : ControllerBase
    {
        //Global
        CarpoolBusinessServices carpoolBusinessServices;

        //Construktor
        public CarpoolController()
        {
            carpoolBusinessServices = new CarpoolBusinessServices();
        }
        //POST: api/Carpool/Id
        [HttpPost("{id}")]
        public ActionResult<CarpoolDto> PostCarpool(int id, CarpoolDto carpool)
        {
            carpoolBusinessServices.PostCarpool(id, carpool);
            return Created($"api/Carpool/{carpool.WohnOrt}", carpool); ;
        }
        //GET: api/Carpool
        [HttpGet]
        public ActionResult<List<CarpoolDtoWithUserInformation>> GetAllCarpools()
        {
            var list = carpoolBusinessServices.GetAllCarpools();
            List<CarpoolDtoWithUserInformation> dtoList = new List<CarpoolDtoWithUserInformation>();
            foreach (var item in list)
            {
                 dtoList.Add(carpoolBusinessServices.ConvertToCarpoolDtoWithUserInfo(item));
            }
            return dtoList;
        }


    }
}