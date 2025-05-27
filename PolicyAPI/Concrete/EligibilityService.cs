using PolicyAPI.Abstract;
using PolicyAPI.Concrete.PolicyTypes;
using PolicyAPI.DTOs;

namespace PolicyAPI.Concrete
{
    public class EligibilityService : IEligibilityService
    {
        public EligibilityReasonDTO CheckEligibility(StudentDTO student, CompanyDTO company, PolicyConfigurationDTO policies, double currentPlacementPercentage)
        {
            var result = new EligibilityReasonDTO
            {
                CompanyId = company.Id,
                CompanyName = company.Name,
                IsEligible = true,
                Reasons = new List<string>()
            };

            // If student is not placed, they can apply (unless other restrictions apply)
            if (!student.IsPlaced)
            {
                result.Reasons.Add("Student is not yet placed - eligible to apply");

                var cgpaPolicyCheck =new CgpaThresholdPolicy();
                var cgpaCheckResult = cgpaPolicyCheck.Evaluate(student, company, policies, currentPlacementPercentage);
                if (!string.IsNullOrEmpty(cgpaCheckResult.Reason))
                    result.Reasons.Add(cgpaCheckResult.Reason);
                result.IsEligible = cgpaCheckResult.Passed;
                result.Decision = result.IsEligible ? "Eligible" : "Not Eligible";
                return result;
            }

            var policylist = PolicyListInitializer.InitializePolicyList();

            for (int i = 0; i < policylist.Count; i++)
            {
                var policy = policylist[i];
                var resultPolicy = policy.Evaluate(student, company, policies, currentPlacementPercentage);
                if (!resultPolicy.Blocking)
                {
                    result.Reasons.Add(resultPolicy.Reason);
                    result.IsEligible = resultPolicy.Passed;
                    result.Decision = result.IsEligible ? "Eligible" : "Not Eligible";
                    return result;
                }
                else
                {
                    if (!string.IsNullOrEmpty(resultPolicy.Reason))
                        result.Reasons.Add(resultPolicy.Reason);
                    result.IsEligible = resultPolicy.Passed;
                    result.Decision = result.IsEligible ? "Eligible" : "Not Eligible";
                    if (i == policylist.Count - 1)
                        return result;
                }
            }
            return result;

        }
        
        public EligibilityConsolidationDTO CheckBulkEligibility(List<StudentDTO> students, List<CompanyDTO> companies, PolicyConfigurationDTO policies, double currentPlacementPercentage)
        {
            var eligibilityResults = ProcessStudentBasedEligibility(students, companies, policies, currentPlacementPercentage);
            var companyBasedResult = ProcessCompanyBasedResults(companies, students, eligibilityResults);

            EligibilityConsolidationDTO EligibilityConsolidation = new EligibilityConsolidationDTO
            {
                EligibilityResults = eligibilityResults,
                CompanyBasedResult = companyBasedResult
            };

            return EligibilityConsolidation;
        }

        private List<EligibilityResultDTO> ProcessStudentBasedEligibility(List<StudentDTO> students, List<CompanyDTO> companies, PolicyConfigurationDTO policies, double currentPlacementPercentage)
        {
            var eligibilityResults = new List<EligibilityResultDTO>(students.Count);

            foreach (var student in students)
            {
                var eligibilityReasons = new List<EligibilityReasonDTO>(companies.Count); 
                var eligibleCompaniesName = new List<string>();

                foreach (var company in companies)
                {
                    var reason = CheckEligibility(student, company, policies, currentPlacementPercentage);
                    eligibilityReasons.Add(reason);

                    if (reason.IsEligible)
                        eligibleCompaniesName.Add(reason.CompanyName);
                }

                var result = new EligibilityResultDTO
                {
                    StudentId = student.Id,
                    StudentName = student.Name,
                    EligibilityReasonDTO = eligibilityReasons,
                    EligibleCompaniesName = eligibleCompaniesName,
                    EligibleCompaniesCount = eligibleCompaniesName.Count
                };

                eligibilityResults.Add(result);
            }

            return eligibilityResults;
        }

        private List<CompanyBasedResultDTO> ProcessCompanyBasedResults(List<CompanyDTO> companies, List<StudentDTO> students, List<EligibilityResultDTO> eligibilityResults)
        {
            // Create lookup dictionary for O(1) access instead of nested loops
            var studentEligibilityLookup = eligibilityResults
                .SelectMany(result => result.EligibilityReasonDTO
                    .Where(reason => reason.IsEligible)
                    .Select(reason => new {
                        CompanyId = reason.CompanyId,
                        StudentName = result.StudentName
                    }))
                .GroupBy(x => x.CompanyId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.StudentName).ToList()
                );

            var companyBasedResult = new List<CompanyBasedResultDTO>(companies.Count); // Pre-allocate capacity

            foreach (var company in companies)
            {
                var eligibleStudentNames = studentEligibilityLookup.ContainsKey(company.Id)
                    ? studentEligibilityLookup[company.Id]
                    : new List<string>();

                var companyresult = new CompanyBasedResultDTO
                {
                    CompanyName = company.Name,
                    TotalStudents = students.Count,
                    EligibleStudents = eligibleStudentNames.Count,
                    NotEligibleStudents = students.Count - eligibleStudentNames.Count,
                    EligibleStudentsName = eligibleStudentNames
                };

                companyBasedResult.Add(companyresult);
            }

            return companyBasedResult;
        }

        public PlacementStatusDTO GetPlacementStats(List<StudentDTO> students)
        {
            var totalStudents = students.Count;
            var placedStudents = students.Count(s => s.IsPlaced);
            var placementPercentage = totalStudents > 0 ? (double)placedStudents / totalStudents * 100 : 0;

            return new PlacementStatusDTO
            {
                TotalStudents = totalStudents,
                PlacedStudents = placedStudents,
                PlacementPercentage = Math.Round(placementPercentage, 2)
            };
        }
    }
}
