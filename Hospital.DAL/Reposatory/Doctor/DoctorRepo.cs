using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class DoctorRepo : IDoctorRepo                //class implement from interface
    {
        private readonly HospitalContext _Context;   //put context in field to use later 
        public DoctorRepo(HospitalContext context)   //depend on context(service)
        {
            _Context = context; 
            
        }

        public void Add(Doctor doctor)
        {
            _Context.Set<Doctor>().Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _Context.Set<Doctor>().Remove(doctor);
        }

        public Doctor? GetById(Guid id)
        {
           return _Context.Set<Doctor>().Find(id);    //search  by  id
         }


        public Doctor? GetByIdWithPatientIssues(Guid id)
        {
            //eager loading
            return _Context.Set<Doctor>()
                .Include(d => d.Patients)
                .ThenInclude(d => d.Issues)
                .FirstOrDefault(d=> d.Id == id);

        }

        public IEnumerable<Doctor> GetByPerformance(int rate)
        {
          return  _Context.Set<Doctor>().Where(p=>p.PerformanceRate >= rate);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _Context.Set<Doctor>().AsNoTracking();
        }

        public int SaveChange()
        {
          return  _Context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _Context.Doctors.Update(doctor);
        }

    }
}
