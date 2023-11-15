using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Data
{
    public class CabinetVeterinarContext : DbContext
    {
        public CabinetVeterinarContext (DbContextOptions<CabinetVeterinarContext> options)
            : base(options)
        {
        }

        public DbSet<CabinetVeterinar.Models.Animal> Animal { get; set; } = default!;

        public DbSet<CabinetVeterinar.Models.Cabinet>? Cabinet { get; set; }

        public DbSet<CabinetVeterinar.Models.Vet>? Vet { get; set; }

        public DbSet<CabinetVeterinar.Models.EmergencyType>? EmergencyType { get; set; }

        public DbSet<CabinetVeterinar.Models.ShowVetAnimalsModel>? ShowVetAnimalsModel { get; set; }
    }
}
