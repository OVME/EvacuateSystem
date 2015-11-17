using System;
using Model.Model.Classes;

namespace EvacuateSystem.Model.Classes
{
    public class Evacuated : BaseEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NumberOfDocument { get; set; }
        public string DocumentData { get; set; }
        public int NumberOfFamilyMembers { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
