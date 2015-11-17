using System;

namespace EvacuateSystem.Model.Classes
{
    public class RegistrationRecord : BaseEntity
    {
        public DateTime ArrivialDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string Note { get; set; }
        public PEPCooperator Registrator { get; set; }
    }
}
