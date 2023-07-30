
namespace Hospital.BL.ViewModels
{
    public class DoctorEditVM
    {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Specializatuon { get; set; } = string.Empty;

            public decimal Salary { get; set; }
            //public int PerformanceRate { get; set; }
        }
}
