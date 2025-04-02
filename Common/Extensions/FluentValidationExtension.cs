using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class FluentValidationExtension
    {
        public static IRuleBuilderOptions<T, TProperty> Password<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.SetValidator(new PasswordValidator<T, TProperty>());
    }
}

