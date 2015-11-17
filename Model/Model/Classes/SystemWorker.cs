using EvacuateSystem.Model.Classes;

namespace Model.Model.Classes
{
    public class SystemWorker : BaseEntity
    {
        public PEPCooperator Cooperator { get; set; }
        public string Password { get; set; }
    }
}
