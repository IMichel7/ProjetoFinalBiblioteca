using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
//Michel Furtado da Silva
namespace ProjetoFinalBiblioteca
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return value.ToString();

            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false)
                               .OfType<DescriptionAttribute>()
                               .ToArray();

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }
    }
}