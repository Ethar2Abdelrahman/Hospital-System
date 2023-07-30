using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL;

// depences injection
    public class HospitalContext : DbContext
    {


    //Doctor property
    public DbSet<Doctor> Doctors => Set<Doctor>();  //when user ask doctor return set of doctors, getter only , not allow nullable
    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Issue> Issues => Set<Issue>();

    //configration per inveronment 
    //send option in ctor , and send option to base (microsoft)
    public HospitalContext(DbContextOptions<HospitalContext> options): base(options) 
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        #region Seeding Docs

        var doctors = new List<Doctor>
                {
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Jessie",
                    Specializatuon= "Hematology",
                    Salary= 27064,
                    PerformanceRate= 65,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Judy",
                     Specializatuon= "Neurology",
                    Salary= 18711,
                    PerformanceRate= 32,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Naomi",
                     Specializatuon= "Pediatrics",
                    Salary= 32145,
                    PerformanceRate= 27,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Joann",
                     Specializatuon= "Hematology",
                    Salary= 9232,
                    PerformanceRate= 72,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Judy",
                    Specializatuon= "Dermatology",
                    Salary= 48498,
                    PerformanceRate= 19,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Alyssa",
                 Specializatuon= "Gastroenterology",
                    Salary= 16586,
                    PerformanceRate= 79,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Mable",
                     Specializatuon= "Infectious Disease",
                    Salary= 33706,
                    PerformanceRate= 5,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Paula",
                    Specializatuon= "Urology",
                    Salary= 19094,
                    PerformanceRate= 0,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Rafael",
                     Specializatuon= "Pediatrics",
                    Salary= 12266,
                    PerformanceRate= 97,
                  },
                  new Doctor {
                    Id= Guid.NewGuid(),
                    Name= "Sara",
                     Specializatuon= "Pediatrics",
                    Salary= 45041,
                    PerformanceRate= 82,
                  },
                };

        #endregion

        modelBuilder.Entity<Doctor>().HasData(doctors);

    }
}

