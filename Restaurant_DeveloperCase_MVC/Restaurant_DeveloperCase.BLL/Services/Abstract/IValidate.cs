using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.BLL.Services.Abstract
{
    public interface IValidate
    {
        ValidationResult Factory<T, TModel>(TModel model) where T : AbstractValidator<TModel>, new()
            where TModel : class, new();
    }
}
