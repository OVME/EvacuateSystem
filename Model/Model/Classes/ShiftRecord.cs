using System;

namespace EvacuateSystem.Model.Classes
{
    public class ShiftRecord : BaseEntity
    {
        public PEPCooperator Personal { get; set; }
        public ShiftRecord Shift { get; set; }
        public DateTime Date { get; set; }
    }
}
