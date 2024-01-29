using System.ComponentModel.DataAnnotations;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- set min max by property -----------------------------------------------------------
    internal static void SetMinMaxByProperty(this NumericUpDown source, object instance, string property) {
      if (
        instance
          .GetType()
          .GetProperty(property)?
          .GetCustomAttributes(typeof(RangeAttribute), false)
          .FirstOrDefault() is RangeAttribute rangeAttribute
      ) { 
        source.Maximum = (int)rangeAttribute.Maximum;
        source.Minimum = (int)rangeAttribute.Minimum;
      }
    }
    #endregion
  }
}