using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SqlClient;
using Insight.Database;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class DownloadLogController : Controller
    {
        [HttpGet]
        [Route("GetWHRep")]
        public IEnumerable<DownloadLog> GetWHRep()
        {
            DbConnection cn = new SqlConnection(ConnectionStrings.whrep_ProTraQ_Corporate_V1);
            IDownloadLogRepository downloadLog = cn.As<IDownloadLogRepository>();
            var results = downloadLog.usp_DownloadLog_Get();
            return results;
        }

        [HttpGet]
        public IEnumerable<DownloadLog> Getfr_sql_07_pd()
        {
            DbConnection cn = new SqlConnection(ConnectionStrings.fr_sql_07_pd_ProTraQ_Corporate_V1);
            IDownloadLogRepository downloadLog = cn.As<IDownloadLogRepository>();
            var results = downloadLog.usp_DownloadLog_Get();
            return results;
        }
    }

    public interface IDownloadLogRepository
    {
        IList<DownloadLog> usp_DownloadLog_Get();
    }

    // public class DownloadLog
    // {
    //     public string TableName { get; set; }
    //     public string ComparisonType { get; set; }
    //     public int QueueID { get; set; }
    //     public int ScheduleID { get; set; }
    //     public int BatchID { get; set; }
    //     public DateTime ScheduledRunDT { get; set; }
    //     public DateTime StartDT { get; set; }
    //     public DateTime MergeEndDT { get; set; }
    //     public int BulkCopyTime { get; set; }
    //     public int MergeTime { get; set; }
    //     public int TotalTime { get; set; }
    //     public int UpdateCount { get; set; }
    //     public int InsertCount { get; set; }
    //     public int DeleteCount { get; set; }
    //     public int RawCount { get; set; }
    //     public int ResultCode { get; set; }
    //     public string ResultText { get; set; }
    //     public string DetailText { get; set; }
    // }
}
