using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF38_2016GUI.UI
{
    public class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Molim vas popunite polje");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
