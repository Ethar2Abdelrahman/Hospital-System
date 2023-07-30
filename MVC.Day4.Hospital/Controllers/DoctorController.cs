using Hospital.BL;
using Hospital.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.MVC.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorsManager _doctorsManager;

        public DoctorController(IDoctorsManager doctorsManager)
        {
            _doctorsManager = doctorsManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<DoctorReadVM> doctors = _doctorsManager.GetAllAsViewModel();  //as aview
            return View(doctors);
        }
        //details
        //add form view
        //[HttpPost]
        //public IActionResult Add(DoctorAddVM doctorVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _doctorsManager.AddAsViewModel(doctorVM);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(doctorVM);
        //    }
        //}

        [HttpPost]
        public IActionResult Add(DoctorAddVM doctorVM)    //take view model
        {
            _doctorsManager.AddAsViewModel(doctorVM);   //viewmodel -> domainmodel -> save in db
            
            return RedirectToAction(nameof(Index));
        }
        //edit
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            DoctorEditVM? model = _doctorsManager.GetBYIdEditViewModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DoctorEditVM doctorVM)
        {
            _doctorsManager.EditAsViewModel(doctorVM);
            return RedirectToAction(nameof(Index));
        }

        //details
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            DoctorDetailsVM? doctorVM = _doctorsManager.GetDetails(id);
            return View(doctorVM);
        }
        }

}
