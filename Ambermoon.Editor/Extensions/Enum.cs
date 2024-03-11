using System.ComponentModel;
using System.Reflection;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- description -----------------------------------------------------------------------
    internal static string? Description(this Enum source) {
      FieldInfo? fieldInfo = source
        .GetType()
        .GetField(source.ToString());

      if (fieldInfo is not null) {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
          .GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
      }

      return string.Empty;
    }
    #endregion
    #region --- get flags -------------------------------------------------------------------------
    internal static IEnumerable<Enum> GetFlags(this Enum source) {
      return Enum
        .GetValues(source.GetType())
        .Cast<Enum>()
        .Where(source.HasFlag)
        .Distinct();
    }
    #endregion
    #region --- get values as ordered string list -------------------------------------------------
    internal static List<string> GetValuesAsOrderedStringList(this Enum source) {
      return
      [
        .. Enum
          .GetValues(source.GetType())
          .Cast<Enum>()
          .Distinct()
          .Select(x => x.ToString())
          .OrderBy(x => x),
      ];
    }
    #endregion
  }
}