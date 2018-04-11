namespace CM.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string FullName { get { return FName + " " + LName; } }
    }
}
