namespace Hospital.DAL
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        //m to m of patient
        //list of patient

        public ICollection<Patient> Patients { get; set; }  = new List<Patient>();

    }
}
