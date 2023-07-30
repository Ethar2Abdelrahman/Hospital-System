using Hospital.BL.ViewModels;
using Hospital.DAL;

namespace Hospital.BL;

public class DoctorsManager : IDoctorsManager
{
    private readonly IDoctorRepo _doctorsRepo;

    public DoctorsManager(IDoctorRepo doctorsRepo)
    {
        _doctorsRepo = doctorsRepo;
    }

    public IEnumerable<DoctorReadVM> GetAllAsViewModel()
    {
        IEnumerable<Doctor> doctorsFromDb = _doctorsRepo.GetDoctors(); //from db
        IEnumerable<DoctorReadVM> doctorsVM = doctorsFromDb      //list of doctors to list of vm
            .Select(d => new DoctorReadVM
            {
                Id = d.Id,
                Name = d.Name,
                Specializatuon = d.Specializatuon,
                PerformanceRate = d.PerformanceRate,
            });
        return doctorsVM;
    }

    public DoctorReadVM? GetBYIdAsViewModel(Guid id)
    {
        Doctor? doctorsFromDb = _doctorsRepo.GetById(id);    //from db
        if (doctorsFromDb is null)
        {
            return null;
        }
        //map to view 
        return new DoctorReadVM
        {
            Id = doctorsFromDb.Id,
            Name = doctorsFromDb.Name,
            Specializatuon = doctorsFromDb.Specializatuon,
            PerformanceRate = doctorsFromDb.PerformanceRate,
        };
    }
    public void AddAsViewModel(DoctorAddVM doctorVM)     //convert view to domain
    {

        //domain
        var doctor = new Doctor
        {
            Id = Guid.NewGuid(),
            Name = doctorVM.Name,
            Specializatuon = doctorVM.Specializatuon,
            PerformanceRate = doctorVM.PerformanceRate,

        };
        //addto db
        _doctorsRepo.Add(doctor);
        _doctorsRepo.SaveChange();

    }

    public DoctorEditVM? GetBYIdEditViewModel(Guid id)
    {
        Doctor? DoctorFormDb = _doctorsRepo.GetById(id);
        if( DoctorFormDb is null)
        {
            return null;
        }
        //mapping to doctoredit

        return new DoctorEditVM { 
            Id = id,
            Name = DoctorFormDb.Name,
            Specializatuon =  DoctorFormDb.Specializatuon,
            Salary = DoctorFormDb.Salary,
        };

    }

    public void EditAsViewModel(DoctorEditVM doctorVM)
    {
        Doctor? doctor = _doctorsRepo.GetById(doctorVM.Id);
        if(doctorVM is null)
            {
            return;
        }
        doctor.Name = doctorVM.Name;
        doctor.Salary = doctorVM.Salary;
        doctor.Specializatuon = doctorVM.Specializatuon;
        _doctorsRepo.Update(doctor);
        _doctorsRepo.SaveChange();

        
    }

    //public DoctorDetailsVM? GetDetails(Guid id)
    //{
    //    Doctor? DoctorFromDb = _doctorsRepo.GetByIdWithPatientIssues(id);
    //    if (DoctorFromDb is null)
    //    {
    //        return null;
    //    }
    //    //db model -> view model
    //    return new DoctorDetailsVM
    //    {
    //        Name = DoctorFromDb.Name,
    //        Specialization = DoctorFromDb.Specializatuon,
    //        PerformanceRate = DoctorFromDb.PerformanceRate,

    //        //convert list of patient to list of chilpatient (select)
    //        Patients = DoctorFromDb.Patients
    //        .Select(p => new DoctorDetailsVM 
    //        {

    //            Name = p.Name,
    //            NumberOfIssue = p.Issues.Count
    //        }).ToList()

    //};

    //}
    public DoctorDetailsVM? GetDetails(Guid id)
    {
        Doctor? doctorFromDb = _doctorsRepo.GetByIdWithPatientIssues(id);
        if (doctorFromDb is null)
        {
            return null;
        }
        // Convert db model to view model
        var doctorDetailsVM = new DoctorDetailsVM
        {
            Name = doctorFromDb.Name,
            Specialization = doctorFromDb.Specializatuon,
            PerformanceRate = doctorFromDb.PerformanceRate,

            Patients = doctorFromDb.Patients
                .Select(p => new PatientChildVM
                {
                    Name = p.Name,
                    NumberOfIssue = p.Issues.Count
                })
                .ToList()
        };

        return doctorDetailsVM;
    }


}