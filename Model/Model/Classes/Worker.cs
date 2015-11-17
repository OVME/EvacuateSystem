using EvacuateSystem.Model.Classes;

namespace Model.Model.Classes
{
    public class Worker : BaseEntity
    {
        public Vacancy Vacancy { get; set; }
        public Evacuated Evacuated { get; set; } 
    }
}
