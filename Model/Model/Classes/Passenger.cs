namespace EvacuateSystem.Model.Classes
{
    public class Passenger : BaseEntity
    {
        public Resettlement Resettlement { get; set; }
        public Trip Trip { get; set; }
        public string Note { get; set; }
    }
}
