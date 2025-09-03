using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FagValidator : AbstractValidator<Fag>
    {
        public FagValidator()
        {
            RuleFor(x => x.Content).MinimumLength(3).NotEmpty();
            //RuleFor(x => x.Title).Must(StartWithA);
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("");
        //}
    }
}