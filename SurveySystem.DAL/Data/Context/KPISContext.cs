using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveySystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace SurveySystem.DAL.Data.Context
{
    public class KPISContext : DbContext
    {
        public DbSet<TbiKPI> Kpis => Set<TbiKPI>();

        public KPISContext(DbContextOptions<KPISContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding TbiKPI table

            var tbikpi = new List<TbiKPI>
            {
                  new TbiKPI {
                    KPINum= 18820007,
                    KPIDescription= "Grow sales by 5% per quarter",
                    DepNo=2,
                      MeasurementUnit = true,
                      TargetedValue= 100
                  },
                  new TbiKPI {
                    KPINum= 18320088,
                    KPIDescription= "Increase Net Promoter Score 25% over the next three years",
                    DepNo=1,
                    MeasurementUnit = false,
                    TargetedValue= 80
                  },

            };
            #endregion
            
            modelBuilder.Entity<TbiKPI>().HasData(tbikpi);
            base.OnModelCreating(modelBuilder);
        }

    }
}
