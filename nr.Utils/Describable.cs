using System.Reflection;
using System.Text;

namespace nr.Utils
{
    public static class Describable
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)] public class ExcludeAttribute : Attribute { }

        public static string Describe(this object source, string? numberFormatInfo = null, string? dateTimeFormatInfo = null) {
            return source.Describe(numberFormatInfo, dateTimeFormatInfo, 0);
        }

        public static bool IsNumeric(this object obj) =>
            obj is double ||
            obj is float ||
            obj is int ||
            obj is long ||
            obj is byte ||
            obj is short ||
            obj is decimal ||
            obj is uint ||
            obj is ulong ||
            obj is ushort
            ;

        private static string Describe(this object source, string? numberFormatInfo, string? dateTimeFormatInfo, int recursion) {
            if (recursion > 10) return $"{source}...";

            if (source is ICollection<object> e) {
                return $"[{string.Join(',', [.. e.Select(i => i.Describe(numberFormatInfo, dateTimeFormatInfo, recursion + 1))])}]";
            }
            var className = source.GetType().Name;
            var properties = source.GetType().GetProperties().SkipWhile(p => p.GetCustomAttributes<ExcludeAttribute>().Any());
            return new StringBuilder()
                .Append(className).Append('(')
                .AppendJoin(',', properties.Select(p => {
                    var v = p.GetValue(source);
                    if (v == null)
                        return $"{p.Name}=null";
                    if (v is DateTime d)
                        return $"{p.Name}=#{d.ToString(dateTimeFormatInfo)}#";
                    if (v is DateOnly dateOnly)
                        return $"{p.Name}=#{dateOnly.ToString(dateTimeFormatInfo)}#";
                    if (v is TimeOnly timeOnly)
                        return $"{p.Name}=#{timeOnly.ToString(dateTimeFormatInfo)}#";
                    if (v.IsNumeric())
                        if (numberFormatInfo != null)
                            return $"{p.Name}={string.Format(numberFormatInfo, v)}";
                        else
                            return $"{p.Name}={v}";
                    if (v is string) {
                            return $"{p.Name}=\"{v}\"";
                        }
                    return $"{p.Name}={v.Describe(numberFormatInfo, dateTimeFormatInfo, recursion + 1)}";
                }))
                .Append(')').ToString();
        }
    }

}
