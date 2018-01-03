using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF38_2016GUI.UI
{
    public class PopustValidation : ValidationRule
    {
        Regex regex = new Regex("[^0-9.]");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var v = value as string;

            //double popust = Double.Parse(v);
            try
            {
                if (regex.Match(v).Success && double.Parse(v) > 2 && double.Parse(v) < 98)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Unesite broj izmedju 2 i 98!");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Unesite broj izmedju 2 i 98!");
            }
        }
    }
}
