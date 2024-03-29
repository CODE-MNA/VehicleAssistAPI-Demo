﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Data.Configurations
{
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.HasDiscriminator(b=>b.MemberType);
            
            builder.Property(m => m.UserName).HasColumnType("varchar(50)");
            builder.Property(m => m.PasswordHash).HasColumnType("varchar(60)");

            builder.Property(m => m.FirstName).HasColumnType("varchar(100)");
            builder.Property(m => m.LastName).HasColumnType("varchar(50)");

            builder.Property(m => m.Email).HasColumnType("varchar(100)");

            builder.Property(m => m.CellPhoneNumber).HasColumnType("varchar(30)");
            builder.Property(m => m.HomePhoneNumber).HasColumnType("varchar(30)");

            builder.Property(b => b.UserActivated).HasColumnType("bit");
            builder.Property(b => b.UserActivatedDate).HasColumnType("datetime");

            builder.Property(b => b.MemberId).HasColumnName("MemberId");

            builder.HasIndex(b => b.UserName).IsUnique(true);
            builder.HasIndex(b => b.Email).IsUnique(true);

            builder.HasKey(m => m.MemberId);

            //Notifications
            builder.HasMany(b => b.Notifications)
                .WithOne(n => n.Member).HasForeignKey(x => x.MemberId);
        
        }
    }
}
