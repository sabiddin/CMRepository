using System;

namespace CM.Domain.Entities
{
    public class Document
    {
        public virtual int DocumentID { get; set; }
        public string Title { get; set; }
        public int? TreatmentCycleID { get; set; }
        public int? PatientID { get; set; }
        public int? ParentDocumentID { get; set; }
        public DateTime? DocumentDate { get; set; }
        public byte? RecActive { get; set; }
        public string DocumentType { get; set; }
        public int? VisitID { get; set; }
        public Visit Visit { get; set; }
        public int? LastUpdatedBy { get; set; }
        public User LastUpdatedUser { get; set; }
    }
}
