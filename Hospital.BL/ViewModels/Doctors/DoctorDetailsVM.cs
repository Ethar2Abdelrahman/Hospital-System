namespace Hospital.BL.ViewModels
{
    //name,spec,rate, list of class carry name  , issue
    public class DoctorDetailsVM
    {
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public int PerformanceRate { get; set; }

        public List<PatientChildVM> Patients { get; set; } = new List<PatientChildVM>(); // List return nameof,num
    }

    public class PatientChildVM
    {
        public string Name { get; set; } = string.Empty;
        public int NumberOfIssue { get; set; }
    }
}
