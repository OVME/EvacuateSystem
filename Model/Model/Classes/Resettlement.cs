namespace EvacuateSystem.Model.Classes
{
    public class Resettlement : BaseEntity
    {
        public string Note { get; set; }
        public RegistrationRecord RegistrationRecord { get; set; }
        public Adress Adress { get; set; }
        public PEPCooperator Settler { get; set; }
    }
}
