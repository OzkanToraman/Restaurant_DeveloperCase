using Restaurant_DeveloperCase.BLL.Services.Abstract;
using Restaurant_DeveloperCase.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_DeveloperCase_MVC.Controllers
{
    public class _BaseController:Controller
    {
        protected IUnitOfWork _uow;
        protected IValidate _validate;
        private IUnitOfWork uow;

        public _BaseController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public _BaseController(IUnitOfWork uow,IValidate validate)
        {
            _validate = validate;
            _uow = uow;
        }
    }
}