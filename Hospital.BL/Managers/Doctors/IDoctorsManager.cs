using Hospital.BL.ViewModels;
using Hospital.DAL;

namespace Hospital.BL;
public interface IDoctorsManager
    {
        IEnumerable<DoctorReadVM> GetAllAsViewModel();
       DoctorReadVM? GetBYIdAsViewModel(Guid id);
        DoctorEditVM? GetBYIdEditViewModel(Guid id);
        void AddAsViewModel(DoctorAddVM doctorVM);    //return view , will change this view to domain and sent it ti database

        void EditAsViewModel(DoctorEditVM doctorVM);

         DoctorDetailsVM? GetDetails(Guid id);

}

