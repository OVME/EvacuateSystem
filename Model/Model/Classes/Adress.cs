namespace EvacuateSystem.Model.Classes
{
    public class Adress : BaseEntity
    {
        public int HouseNumber { get; set; }
        public int Square { get; set; }
        public string OwnerName { get; set; }
        public string OwnerDocData { get; set; }
        public int NumberOfResidents { get; set; }
        public Village Village { get; set; }
        public Street Street { get; set; }
        public string Phone { get; set; }
    }
}
