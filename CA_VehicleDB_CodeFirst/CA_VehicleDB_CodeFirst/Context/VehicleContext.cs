using CA_VehicleDB_CodeFirst.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Context
{
    public class VehicleContext:DbContext
    {
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<TruckAndTire> TruckAndTires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KUQ9PNH;database=VehicleDB;uid=sa;pwd=Ahmet21293;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruckAndTire>().HasKey(x => new { x.TireId, x.TruckId });



            List<Automobile> automobiles = new List<Automobile>()
            {
                new Automobile {Id=1,Colour="White",Fuel="Diesel",MaxKmh=260,TransmissionType='M',TireId=1,EngineId=1},
                new Automobile{Id=2,Colour="Black",Fuel="Gasoline",MaxKmh=280,TransmissionType='A',TireId=1,EngineId=2}
            };
            List<Motorcycle> motorcycles = new List<Motorcycle>()
            {
                new Motorcycle{Id=1,Colour="Red",Fuel="Gasoline",MaxKmh=300,TransmissionType='M',TireId=3,EngineId=1}
            };

            modelBuilder.Entity<Automobile>().HasData(automobiles);
            modelBuilder.Entity<Motorcycle>().HasData(motorcycles);
            base.OnModelCreating(modelBuilder);
        }
    }
}
