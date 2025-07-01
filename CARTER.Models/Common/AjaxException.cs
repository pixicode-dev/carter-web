using System;
using System.Globalization;

namespace CARTER.Models.Common
{
    public class AjaxException : Exception
    {
        public AjaxException() : base() { }

        public AjaxException(string message) : base(message) { }

        public AjaxException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
