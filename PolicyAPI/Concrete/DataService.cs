using PolicyAPI.Abstract;
using PolicyAPI.DTOs;

namespace PolicyAPI.Concrete
{
    public class DataService:IDataService
    {
        public List<StudentDTO> GetStudents()
        {
            // Your actual student data
            return new List<StudentDTO>
            {  
                new StudentDTO { Id = 1, Name = "Arjun Sharma", Cgpa = 9.2, IsPlaced = true, CurrentSalary = 4500000, CompaniesApplied = 1, DreamOffer = 5000000, DreamCompany = "Google" },
                new StudentDTO { Id = 2, Name = "Priya Patel", Cgpa = 8.8, IsPlaced = true, CurrentSalary = 3800000, CompaniesApplied = 1, DreamOffer = 4200000, DreamCompany = "Microsoft" },
                new StudentDTO { Id = 3, Name = "Rahul Kumar", Cgpa = 8.5, IsPlaced = true, CurrentSalary = 2800000, CompaniesApplied = 2, DreamOffer = 3500000, DreamCompany = "Amazon" },
                new StudentDTO { Id = 4, Name = "Sneha Gupta", Cgpa = 7.9, IsPlaced = true, CurrentSalary = 2200000, CompaniesApplied = 1, DreamOffer = 2800000, DreamCompany = "Apple" },
                new StudentDTO { Id = 5, Name = "Vikram Singh", Cgpa = 7.2, IsPlaced = true, CurrentSalary = 1800000, CompaniesApplied = 3, DreamOffer = 2500000, DreamCompany = "Netflix" },
                new StudentDTO { Id = 6, Name = "Ananya Joshi", Cgpa = 8.1, IsPlaced = true, CurrentSalary = 1200000, CompaniesApplied = 1, DreamOffer = 1800000, DreamCompany = "Flipkart" },
                new StudentDTO { Id = 7, Name = "Karthik Reddy", Cgpa = 6.8, IsPlaced = true, CurrentSalary = 800000, CompaniesApplied = 2, DreamOffer = 1500000, DreamCompany = "Paytm" },
                new StudentDTO { Id = 8, Name = "Divya Nair", Cgpa = 9.1, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 4000000, DreamCompany = "Google" },
                new StudentDTO { Id = 9, Name = "Rohit Agarwal", Cgpa = 8.7, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 3200000, DreamCompany = "Microsoft" },
                new StudentDTO { Id = 10, Name = "Meera Iyer", Cgpa = 8.3, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 2800000, DreamCompany = "Amazon" },
                new StudentDTO { Id = 11, Name = "Siddharth Jain", Cgpa = 7.6, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 2000000, DreamCompany = "Adobe" },
                new StudentDTO { Id = 12, Name = "Pooja Menon", Cgpa = 7.1, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 1500000, DreamCompany = "TCS" },
                new StudentDTO { Id = 13, Name = "Aditya Kapoor", Cgpa = 6.5, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 1200000, DreamCompany = "Infosys" },
                new StudentDTO { Id = 14, Name = "Neha Sinha", Cgpa = 8.9, IsPlaced = true, CurrentSalary = 3200000, CompaniesApplied = 0, DreamOffer = 6000000, DreamCompany = "Tesla" },
                new StudentDTO { Id = 15, Name = "Aryan Gupta", Cgpa = 7.8, IsPlaced = true, CurrentSalary = 2500000, CompaniesApplied = 1, DreamOffer = 2500000, DreamCompany = "Uber" },
                new StudentDTO { Id = 16, Name = "Kavya Pillai", Cgpa = 8.6, IsPlaced = true, CurrentSalary = 1500000, CompaniesApplied = 2, DreamOffer = 2200000, DreamCompany = "Zomato" },
                new StudentDTO { Id = 17, Name = "Harsh Trivedi", Cgpa = 6.9, IsPlaced = true, CurrentSalary = 700000, CompaniesApplied = 1, DreamOffer = 1800000, DreamCompany = "Swiggy" },
                new StudentDTO { Id = 18, Name = "Riya Shah", Cgpa = 9.3, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 5500000, DreamCompany = "Apple" },
                new StudentDTO { Id = 19, Name = "Abhishek Roy", Cgpa = 7.4, IsPlaced = true, CurrentSalary = 1900000, CompaniesApplied = 3, DreamOffer = 2100000, DreamCompany = "Myntra" },
                new StudentDTO { Id = 20, Name = "Ishita Verma", Cgpa = 8.0, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 2600000, DreamCompany = "Salesforce" },
                new StudentDTO { Id = 21, Name = "Nikhil Pandey", Cgpa = 6.2, IsPlaced = true, CurrentSalary = 600000, CompaniesApplied = 0, DreamOffer = 2000000, DreamCompany = "Wipro" },
                new StudentDTO { Id = 22, Name = "Shreya Bose", Cgpa = 8.4, IsPlaced = true, CurrentSalary = 2700000, CompaniesApplied = 1, DreamOffer = 3000000, DreamCompany = "Oracle" },
                new StudentDTO { Id = 23, Name = "Varun Malhotra", Cgpa = 7.5, IsPlaced = false, CurrentSalary = 0, CompaniesApplied = 0, DreamOffer = 1800000, DreamCompany = "IBM" },
                new StudentDTO { Id = 24, Name = "Tanvi Agrawal", Cgpa = 9.0, IsPlaced = true, CurrentSalary = 4200000, CompaniesApplied = 2, DreamOffer = 4000000, DreamCompany = "Meta" },
                new StudentDTO { Id = 25, Name = "Aarav Saxena", Cgpa = 6.7, IsPlaced = true, CurrentSalary = 950000, CompaniesApplied = 1, DreamOffer = 1400000, DreamCompany = "Accenture" }
            };
        }

