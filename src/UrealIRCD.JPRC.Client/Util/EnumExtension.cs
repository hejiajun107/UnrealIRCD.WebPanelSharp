using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UrealIRCD.JPRC.Client.Util
{
    public class EnumKeyAttribute : Attribute
    {
        public string Name { get; set; }
    }

    public static class EnumExtension
    {
        public static string GetKey(this Enum e)
        {
            var type = e.GetType();
            string enumName = Enum.GetName(type, e)!;
            FieldInfo field = type.GetField(enumName)!;
            var key = field.GetCustomAttribute<EnumKeyAttribute>();
            return key is not null ? key.Name : e.ToString();
        }
    }
}
