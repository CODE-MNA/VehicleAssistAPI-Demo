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
    public class ReminderConfig : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.OwnsMany(x => x.ReminderAlarmSchedules, a =>
            {
                a.WithOwner(x => x.Reminder)
                .HasForeignKey(x => x.ReminderId);
                a.HasKey(x => x.ReminderAlarmScheduleId);
                
                a.Property(x => x.ScheduleType).IsRequired().HasConversion<string>();
            });
         
           
        }
    }
}
