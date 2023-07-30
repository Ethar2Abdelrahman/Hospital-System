namespace Hospital.BL.ViewModels
{
    public class DoctorAddVM
    {
        public string Name { get; set; } = string.Empty;
        public string Specializatuon { get; set; } = string.Empty;

        public decimal Salary { get; set; }
        public int PerformanceRate { get; set; }
    }
}
