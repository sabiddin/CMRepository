namespace CM.Domain.Entities
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int? VisitTypeID { get; set; }
        public VisitType VisitType { get; set; }
    }
}
