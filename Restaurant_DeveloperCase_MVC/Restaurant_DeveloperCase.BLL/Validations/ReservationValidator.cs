using FluentValidation;
using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.BLL.Validations
{

    public class ReservationValidator:AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez!");
        }
    }
}
