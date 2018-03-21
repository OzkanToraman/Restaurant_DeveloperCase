using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_DeveloperCase.Repository.UOW.Abstract;
using Restaurant_DeveloperCase.DAL.Data;
using Restaurant_DeveloperCase.DAL.Model;
using Restaurant_DeveloperCase.BLL.Validations;
using Restaurant_DeveloperCase.BLL.Services.Abstract;

namespace Restaurant_DeveloperCase_MVC.Controllers
{
    public class HomeController : _BaseController
    {
        public HomeController(IUnitOfWork uow,IValidate validate) : base(uow,validate)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            bool IsAuthenticate = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.IsAuthenticate = IsAuthenticate;
            return View();
        }

        public ActionResult Rezervasyon(TableModel model)
        {
            ViewBag.Saatler = SaatDoldur();
            
            int modId = (model.Tarih.Day % 3);
            if (modId == 0)
                modId = 3;
            int allTableId = 
                _uow.GetRepo<AllTable>()
                .Where(x => 
                x.ModId == modId && x.TableId == model.TableId)
                .FirstOrDefault()
                .Id;
            TempData["TumMasalar"] = allTableId;
            TempData["Tarih"] = model.Tarih.Date;

            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Rezervasyon(Reservation model)
        {
            var validator = _validate.Factory<ReservationValidator, Reservation>(model);

            if (validator.IsValid)
            {

            }
            else
            {
                validator.Errors.ToList()
                    .ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
            }
            ViewBag.Saatler = SaatDoldur();
            return View();
        }

        private List<SelectListItem> SaatDoldur()
        {
            IEnumerable<int> hours = Enumerable.Range(11, 12);
            //string[] hours = { "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" };

            List<SelectListItem> saatler = new List<SelectListItem>();

            hours.ToList().ForEach(x => saatler.Add(new SelectListItem()
            {
                Text = x.ToString()+":00",
                Value = x.ToString()
            }));

            return saatler;
        }
    }
}