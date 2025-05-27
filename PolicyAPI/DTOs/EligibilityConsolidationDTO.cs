namespace PolicyAPI.DTOs
{
    public class EligibilityConsolidationDTO
    {
        public List<EligibilityResultDTO> EligibilityResults { get; set; }
        public List<CompanyBasedResultDTO> CompanyBasedResult { get; set; }
    }
}
