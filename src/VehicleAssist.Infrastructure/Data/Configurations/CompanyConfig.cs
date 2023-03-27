using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Service;

namespace VehicleAssist.Infrastructure.Data.Configurations
{
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(c => c.CompanyServices).WithOne(d => d.Company).HasForeignKey(x => x.MemberId).OnDelete(DeleteBehavior.ClientCascade); ;

            builder.HasMany(c => c.DealServices).WithOne(d => d.Company).HasForeignKey(x => x.MemberId).OnDelete(DeleteBehavior.ClientCascade);
        }


    }

    internal class CompanyServiceConfig : IEntityTypeConfiguration<CompanyService>
    {
        public void Configure(EntityTypeBuilder<CompanyService> builder)
        {

            builder.HasOne(cs => cs.Discount).WithMany(cs => cs.CompanyServices).HasForeignKey(x => x.DiscountTypeCode).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(cs => cs.ServiceType).WithMany(cs => cs.CompanyServices).HasForeignKey(x => x.ServiceTypeCode).OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(d => d.DiscountTypeCode).HasColumnType("varchar(10)");
            builder.Property(d => d.ServiceTypeCode).HasColumnType("varchar(100)");
            builder.Property(d => d.Name).HasColumnType("varchar(50)");
            builder.Property(d => d.Description).HasColumnType("varchar(255)");
            builder.Property(d => d.Price).HasPrecision(10,2);
            builder.Property(d => d.ActualPrice).HasPrecision(10, 2);
            builder.Property(d => d.DiscountAmount).HasPrecision(10, 2);

        }
    }

    internal class DiscountConfig : IEntityTypeConfiguration<Discount>
    {

        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(d => d.DiscountTypeCode).HasColumnType("varchar(10)");
            builder.HasKey(d => d.DiscountTypeCode);

        }

    }

    internal class ServiceTypeConfig: IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasKey(st => st.ServiceTypeCode);
            builder.Property(st=>st.Description).HasColumnType("varchar(255)");
            builder.Property(st => st.ServiceTypeCode).HasColumnType("varchar(100)");

        }
    }
}
