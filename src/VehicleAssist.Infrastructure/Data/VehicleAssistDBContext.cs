using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Appointments;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Notification;
using VehicleAssist.Domain.Reminders;
using VehicleAssist.Domain.Service;

namespace VehicleAssist.Infrastructure.Data
{
    public class VehicleAssistDBContext : DbContext, IUnitOfWork
    {
        public VehicleAssistDBContext(DbContextOptions<VehicleAssistDBContext> options) : base(options)
        {
        }


        //Tables Here
        public DbSet<Member> Members { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<ServiceTime> ServiceTimes { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }


        public DbSet<Notification> Notifications { get; set; }

      
    
        public void CommitChanges()
        {
          this.SaveChanges();
        }

        public Task CommitChangesAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleAssistDBContext).Assembly);

        }
    }
}
