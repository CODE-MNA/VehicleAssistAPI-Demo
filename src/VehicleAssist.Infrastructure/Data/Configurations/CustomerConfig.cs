﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Customer;

namespace VehicleAssist.Infrastructure.Data.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(c => c.Vehicles).WithOne(c=>c.Customer).HasForeignKey(v => v.CustomerId);

            builder.HasMany(c=>c.Reminders).WithOne(c => c.Customer).HasForeignKey(v=>v.CustomerId);

        }
    }
}
