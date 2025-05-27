namespace PolicyAPI.DTOs
{
    public class CompanyBasedResultDTO
    {
        public string CompanyName {  get; set; }
        public int TotalStudents { get; set; }
        public int EligibleStudents { get; set; }
        public int NotEligibleStudents { get; set; }
        public List<string> EligibleStudentsName { get; set; }
    }
}
