namespace PolicyAPI.DTOs
{
    public class EligibilityReasonDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public bool IsEligible { get; set; }
        public List<string> Reasons { get; set; } = new();
        public string Decision { get; set; } = string.Empty;
    }
}
