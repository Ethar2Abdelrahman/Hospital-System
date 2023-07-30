namespace Hospital.DAL;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }    = string.Empty;
    public string Specializatuon { get; set; } = string.Empty;

    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }

    //list of patient
    public ICollection<Patient> Patients { get; set; }  =  new List<Patient>();
}
