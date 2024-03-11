using System.ComponentModel.DataAnnotations;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- set max length by property --------------------------------------------------------
    internal static void SetMaxLengthByProperty(this TextBox source, object instance, string property) {
      if (
        instance
          .GetType()
          .GetProperty(property)?
          .GetCustomAttributes(typeof(StringLengthAttribute), false)
          .FirstOrDefault() is StringLengthAttribute stringLengthAttribute
      ) { 
        source.MaxLength = stringLengthAttribute.MaximumLength;
      }
    }
    #endregion
  }
}