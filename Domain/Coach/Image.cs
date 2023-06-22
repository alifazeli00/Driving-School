namespace Domain.Coach
{
    public class Image
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public Coachs Coachs { get; set; }
        public int CoachsId { get; set; }

    }
}
