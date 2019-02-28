using System;
using System.Runtime.Serialization;

namespace WebApp.Models
{
    public class DownloadLog
    {
        public string TableName { get; set; }
        public string ComparisonType { get; set; }
        public int QueueID { get; set; }
        public int ScheduleID { get; set; }
        public int BatchID { get; set; }
        public DateTime ScheduledRunDT { get; set; }
        public DateTime StartDT { get; set; }
        public DateTime MergeEndDT { get; set; }
        public int BulkCopyTime { get; set; }
        public int MergeTime { get; set; }
        public int TotalTime { get; set; }
        public int UpdateCount { get; set; }
        public int InsertCount { get; set; }
        public int DeleteCount { get; set; }
        public int RawCount { get; set; }
        public int ResultCode { get; set; }
        public string ResultText { get; set; }
        public string DetailText { get; set; }
    }
}
