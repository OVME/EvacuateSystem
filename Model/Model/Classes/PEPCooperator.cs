namespace EvacuateSystem.Model.Classes
{
    public class PEPCooperator : BaseEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        public Role Role { get; set; }
    }
}
