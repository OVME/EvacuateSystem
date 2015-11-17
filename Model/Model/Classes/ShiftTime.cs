using System;

namespace EvacuateSystem.Model.Classes
{
    public class ShiftTime : BaseEntity
    {
        public DateTime BeginingTime { get; set; }
        public DateTime EndingTime { get; set; }
    }
}
