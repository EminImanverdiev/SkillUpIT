using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class XEntityValidator : AbstractValidator<XEntity>
    {
        public XEntityValidator()
        {
            RuleFor(x => x.XName).MinimumLength(3).NotEmpty();
            RuleFor(x => x.XName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}