using System;

namespace EvacuateSystem.Model.Classes
{
    public class Trip : BaseEntity
    {
        public DateTime DepartureDateTime { get; set; }
        public Automobile Automobile { get; set; }

        public Village Village { get; set; }
    }
}
