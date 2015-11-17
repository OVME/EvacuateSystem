using System.Data.Entity;
using EvacuateSystem.Model.Classes;
using Model.Model.Classes;

namespace Core.Classes
{
    public class EvacuateSystemContext : DbContext
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Evacuated> Evacuateds { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PEPCooperator> PepCooperators { get; set; }
        public DbSet<RecordCard> RecordCards { get; set; }
        public DbSet<RegistrationRecord> RegistrationRecords { get; set; }
        public DbSet<Resettlement> Resettlements { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShiftRecord> ShiftRecords { get; set; }
        public DbSet<ShiftTime> ShiftTimes { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SystemWorker> SystemWorkers { get; set; }


        public EvacuateSystemContext()
        {
            Automobiles.Load();
            Adresses.Load();
            DocumentTypes.Load();
            Evacuateds.Load();
            Passengers.Load();
            PepCooperators.Load();
            RecordCards.Load();
            RegistrationRecords.Load();
            Resettlements.Load();
            Roles.Load();
            ShiftRecords.Load();
            ShiftTimes.Load();
            Streets.Load();
            Trips.Load();
            Villages.Load();
            Workers.Load();
            Professions.Load();
            Vacancies.Load();
            SystemWorkers.Load();

        }
    }
}
