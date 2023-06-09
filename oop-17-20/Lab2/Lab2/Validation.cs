using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2
{
    public class Validation
    {

        #region Валидатор ID
        public class UDKValidation : ValidationAttribute
        {
            public Regex regex = new Regex(@"\d*");
            public override bool IsValid(object value)
            {
                if (regex.IsMatch((string)value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool IsValidStr(string value)
            {
                if (regex.IsMatch((string)value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

    }
}
