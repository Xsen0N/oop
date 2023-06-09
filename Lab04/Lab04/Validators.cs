using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Lab04
{
    public class NumericAttribute : ValidationAttribute // проверка числовых значений
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            int.TryParse(value.ToString(), out int result);
            if (result <= 0 && result > 99999)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
    public class StringAttribute : ValidationAttribute // проверка строковых значений
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^[a-zA-Zа-яА-ЯёЁ]+(?:[\\s-][a-zA-Zа-яА-ЯёЁ]+)*$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class ImgAttribute : ValidationAttribute // проверка пути 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex2 = new Regex("^(\\/?[a-zA-Z0-9\\s_\\\\.\\-\\(\\):])+(.jpg|.jpeg|.png|.gif|.bmp)$");
                if (!regex2.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class DiscrAttribute : ValidationAttribute // проверка пути 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^[a-zA-Zа-яА-ЯёЁ0-9()]+(?:[\\s-][a-zA-Zа-яА-ЯёЁ0-9()]+)*$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }



}
