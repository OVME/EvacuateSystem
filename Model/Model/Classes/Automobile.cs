namespace EvacuateSystem.Model.Classes
{
    public class Automobile : BaseEntity
    {
        public string ModelAndMark { get; set; }
        public int NumberOfSets { get; set; }
        public PEPCooperator Driver { get; set; }
    }
}
