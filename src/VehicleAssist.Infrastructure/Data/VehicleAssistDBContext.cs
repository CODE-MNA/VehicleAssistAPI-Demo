using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Customer;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Reminders;

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

        //public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<Reminder> Reminders { get; set; }
    
        public void CommitChanges()
        {
          this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleAssistDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
