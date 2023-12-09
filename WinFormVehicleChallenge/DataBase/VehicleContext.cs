using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCarChallenge.Entities.DomainEntities;

namespace WinFormVehicleChallenge.DataBase;

public class VehicleContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            var conectionString = "Server=localhost;Port=5432;User Id=rood;Password=admin123;Database=mysql";
            options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
        }
    }
}
