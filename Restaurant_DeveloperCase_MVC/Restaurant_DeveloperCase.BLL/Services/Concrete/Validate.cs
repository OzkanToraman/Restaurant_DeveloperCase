using Restaurant_DeveloperCase.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Restaurant_DeveloperCase.BLL.Services.Concrete
{
    public class Validate : IValidate
    {
        public ValidationResult Factory<T,TModel>(TModel model) where T : AbstractValidator<TModel>, new()
            where TModel:class,new()
        {
            return new T().Validate(model);
        }
    }
}
