using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Infrastructure.Data.Configurations
{
    public class ReminderScheduleTypeConfig : IEntityTypeConfiguration<ReminderAlarmSchedule>
    {
        public void Configure(EntityTypeBuilder<ReminderAlarmSchedule> builder)
        {
            builder.Property(x => x.ScheduleType)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
