using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace District64.District64Mvc.Models
{
    /// <summary>
    /// Used to extend a Validation to ensure 
    /// the object value is of Int32
    /// </summary>
    public class IntegerValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Used to validate the object is Int32, using TryParse pattern
        /// </summary>
        /// <param name="value">object to be evaluated</param>
        /// <returns>true/false if valid Int32</returns>
        public override bool IsValid(object value)
        {
            if (value == null) return true;

            int dummy;
            bool test = Int32.TryParse(value.ToString(), out dummy);
            return test;
        }
    }
}