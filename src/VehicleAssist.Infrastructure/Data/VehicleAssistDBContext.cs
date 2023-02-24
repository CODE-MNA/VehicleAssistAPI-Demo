using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Data
{
    public class VehicleAssistDBContext : DbContext, IUnitOfWork
    {
        public VehicleAssistDBContext(DbContextOptions<VehicleAssistDBContext> options) : base(options)
        {
        }


        //Tables Here
        public DbSet<Member> Members { get; set; }

        public void CommitChanges()
        {
            Console.WriteLine("Saved POG");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
