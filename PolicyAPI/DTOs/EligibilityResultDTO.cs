namespace PolicyAPI.DTOs
{
    public class EligibilityResultDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public List<EligibilityReasonDTO> EligibilityReasonDTO { get; set; }
        public int EligibleCompaniesCount { get; set; }
        public List<string> EligibleCompaniesName { get; set; }
        //public int CompanyId { get; set; }
        //public string CompanyName { get; set; } = string.Empty;
        //public bool IsEligible { get; set; }
        //public List<string> Reasons { get; set; } = new();
        //public string Decision { get; set; } = string.Empty;
    }
}
