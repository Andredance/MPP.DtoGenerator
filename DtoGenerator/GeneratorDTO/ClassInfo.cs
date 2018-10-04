using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    internal static class ClassInfo
    {
        internal static List<ConstructorInfo> GetClassConstructorsInfo(Type t)
        {
            return new List<ConstructorInfo>(t.GetConstructors());
        }

        internal static List<PropertyInfo> GetClassPropertiesInfo(Type t)
        {
            return new List<PropertyInfo>(t.GetProperties());
        }

        internal static List<FieldInfo> GetClassFieldsInfo(Type t)
        {
            return new List<FieldInfo>(t.GetFields());
        }
    }
}
