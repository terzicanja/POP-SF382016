using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF38_2016GUI.UI
{
    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            double broj;

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Molim vas popunite polja");
            }

            try
            {
                broj = double.Parse(str);
                if (broj < 1)
                {
                    return new ValidationResult(false, "Unesite pozitivan broj");
                }
            }
            catch
            {
                return new ValidationResult(false, "Unesite pozitivan broj");
            }
            return new ValidationResult(true, null);
        }
    }
}
