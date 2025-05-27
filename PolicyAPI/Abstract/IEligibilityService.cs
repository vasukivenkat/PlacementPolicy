using PolicyAPI.DTOs;

namespace PolicyAPI.Abstract
{
    public interface IEligibilityService
    {
        EligibilityConsolidationDTO CheckBulkEligibility(List<StudentDTO> students, List<CompanyDTO> companies, PolicyConfigurationDTO policies, double currentPlacementPercentage);
        PlacementStatusDTO GetPlacementStats(List<StudentDTO> students);
    }
}
