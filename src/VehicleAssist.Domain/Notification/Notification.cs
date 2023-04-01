using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Notification
{
    public class Notification : BaseEntity
    {
        public int NotificationId { get;  set; }
        public SendType SendType { get;  set; }

        public string Content { get; set; }

        public int MemberId { get; set; }

        public Member.Member? Member { get; set; }

        public string? JobID { get; set; }

        public DateTime TriggerTime { get; set; }

        public int ReferenceId { get; set; }

        public DateTimeOffset TimeZoneOffset { get; set; }
    }

    public enum SendType
    {
        ReminderPreparation,
        FinalReminder,

    }
}
