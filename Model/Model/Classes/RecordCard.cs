namespace EvacuateSystem.Model.Classes
{
    public class RecordCard : BaseEntity
    {
        public Evacuated Evacuated { get; set; }
        public RegistrationRecord RegistrationRecord { get; set; }
    }
}