        public List<CompanyDTO> GetCompanies()
        {
            return new List<CompanyDTO>
            {
                new CompanyDTO { Id = 1, Name = "Google", SalaryOffered = 5500000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 2, Name = "Microsoft", SalaryOffered = 5000000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 3, Name = "Amazon", SalaryOffered = 4500000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 4, Name = "Apple", SalaryOffered = 6000000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 5, Name = "Meta", SalaryOffered = 5200000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 6, Name = "Netflix", SalaryOffered = 4800000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 7, Name = "Tesla", SalaryOffered = 4200000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 8, Name = "Uber", SalaryOffered = 3500000, Category = "Product", IsHighPaying = true },
                new CompanyDTO { Id = 9, Name = "Flipkart", SalaryOffered = 2800000, Category = "Product", IsHighPaying = false}
            };
        }

        public PolicyConfigurationDTO GetPolicyConfiguration()
        {
            PolicyConfigurationDTO config = new PolicyConfigurationDTO();

            config.MaxCompanies.Enabled = true;
            config.MaxCompanies.MaxApplications = 2;

            config.DreamOffer.Enabled = true;

            config.DreamCompany.Enabled = false;

            config.CgpaThreshold.Enabled = true;
            config.CgpaThreshold.MinimumCgpa = 7.8;
            config.CgpaThreshold.HighSalaryThreshold = 2200000;

            config.PlacementPercentage.Enabled = false;
            config.PlacementPercentage.TargetPercentage = 75.0;

            config.OfferCategory.Enabled = true;
            config.OfferCategory.L1Threshold = 3200000;
            config.OfferCategory.L2Threshold = 1800000;
            config.OfferCategory.RequiredHikePercentageForL2 = 15.0;

            return config;
        }

        public double GetPlacementPercent() {
            List<StudentDTO> students = new List<StudentDTO>();
            students.AddRange(GetStudents());
            double placedStudents = students.Where(x => x.IsPlaced).Count();
            double percentage = (placedStudents / students.Count) * 100;

            return percentage;
        }
    }
}
