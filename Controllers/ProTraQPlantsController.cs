using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SqlClient;
using Insight.Database;
using Microsoft.AspNetCore.SignalR;
using WebApp.Hubs;
using System.Threading;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProTraQPlantsController : Controller
    {
        private readonly IHubContext<SandboxHub> _hubContext;
        private static Timer timer;
        private static bool timerRunning = false;

        public ProTraQPlantsController(IHubContext<SandboxHub> hubContext)
        {
            _hubContext = hubContext;
        }

        private async void TimerProc(object state)
        {
            string now = DateTime.Now.ToLongTimeString();
            string msg = "Timer created at: " + (string)state + " - Current time: " + now;
            Console.WriteLine(msg);
            await _hubContext.Clients.All.SendAsync("messageReceived", msg);

            if (SandboxHub.connectionCounter < 1)
            {
                timer.Dispose();
                timerRunning = false;
            }
        }

        [HttpGet]
        public IEnumerable<ProTraQPlants> Get()
        {
            DbConnection cn = new SqlConnection(ConnectionStrings.fr_sql_07_pd_ProTraQ_CorporateTables);
            IProTraQPlantsRepository ptplants = cn.As<IProTraQPlantsRepository>();
            var results = ptplants.usp_ProTraQPlants_Get();

            return results;
        }

        [HttpGet("GetWithSignalR")]
        public IEnumerable<ProTraQPlants> GetWithSignalR()
        {
            DbConnection cn = new SqlConnection(ConnectionStrings.fr_sql_07_pd_ProTraQ_CorporateTables);
            IProTraQPlantsRepository ptplants = cn.As<IProTraQPlantsRepository>();
            var results = ptplants.usp_ProTraQPlants_Get();

            if (!timerRunning)
            {
                timerRunning = true;
                timer = new Timer(new TimerCallback(TimerProc), DateTime.Now.ToLongTimeString(), 5000, 5000);
            }

            return results;
        }
    }

    public interface IProTraQPlantsRepository
    {
        IList<ProTraQPlants> usp_ProTraQPlants_Get();
    }

    public class ProTraQPlants
    {
        public int FacilityID { get; set; }
        public int CompanyID { get; set; }
        public int FacilityNumber { get; set; }
        public string ProTraQURL { get; set; }
        public string ProTraQURLShort { get; set; }
        public string ProTraQURLSimplified { get; set; }
        public string FacilityName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string ExtendedZipCode { get; set; }
        public string ItemMasterDownloadFacilities { get; set; }
        public string FacilityAlpha { get; set; }
    }
}
