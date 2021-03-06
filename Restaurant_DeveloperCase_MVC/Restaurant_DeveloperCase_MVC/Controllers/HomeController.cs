﻿using System;
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
            ViewBag.Saatler = SaatDoldur();
            return View();
        }

        public ActionResult Rezervasyon(TableModel model)
        {

            ViewBag.Saatler = SaatDoldur();
            
            int modId = (model.Tarih.Day % 3);
            if (modId == 0)
                modId = 3;

            int tableId = 
                _uow.GetRepo<Table>().Where(x => x.TableName == model.TableName && x.BaslangicSaati ==Convert.ToInt32(model.baslangicSaat))
                .FirstOrDefault().Id;

            int allTableId = 
                _uow.GetRepo<AllTable>()
                .Where(x => 
                x.ModId == modId && x.TableId == tableId)
                .FirstOrDefault()
                .Id;

            RezerveKontrol(allTableId);
            SaatKontrol(allTableId);

            TempData["TumMasalar"] = allTableId;
            TempData["Tarih"] = model.Tarih.Date;

            return View();
        }

        private void SaatKontrol(int allTableId)
        {
            AllTable masa = _uow.GetRepo<AllTable>().GetById(allTableId);
            if (masa.RezerveTarihi < DateTime.Now)
                masa.IsFill = false;
        }

        private RedirectToRouteResult RezerveKontrol(int allTableId)
        {
            if (_uow.GetRepo<AllTable>().GetById(allTableId).IsFill)
                ViewBag.Msg = "Seçtiğiniz masa dolu!";
             return RedirectToAction("Index");
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Rezervasyon(Reservation model)
        {
            var validator = _validate.Factory<ReservationValidator, Reservation>(model);

            if (validator.IsValid)
            {
                _uow.GetRepo<Reservation>().Add(model);
                var masa = _uow.GetRepo<AllTable>().GetById(model.AllTableId);
                masa.IsFill = true;
                masa.RezerveTarihi = DateTime.Now;
                if (_uow.Commit() > 0)
                    ViewBag.Msg = "İşlem başarıyla gerçekleştirildi!";
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