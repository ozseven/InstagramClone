using FluentValidation.Validators;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public class PasswordValidator<T,TProperty>:PropertyValidator<T,TProperty>,IPasswordValidator
    {

        public override string Name => "PasswordValidator";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            //Şifre kullanıcı adı bulunduruluyor mu bunu kontrol etmelisin!!!
            if (value == null)
            {
                return false;
            }
            if (value is string s)
            {
                if (Regex.IsMatch(s,"[A-Z]") && Regex.IsMatch(s,"[a-z]")&&Regex.IsMatch(s,"[0-9]"))
                {
                    return false;
                }
            
                
            }
            return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }

        private static bool IsEmpty(IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();

            using (enumerator as IDisposable)
            {
                return !enumerator.MoveNext();
            }
        }
    }

    public interface IPasswordValidator: IPropertyValidator
    {
    }
}
