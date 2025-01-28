using System.Reflection;
using System.Text;

namespace nr.Utils
{
    public static class Describable
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)] public class ExcludeAttribute : Attribute { }

        public static string Describe(this object source) {
            var className = source.GetType().Name;
            var properties = source.GetType().GetProperties().SkipWhile(p => p.GetCustomAttributes<ExcludeAttribute>().Any());
            return new StringBuilder()
                .Append(className).Append('(')
                .AppendJoin(',', properties.Select(p => $"{p.Name}={p.GetValue(source)?.ToString() ?? "null"}"))
                .Append(')').ToString();
        }
    }

}
