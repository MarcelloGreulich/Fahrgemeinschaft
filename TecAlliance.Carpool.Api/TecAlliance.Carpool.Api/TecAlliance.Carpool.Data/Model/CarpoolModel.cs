using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecAlliance.Carpool.Data.Model
{
    public class CarpoolModel
    {
        public int CarpoolId { get; set; }
        public string? CarDesignation { get; set; }
        public int FreeSeat { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }

        public UserInfo Drivers { get; set; }
        public List<UserInfo> Passengers { get; set; }

    }
}