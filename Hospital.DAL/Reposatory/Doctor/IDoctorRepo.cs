namespace Hospital.DAL
{
    public interface IDoctorRepo
    {

        //contract
        IEnumerable<Doctor> GetDoctors ();  //list return doctors

        IEnumerable<Doctor> GetByPerformance(int rate);  //take rate , return docore that rate>
        Doctor? GetById (Guid id);

        void Add(Doctor doctor);

        void Delete(Doctor doctor);
        void Update(Doctor doctor);

        int SaveChange();

        Doctor? GetByIdWithPatientIssues(Guid id);
    }
}
