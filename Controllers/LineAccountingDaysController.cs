using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SqlClient;
using Insight.Database;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class LineAccountingDaysController : Controller
    {
        [HttpGet]
        public IEnumerable<LineAccountingDays> GetLineAccountingDays()
        {
            DbConnection cn = new SqlConnection(ConnectionStrings.ProTraQ869);
            ILineAccountingDaysRepository lineAccountingDays = cn.As<ILineAccountingDaysRepository>();
            var results = lineAccountingDays.tmp_usp_LINESETUP_GetLineAccountingDays();
            return results;
        }

        //[HttpPost("UpdateLineAccountingDay")]
        // [HttpPost]
        // [Route("UpdateLineAccountingDay")]
        // public int UpdateLineAccountingDay(LineAccountingDays lad)
        // {
        //     DbConnection cn = new SqlConnection(ConnectionStrings.ProTraQ869);
        //     ILineAccountingDaysRepository lineAccountingDays = cn.As<ILineAccountingDaysRepository>();
        //     return lineAccountingDays.tmp_usp_LINESETUP_UpdateLineAccountingDay();
        // }
    }

    public interface ILineAccountingDaysRepository
    {
        IList<LineAccountingDays> tmp_usp_LINESETUP_GetLineAccountingDays();
        //int tmp_usp_LINESETUP_UpdateLineAccountingDay();
    }

    public class LineAccountingDays
    {
        public long LineID { get; set; }
        public string LineName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long PlantTimeID { get; set; }
        public DateTime PStartTime { get; set; }
        public string Description { get; set; }
    }
}
