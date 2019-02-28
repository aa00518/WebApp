using System;
using System.Runtime.Serialization;

namespace WebApp.Models
{
    [DataContract]
    public class DownloadLog
    {
        [DataMember]
        public string TableName { get; set; }
        [DataMember]
        public string ComparisonType { get; set; }
        [DataMember]
        public int QueueID { get; set; }
        [DataMember]
        public int ScheduleID { get; set; }
        [DataMember]
        public int BatchID { get; set; }
        [DataMember]
        public DateTime ScheduledRunDT { get; set; }
        [DataMember]
        public DateTime StartDT { get; set; }
        [DataMember]
        public DateTime MergeEndDT { get; set; }
        [DataMember]
        public int BulkCopyTime { get; set; }
        [DataMember]
        public int MergeTime { get; set; }
        [DataMember]
        public int TotalTime { get; set; }
        [DataMember]
        public int UpdateCount { get; set; }
        [DataMember]
        public int InsertCount { get; set; }
        [DataMember]
        public int DeleteCount { get; set; }
        [DataMember]
        public int RawCount { get; set; }
        [DataMember]
        public int ResultCode { get; set; }
        [DataMember]
        public string ResultText { get; set; }
        [DataMember]
        public string DetailText { get; set; }
    }
}
