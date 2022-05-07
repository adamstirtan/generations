using System.Reflection;

namespace Generations.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasProperty(this Type obj, string propertyName)
        {
            return obj.GetProperty(
                propertyName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                is not null;
        }
    }
}