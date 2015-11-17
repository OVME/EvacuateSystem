using EvacuateSystem.Model.Classes;

namespace Model.Model.Classes
{
    public class Vacancy : BaseEntity
    {
        public Profession Profession { get; set; }
        public Village Village { get; set; }
        public string Description { get; set; }
        public string Organisation { get; set; }
        public bool IsOccupied { get; set; }
    }
}
